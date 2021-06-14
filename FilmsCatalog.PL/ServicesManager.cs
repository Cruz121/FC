using FilmsCatalog.BL;
using FilmsCatalog.PL.Services;
using System;

namespace FilmsCatalog.PL
{
    public class ServicesManager
    {
        DataManager _dataManager;
        private FilmsService _filmsService;
        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _filmsService = new FilmsService(_dataManager);
        }
        
        public FilmsService Films { get { return _filmsService; } }
    }
}
