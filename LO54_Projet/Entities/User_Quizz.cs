using LO54_Projet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LO54_Projet.Entities
{
    public class User_Quizz
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Quizz")]
        public int QuizzId { get; set; }

        public ApplicationUser User { get; set; }
        public Quizz Quizz{ get; set; }

        public int Score { get; set; }
        public int ScoreMax { get; set; }

        public User_Quizz() { }

        public User_Quizz(ApplicationUser user, Quizz quizz)
        {
            User = user;
            Quizz = quizz;
            Score = 0;
            ScoreMax = 0;
        }

        public User_Quizz(string user, int quizz)
        {
            UserId = user;
            QuizzId = quizz;
            Score = 0;
            ScoreMax = 0;
        }

        public User_Quizz(ApplicationUser user, Quizz quizz,int score,int scoreMax)
        {
            User = user;
            Quizz = quizz;
            Score = score;
            ScoreMax = scoreMax;
        }

        public User_Quizz(string user, int quizz,int score, int scoreMax)
        {
            UserId = user;
            QuizzId = quizz;
            Score = score;
            ScoreMax = scoreMax;
        }
    }
}