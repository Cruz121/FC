using FilmsCatalog.BL.Interfaces;
using System;

namespace FilmsCatalog.BL
{
    public class DataManager
    {
        private IFilmsRepository _filmsRepository;
        public DataManager(IFilmsRepository filmsRepository)
        {
            _filmsRepository = filmsRepository;
        }

        public IFilmsRepository FilmsRepository { get { return _filmsRepository; } }
    }
}
