using FilmsCatalog.BL.Interfaces;
using FilmsCatalog.DL;
using FilmsCatalog.DL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.BL.Implementations
{
    public class FilmsRepository : IFilmsRepository
    {
        private DBContext context;
        public FilmsRepository(DBContext context)
        {
            this.context = context;
        }

        public string AddFilm(Film film)
        {
            if (film != null)
            {
                var result = context.Add(film);
                context.SaveChanges();
                return result.Entity.Id.ToString();
            }
            return null;
        }

        public string EditFilm(Film film)
        {
            if (film != null)
            {
                var data = context.Films.FirstOrDefault(p => p.Id == film.Id);
                if (data != null)
                {
                    data.Name = film.Name;
                    data.Description = film.Description;
                    data.MovieDirector = film.MovieDirector;
                    data.YearRelease = film.YearRelease;
                    if (film.Poster != null)
                        data.Poster = film.Poster;
                    context.SaveChanges();
                    return film.Id.ToString();
                }
                return null;
            }
            return null;
        }

        public IEnumerable<Film> GetAllFilms()
        {
            return context.Films.ToList();
        }

        public async Task<IEnumerable<Film>> GetAllFilmsAsync()
        {
            return await context.Films.ToListAsync();
        }

        public Film GetFilmInfo(int filmID)
        {
            return context.Films.FirstOrDefault(p => p.Id == filmID);
        }

        public async Task<Film> GetFilmInfoAsync(int filmID)
        {
            return await context.Films.FirstOrDefaultAsync(p => p.Id == filmID);
        }
    }
}
