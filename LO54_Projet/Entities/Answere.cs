using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LO54_Projet.Entities
{
    public class Answere
    {
        [Key]
        public int IdAnswere { get; set; }

        public string answere { get; set; }
        public bool isGoodAnswere;

        public Answere(string answere, bool isGoodAnswere)
        {
            this.answere = answere;
            this.isGoodAnswere = isGoodAnswere;
        }

        public Answere()
        {
        }
    }
}