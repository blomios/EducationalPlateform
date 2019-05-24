using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LO54_Projet.Entities;

namespace LO54_Projet.Repository
{
    public class QuizzDb : DbContext
    {
        public DbSet<Quizz> Quizzes { get; set; } // Créer la table Quizzes à partir des objets Quizz implémentés avec le site web

        public QuizzDb()
            : base("TestReel")
        {

        }
    }
}