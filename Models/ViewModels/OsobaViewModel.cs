﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class OsobaViewModel
    {
        public int osobaid { get; set; }

        [Required(ErrorMessage = "Ime je obavezno za unos.")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno za unos.")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Grad je obavezan za unos.")]
        public string Grad { get; set; }

        public string Opis { get; set; }

        public byte[] Slika { get; set; }
    }
}
