using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        public byte[] Slika { get; set; }

        [DisplayName("Tip broja telefona")]
        public int BrojTip { get; set; }

        public IEnumerable<BrojTip> TipBroja { get; set; }

        public string Broj { get; set; }

        [DisplayName("Opis broja")]
        public string OpisBroja { get; set; }
    }
}