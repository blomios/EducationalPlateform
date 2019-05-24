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
        
    }
}