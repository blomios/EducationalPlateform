using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LO54_Projet.Entities;


namespace LO54_Projet.Repository
{
    public class AnswereDb : DbContext
    {
        public DbSet<Answer> Answeres { get; set; } // Créer la table UVs à partir des objets UV implémentés avec le site web

        public AnswereDb()
            : base("TestReel")
        {

        }
    }
}