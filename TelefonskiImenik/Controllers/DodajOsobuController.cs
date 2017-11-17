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
            var viewModel = new UnosBrojaViewModel();
            return View(viewModel);
        }
    }
}