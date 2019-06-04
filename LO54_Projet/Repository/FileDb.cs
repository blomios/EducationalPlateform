using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LO54_Projet.Entities;

namespace LO54_Projet.Repository
{
    public class FileDb : DbContext
    {
        public DbSet<File> files { get; set; }

        public FileDb()
            : base("TestReel")
        {

        }
    }
}