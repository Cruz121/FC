using FilmsCatalog.BL;
using FilmsCatalog.DL.Entity;
using FilmsCatalog.PL.Models;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FilmsCatalog.PL.Services
{
    public class FilmsService
    {
        private DataManager _dataManager;
        public FilmsService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public string AddFilm(FilmViewModel model, IFormFile img)
        {
            if (model != null)
            {
                var film = new Film
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    YearRelease = model.YearRelease,
                    MovieDirector = model.MovieDirector,
                    UserPosted = model.UserPosted
                };
                if (img != null)
                {
                    byte[] imageData = null;
                    using (var reader = new BinaryReader(img.OpenReadStream()))
                    {
                        imageData = reader.ReadBytes((int)img.Length);
                    }

                    film.Poster = imageData;
                }
                return _dataManager.FilmsRepository.AddFilm(film);
            }
            return null;
        }

        public List<FilmViewModel> GetFilmsList()
        {
            var data = _dataManager.FilmsRepository.GetAllFilms();
            var viewModels = new List<FilmViewModel>();
            foreach (var item in data)
            {
                var filmVM = new FilmViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    YearRelease = item.YearRelease,
                    MovieDirector = item.MovieDirector,
                    UserPosted = item.UserPosted,
                    Poster = item.Poster
                };
                //using (var stream = new MemoryStream(item.Poster))
                //{
                //    IFormFile file = new FormFile(stream, 0, item.Poster.Length, item.Name, item.Name);
                //    filmVM.Poster = file;
                //};

                viewModels.Add(filmVM);

            }
            return viewModels;

        }

        public async Task<List<FilmViewModel>> GetFilmsListAsync()
        {
            var data = await _dataManager.FilmsRepository.GetAllFilmsAsync();
            var viewModels = new List<FilmViewModel>();
            foreach (var item in data)
            {
                var filmVM = new FilmViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    YearRelease = item.YearRelease,
                    MovieDirector = item.MovieDirector,
                    UserPosted = item.UserPosted,
                    Poster = item.Poster

                };
                viewModels.Add(filmVM);
            }
            return viewModels;
        }

        public string EditFilm(FilmViewModel model, IFormFile img)
        {
            if(model != null)
            {
                var film = new Film
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    YearRelease = model.YearRelease,
                    MovieDirector = model.MovieDirector,
                    UserPosted = model.UserPosted,
                };
                if (img != null)
                {
                    byte[] imageData = null;
                    using (var reader = new BinaryReader(img.OpenReadStream()))
                    {
                        imageData = reader.ReadBytes((int)img.Length);
                    }
                    film.Poster = imageData;
                }
                return _dataManager.FilmsRepository.EditFilm(film);
            }
            return null;
        }

        public async Task<FilmViewModel> GetFilmInfoAsync(int id)
        {
            var film = await _dataManager.FilmsRepository.GetFilmInfoAsync(id);
            var filmVM = new FilmViewModel
            {
                Id = film.Id,
                Name = film.Name,
                Description = film.Description,
                YearRelease = film.YearRelease,
                MovieDirector = film.MovieDirector,
                UserPosted = film.UserPosted,
                Poster = film.Poster
            };
            return filmVM;
        }

        public FilmViewModel GetFilmInfo(int id)
        {
            var film = _dataManager.FilmsRepository.GetFilmInfo(id);
            var filmVM = new FilmViewModel
            {
                Id = film.Id,
                Name = film.Name,
                Description = film.Description,
                YearRelease = film.YearRelease,
                MovieDirector = film.MovieDirector,
                UserPosted = film.UserPosted,
                Poster = film.Poster
            };
            return filmVM;
        }

    }
}
