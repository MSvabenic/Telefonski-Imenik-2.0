using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonskiImenik.Models;
using Models.ViewModels;

namespace TelefonskiImenik.Controllers
{
    public class KontaktMVCController : Controller
    {
        private ApplicationDbContext _context;

        public KontaktMVCController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: DodajOsobu
        public ActionResult DodajOsobu()
        {
            var viewModel = new OsobaViewModel();
            return View(viewModel);
        }

        public ActionResult DodajBroj()
        {
            ViewBag.punoime = from osoba in _context.Osobe.ToList()
                              select new
                              {
                                  Id = osoba.OsobaId,
                                  punoime = osoba.Ime + " " + osoba.Prezime
                              };
            var viewModel = new BrojViewModel()
            {
                TipBroja = _context.BrojTipovi.ToList(),
                Osobe = _context.Osobe.ToList()

            };
            return View(viewModel);
        }
    }
}