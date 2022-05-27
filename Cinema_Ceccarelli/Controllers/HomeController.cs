using Cinema_Ceccarelli.Models;
using Cinema_Ceccarelli.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;


namespace Cinema_Ceccarelli.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBManager dBManager;
        private DBManager_SaleCinema dBManager_SaleCinema;
        private DBManager_Spett dBManager_Spett;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            dBManager = new DBManager();
            dBManager_SaleCinema = new DBManager_SaleCinema();
            dBManager_Spett = new DBManager_Spett();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
            return View(dBManager.GetAllFilm());
        }
        //TOFIX
       /* [HttpGet]
        public IActionResult SvuotaSala(int id)
        {
            var sala = dBManager_SaleCinema.SvuotaSala();
            
            return View(sala);
        }
        [HttpPost]
        public IActionResult SvuotaSala(SalaViewModel sala)
        {
            var res = dBManager_SaleCinema.SvuotaSala();
            if (res != null)
                dBManager_SaleCinema.SvuotaSala(sala);

            return RedirectToAction("Index");
        }*/

        [HttpGet]
        public IActionResult AggiungiBiglietto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AggiungiBiglietto(BigliettoViewModel biglietto)
        {
            dBManager.AggiungiBiglietto(biglietto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AggiungiFilm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AggiungiFilm(FilmViewModel film)
        {
            dBManager.AggiungiFilm(film);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AggiungiSpettatore()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AggiungiSpettatore(SpettatoreViewModel spettatore)
        {
            dBManager_Spett.AggiungiSpettatore(spettatore);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ScontoAnziani()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ScontoAnziani(SpettatoreViewModel spettatore)
        {
            dBManager_Spett.ScontoAnziani(spettatore);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ScontoBimbi()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ScontoBimbi(SpettatoreViewModel spettatore)
        {
            dBManager_Spett.ScontoBimbi(spettatore);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult IncassoCinema()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IncassoCinema(SalaViewModel sala)
        {
            dBManager_SaleCinema.IncassoCinema(sala);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult IncassoSala()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IncassoSala(SalaViewModel sala)
        {
            dBManager_SaleCinema.IncassoSala(sala);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}