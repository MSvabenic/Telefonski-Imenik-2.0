using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TelefonskiImenik.Models
{
    [Table("BrojeviOsoba")]
    public class BrojeviOsoba
    {
        public int BrojeviOsobaId { get; set; }
       
        public int OsobaId { get; set; }

        [Required]
        public virtual Osoba Osoba{ get; set; }
       
        public int BrojTipId { get; set; }

        [Required]
        public virtual BrojTip BrojTip { get; set; }

        [Required]
        public string Broj { get; set; }

        public string Opis { get; set; }
    }
}