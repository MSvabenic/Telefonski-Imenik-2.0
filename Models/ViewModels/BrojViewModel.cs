﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TelefonskiImenik.Models;

namespace Models.ViewModels
{
    public class BrojViewModel
    {

        [DisplayName("Osoba")]
        public int OsobaId { get; set; }

        public IEnumerable<Osoba> Osobe { get; set; }

        [DisplayName("Tip broja telefona")]
        [Required(ErrorMessage ="Tip broja je obvezan za unos.")]
        public int BrojTip { get; set; }

        public IEnumerable<BrojTip> TipBroja { get; set; }

        [Required(ErrorMessage = "Broja je obvezan za unos.")]
        public string Broj { get; set; }

        [DisplayName("Opis broja")]
        public string OpisBroja { get; set; }
    }
}