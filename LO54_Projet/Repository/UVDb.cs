using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LO54_Projet.Entities;

namespace LO54_Projet.Repository
{
    public class UVDb : DbContext
    {
        public DbSet<UV> UVs { get; set; } // Créer la table UVs à partir des objets UV implémentés avec le site web

        public UVDb()
            :base("TestReel")
        {

        }
        
        public List<UV> getLinkedUvs(string userId)
        {
            List<UV> maListe = UVs.ToList();
            string eMail = "";
            using (var identityDbContext = new IdentityDb())
            {
                eMail = identityDbContext.getUserMail(userId);
            }

            return maListe.FindAll(u => u.Owner.Equals(eMail));
        }
    }
}