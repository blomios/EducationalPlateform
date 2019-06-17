using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LO54_Projet.Entities
{
    public class Answer
    {
        [Key]
        public int IdAnswere { get; set; }


        public int questionRelated{ get; set; }

        public string answere { get; set; }

        public bool isGoodAnswere { get; set; }

        public Answer(string answere, bool isGoodAnswere)
        {
            this.answere = answere;
            this.isGoodAnswere = isGoodAnswere;
        }

        public Answer(string answere, bool isGoodAnswere,int question)
        {
            this.answere = answere;
            this.isGoodAnswere = isGoodAnswere;
            this.questionRelated = question;
        }

        public Answer()
        {
        }
    }
}