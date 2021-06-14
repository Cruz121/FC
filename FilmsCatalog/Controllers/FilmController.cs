using FilmsCatalog.DL.Entity;
using FilmsCatalog.PL;
using FilmsCatalog.PL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Controllers
{
    public class FilmController : Controller
    {
        private readonly UserManager<User> _userManager;
        private ServicesManager _servicesManager;


        public FilmController(UserManager<User> userManager, ServicesManager servicesManager)
        {
            _userManager = userManager;
            _servicesManager = servicesManager;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int page = 0)
        {
            var models = await _servicesManager.Films.GetFilmsListAsync();
            const int PageSize = 3;
            var count = models.Count;
            var data = models.Skip(page * PageSize).Take(PageSize).ToList();
            ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);
            ViewBag.Page = page;
            return View(data);
        }

        [HttpGet]
        [HttpPost]
        public IActionResult New()
        {
            return View(new FilmViewModel());
        }

        [HttpPost]
        public IActionResult AddFilm(FilmViewModel model, IFormFile img)
        {
            model.UserPosted = _userManager.GetUserName(User);
            var result = _servicesManager.Films.AddFilm(model, img);
            if (string.IsNullOrEmpty(result))
                return Redirect("/Home/Error");
            else
                return LocalRedirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _servicesManager.Films.GetFilmInfoAsync(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditFilm(FilmViewModel model, IFormFile img)
        {
            var result = _servicesManager.Films.EditFilm(model, img);
            if (string.IsNullOrEmpty(result))
                return Redirect("/Home/Error");
            else
                return LocalRedirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _servicesManager.Films.GetFilmInfoAsync(id);
            return View(model);
        }

    }
}
