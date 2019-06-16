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

        public int IdQuizz { get; set; }

        [Required]
        public Quizz MyQuizz{ get; set; }

        [Required]
        public string Enonce { get; set; }

        public AnswereType Type { get; set; }

        [ForeignKey("questionRelated")]
        public List<Answer> OtherAnsweres { get; }

        public Question()
        {
            OtherAnsweres = new List<Answer>();
        }

        public Question(Quizz quizz, string enonce, AnswereType type)
        {
            Type = type;
            Enonce = enonce;
            OtherAnsweres = new List<Answer>();
            MyQuizz = quizz;
            IdQuizz = MyQuizz.IdQuizz;
        }

        public Question(Quizz quizz,string enonce, List<Answer> otherAnsweres,AnswereType type)
        {
            Type = type;
            Enonce = enonce;
            OtherAnsweres = otherAnsweres;
            MyQuizz = quizz;
            IdQuizz = MyQuizz.IdQuizz;
        }

        //Return true if the answere is the correct answere
        //public bool AnswereQuestion(Answere answere)
        //{
        //    return answere.answere == goodAnswere.answere;
        //}
    }
}