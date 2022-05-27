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
        [HttpGet]
        public IActionResult SvuotaSala(int id)
        {
            var sala = dBManager_SaleCinema.SvuotaSala().Where(x => x.  ).FirstOrDefault();
            return View(sala);
        }
        [HttpGet]
        public IActionResult Aggiungi()
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
            dBManager_Spett.ScontoAnziani(spettatore);
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