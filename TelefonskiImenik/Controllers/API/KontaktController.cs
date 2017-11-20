using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using TelefonskiImenik.Models;

namespace TelefonskiImenik.Controllers.API
{
    public class KontaktController : ApiController
    {
        /*---------------------------------------------------------------------------------------------------*/
        private ApplicationDbContext _context;
        /*---------------------------------------------------------------------------------------------------*/
        public KontaktController()
        {
            _context = new ApplicationDbContext();
        }

        /*---------------------------------------------------------------------------------------------------*/
        [Route("api/Kontakt/GetBroj/{id}")]
        [HttpGet]
        public HttpResponseMessage GetBroj([FromUri]int id)
        {
            var broj = (from brojevi in _context.BrojeviOsobe
                        join brojtip in _context.BrojTipovi on brojevi.BrojTipId equals brojtip.BrojTipId
                        where brojevi.OsobaId == id
                        select new
                        {
                            Broj = brojevi.Broj,
                            BrojTip = brojtip.Naziv,
                            OpisBroja = brojevi.Opis
                        }).ToList();

            if (broj != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, broj);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Zapis ne postoji u bazi podataka.");
            }
        }

        /*---------------------------------------------------------------------------------------------------*/
        [Route("api/Kontakt/GetOsobe")]
        [HttpGet]
        public HttpResponseMessage GetOsobe()
        {
            var osoba = from oso in _context.Osobe
                        group oso by new
                        {
                            oso.Ime,
                            oso.Prezime
                        } into os
                        select os.FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, osoba);
        }

        /*---------------------------------------------------------------------------------------------------*/
        [Route("api/Kontakt/GetOsoba/{id}")]
        [HttpGet]
        public HttpResponseMessage GetOsoba(int id)
        {
            var osoba = _context.Osobe.Where(x => x.OsobaId == id).Select(x => new { x.Ime, x.Prezime, x.Grad, x.Opis }).ToList();
            if (osoba != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, osoba);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Osoba ne postoji u bazi podataka.");
            }
        }

        /*---------------------------------------------------------------------------------------------------*/
        [Route("api/Kontakt/DodajBroj")]
        [HttpPost]
        public HttpResponseMessage DodajBroj([FromBody]BrojeviOsoba broj)
        {
            try
            {
                _context.BrojeviOsobe.Add(broj);
                _context.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Created, broj);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /*---------------------------------------------------------------------------------------------------*/
        [Route("api/Kontakt/DodajOsobu")]
        [HttpPost]
        public HttpResponseMessage DodajOsobu([FromBody]Osoba osoba)
        {
            try
            {
                _context.Osobe.Add(osoba);
                _context.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Created, osoba);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}


