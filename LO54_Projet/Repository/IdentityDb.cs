using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using LO54_Projet.Models;
using System.Web.Providers.Entities;
using LO54_Projet.Entities;
using System.Data.Entity;
using LO54_Projet.Tools;

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

        public ApplicationUser GetById(string id)
        {
            return Users.Find(id);
        }

        public ApplicationUser GetByIdEager(string id)
        {
            return Users.Include(u => u.UserSharedUVs)
                        .Include(u => u.QuizzTaken)
                        .Where(u => u.Id == id)
                        .FirstOrDefault();
        }

        public ApplicationUser GetByEmailEager(string email)
        {
            return Users.Include(u => u.UserSharedUVs)
                        .Include(u => u.QuizzTaken)
                        .Where(u => u.Email == email)
                        .FirstOrDefault();
        }

        public string GetUsername(string id)
        {
            return GetById(id).UserName;
        }

        public string GetUserRole(string id)
        {
            try
            {
                return GetById(id).Role;
            }
            catch
            {
                return CustomRoles.roles.Etud.ToString();
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
        
        public void AddSharedUV(string userId, int uvId)
        {
            ApplicationUser user = GetByIdEager(userId);
            user.UserSharedUVs.Add(new UserSharedUV(userId, uvId));
            SaveChanges();
        }

        public void setRole(string userId, string role)
        {
            ApplicationUser user = GetByIdEager(userId);
            user.Role = role;
            SaveChanges();
        }

        public void addQuizzTaken(string userId, int quizzId,int score,int scoreMax)
        {
            ApplicationUser user = GetByIdEager(userId);
            user.QuizzTaken.Add(new User_Quizz(userId, quizzId, score,scoreMax));
            SaveChanges();
        }
    }
}