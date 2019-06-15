using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using LO54_Projet.Entities;
using System;

namespace LO54_Projet.Repository
{
    public class ProjectDb : DbContext
    {
        private static readonly ProjectDb Instance = new ProjectDb();
        public DbSet<Project> Projects{ get; set; } // Créer la table UVs à partir des objets UV implémentés avec le site web

        public ProjectDb() :base("TestReel")
        {
        }

        public static ProjectDb GetInstance()
        {
            return Instance;
        }

        public void Save(Project project)
        {
            Projects.Add(project);
            SaveChanges();
        }

        public void Update(Project project)
        {
            Project oldProject = Projects.First(p => p.IdProject == project.IdProject);
            oldProject.Name = project.Name;
            oldProject.Description = project.Description;
            SaveChanges();
        }

        public void SaveOrUpdate(Project project)
        {
            try
            {
                Projects.First(p => p.IdProject == project.IdProject);
                Update(project);
            }
            catch (InvalidOperationException)
            {
                Save(project);
            }
        }

        public void Delete(int id)
        {
            Projects.Remove(GetById(id));
            SaveChanges();
        }

        public Project GetById(int id)
        {
            return Projects.Find(id);
        }
    }
}