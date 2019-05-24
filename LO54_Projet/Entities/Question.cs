using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LO54_Projet.Entities
{
    public class Question
    {
        [Key]
        public int IdQuestion { get; set; }

        [Required]
        public Quizz MyQuizz{ get; set; }

        [Required]
        public string Enonce { get; set; }

        AnswereType Type { get; set; }

        public Answere[] OtherAnsweres { get; }

        public Question(Quizz quizz,string enonce, Answere[] otherAnsweres,AnswereType type)
        {
            Type = type;
            Enonce = enonce;
            OtherAnsweres = otherAnsweres;
            MyQuizz = quizz;
        }

        //Return true if the answere is the correct answere
        //public bool AnswereQuestion(Answere answere)
        //{
        //    return answere.answere == goodAnswere.answere;
        //}
    }
}