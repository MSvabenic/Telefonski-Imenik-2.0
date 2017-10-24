using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonskiImenik.Models;
using TelefonskiImenik.ViewModels;

namespace TelefonskiImenik.Controllers
{
    public class DodajOsobuController : Controller
    {
        private ApplicationDbContext _context;

        public DodajOsobuController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: DodajOsobu
        public ActionResult Create()
        {
            var viewModel = new UnosBrojaViewModel
            {
                TipBroja = _context.BrojTipovi.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(UnosBrojaViewModel viewModel,HttpPostedFileBase upload)
        {

            var file = Request.Files[0];                            // kod za spremanje slike u bazu podataka
            var content = new byte[file.ContentLength];             // nakodirati provjeru naknadno
            file.InputStream.Read(content, 0, file.ContentLength);
            viewModel.Slika = content;

            if (!ModelState.IsValid)  // provjera modela, ako je ok sprema, ako nije vraća natrag original model
            {
                viewModel.TipBroja = _context.BrojTipovi.ToList();
                return View("Create", viewModel);
            }

            Osoba os = new Osoba()  // instanciranje objekta osoba, parent tablica
            {
                Ime = viewModel.Ime,
                Prezime = viewModel.Prezime,
                Grad = viewModel.Grad,
                Opis = viewModel.Opis,
                Slika = content
            };

            _context.Osobe.Add(os);
            _context.SaveChanges();

            BrojeviOsoba bo = new BrojeviOsoba()  // instanciranje objekta brojevi osoba, child tablica
            {
                OsobaId = os.OsobaId, // id iz tablice osoba
                BrojTipId = viewModel.BrojTip,
                Broj = viewModel.Broj,
                Opis = viewModel.OpisBroja
            };

            _context.BrojeviOsobe.Add(bo);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int Id)
        {
            var os = _context.Osobe.Where(o => o.OsobaId == Id).FirstOrDefault();

            return View(os);
        }

        public ActionResult DohvatiSliku(int Id) // controller za zvanje slike iz baze podataka, izmijeniti logiku za slučaj kada nema slike
        {
            var stream = (from m in _context.Osobe where m.OsobaId == Id select m.Slika).FirstOrDefault();

            return File(stream, "image/jpeg");
        }
    }
}