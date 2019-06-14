using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using LO54_Projet.Models;
using System.Web.Providers.Entities;

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