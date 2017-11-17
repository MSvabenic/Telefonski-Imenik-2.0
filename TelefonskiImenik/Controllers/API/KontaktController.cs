using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TelefonskiImenik.Models;

namespace TelefonskiImenik.Controllers.API
{
    public class KontaktController : ApiController
    {
        private ApplicationDbContext _context;

        public KontaktController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Osoba> Get()
        {
            return _context.Osobe.ToList();
        }

        [Route("api/Kontakt/DodajOsobu")]
        [HttpPost]
        public HttpResponseMessage DodajOsobu([FromBody]Osoba osoba)
        {
            try
            {
                _context.Osobe.Add(osoba);
                _context.SaveChanges();

                //return Json(new { id = osoba.OsobaId });
                var message = Request.CreateResponse(HttpStatusCode.Created, osoba);
                message.Headers.Location = new Uri(Request.RequestUri + osoba.OsobaId.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("api/Kontakt/DodajBroj")]
        //POST: api/Kontakt
        [HttpPost]
        public HttpResponseMessage DodajBroj([FromBody]BrojeviOsoba broj)
        {
            try
            {
                _context.BrojeviOsobe.Add(broj);
                _context.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.Created, broj);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
