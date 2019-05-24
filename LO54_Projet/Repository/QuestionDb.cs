using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LO54_Projet.Entities;

namespace LO54_Projet.Repository
{
    public class QuestionDb : DbContext
    {
        public DbSet<Question> Questions { get; set; } // Créer la table UVs à partir des objets UV implémentés avec le site web

        public QuestionDb()
            : base("TestReel")
        {

        }
    }
}

/*
  CreateTable(
                "dbo.Questions",
                c => new
                {
                    IdQuestion = c.Int(nullable: false, identity: true),
                    Enonce = c.String(nullable: false),
                    Type = c.String(nullable: false),
                    IdAnswer = c.Int(nullable: false),
                    IdQuizz = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.IdQuestion);
            AddForeignKey("dbo.Questions", "IdQuizz", "dbo.Quizzs", "IdQuizz", true,"FK_Questions_Quizz");
     */
