using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LO54_Projet.Entities
{
    public class Quizz
    {
        [Key]
        public int IdQuizz { get; set; }
        
        public string Name { get; set; } = "Toto";

        [Required]
        public int IdUv { get; set; }
        
        [ForeignKey("IdQuizz")]
        public List<Question> Questions { get; set; }

        public Quizz() { }

        public Quizz(string name, int linkedUV)
        {
            Name = name;
            Questions = new List<Question>();
            IdUv = linkedUV;
        }


        public Quizz(string name, List<Question> questions, int linkedUV)
        {
            Name = name;
            Questions = questions;
            IdUv = linkedUV;
        }
    }
}