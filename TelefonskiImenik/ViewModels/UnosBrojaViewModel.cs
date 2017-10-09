﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TelefonskiImenik.Models;

namespace TelefonskiImenik.ViewModels
{
    public class UnosBrojaViewModel
    {

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        public string Grad { get; set; }

        public string Opis { get; set; }

        public int BrojTip { get; set; }

        [DisplayName("Tip broja telefona")]
        public IEnumerable<BrojTip> TipBroja { get; set; }

        public int Broj { get; set; }

        [DisplayName("Opis broja")]
        public string OpisBroja { get; set; }
    }
}