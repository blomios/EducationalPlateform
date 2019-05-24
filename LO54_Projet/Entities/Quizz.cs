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

        [Required]
        string Name { get; set; }

        [Required]
        public UV LinkedUV { get; set; }

        List<Question> Questions { get; set; }

        public Quizz(string name, List<Question> questions, UV linkedUV)
        {
            Name = name;
            Questions = questions;
            LinkedUV = linkedUV;
        }
    }
}