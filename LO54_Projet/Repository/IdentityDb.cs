using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using LO54_Projet.Models;
using System.Web.Providers.Entities;
using LO54_Projet.Entities;
using System.Data.Entity.Validation;

namespace LO54_Projet.Repository
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        private static readonly IdentityDb Instance = new IdentityDb();
        public IdentityDb()
            : base("TestReel")
        {
        }

        public static IdentityDb Create()
        {
            return new IdentityDb();
        }

        public static IdentityDb GetInstance()
        {
            return Instance;
        }

        public string GetUsername(string id)
        {
            return Users.FirstOrDefault(u => u.Id == id).UserName;
        }

        public string GetUserRole(string id)
        {
            return Users.FirstOrDefault(u => u.Id == id).Role;
        }

        public void AddUV(string id, UV uv)
        {
            try { 
            Users.Find(id).ListUV.Add(uv);
            SaveChanges();
        }
            catch (DbEntityValidationException e)
        {
            foreach (var eve in e.EntityValidationErrors)
            {
                      Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            foreach (var ve in eve.ValidationErrors)
            {
            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                ve.PropertyName, ve.ErrorMessage);
            }
                }
                
            }   
        }

        /// <summary>
        /// Get a User's mail throught it's ID
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>A string corresponding to the mail</returns>
        public string getUserMail(string userId)
        {
            return this.Users.FirstOrDefault(u => u.Id == userId).Email;
        }
        
        
    }
}