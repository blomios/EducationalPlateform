using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using LO54_Projet.Models;

namespace LO54_Projet.Repository
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb()
            : base("TestReel")
        {
        }

        public static IdentityDb Create()
        {
            return new IdentityDb();
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