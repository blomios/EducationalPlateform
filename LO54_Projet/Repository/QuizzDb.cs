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
        private static readonly QuizzDb Instance = new QuizzDb();
        public DbSet<Quizz> Quizzes { get; set; } // Créer la table Quizzes à partir des objets Quizz implémentés avec le site web

        public QuizzDb()
            : base("TestReel")
        {

        }

        public Quizz GetByIdString(string id)
        {
            return Quizzes.ToList().FirstOrDefault(quizz => quizz.IdQuizz.ToString() == id);
        }

        /// <summary>
        /// Comme GetById, mais de manière eager (on récupère les questions, et les réponses)
        /// </summary>
        /// <param name="id">L'identifiant du quizz</param>
        /// <returns>Un quizz</returns>
        public Quizz GetByIdStringEager(string id)
        {
            Quizz q = Quizzes
                        .Include(qu => qu.Questions.Select(a => a.OtherAnsweres))
                        .Where(qu => qu.IdQuizz.ToString() == id)
                        .FirstOrDefault();
            return q;
        }


        public static QuizzDb GetInstance()
        {
            return Instance;
        }

        public void Delete(string id)
        {
            Quizzes.Remove(GetByIdString(id));
            SaveChanges();
        }
    }
}