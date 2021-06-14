using FilmsCatalog.DL.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsCatalog.BL.Interfaces
{
    public interface IFilmsRepository
    {
        /// <summary>
        /// Добавление фильма в каталог.
        /// </summary>
        /// <param name="film">Фильм</param>
        /// <returns></returns>
        string AddFilm(Film film);

        /// <summary>
        /// Редактирование имеющегося в каталоге фильма.
        /// </summary>
        /// <param name="filmID"></param>
        /// <returns></returns>
        string EditFilm(Film film);

        /// <summary>
        /// Список всех фильмов (с пагинацией).
        /// </summary>
        IEnumerable<Film> GetAllFilms();

        /// <summary>
        /// Список всех фильмов (с пагинацией). Асинхронная операция.
        /// </summary>
        Task<IEnumerable<Film>> GetAllFilmsAsync();

        /// <summary>
        /// Информации об отдельном фильме.
        /// </summary>
        /// <param name="filmID">Идентификатор фильма</param>
        /// <returns></returns>
        Film GetFilmInfo(int filmID);

        /// <summary>
        /// Информации об отдельном фильме. Асинхронная операция.
        /// </summary>
        /// <param name="filmID">Идентификатор фильма</param>
        /// <returns></returns>
        Task<Film> GetFilmInfoAsync(int filmID);
    }
}
