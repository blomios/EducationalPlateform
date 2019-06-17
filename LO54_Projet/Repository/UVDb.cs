using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using LO54_Projet.Entities;
using System;

namespace LO54_Projet.Repository
{
    public class UVDb : DbContext
    {
        private static readonly UVDb Instance = new UVDb();
        public DbSet<UV> UVs { get; set; } // Créer la table UVs à partir des objets UV implémentés avec le site web

        public UVDb() :base("TestReel")
        {
        }

        public static UVDb GetInstance()
        {
            return Instance;
        }

        public UV GetByDenomination(string denomination)
        {
            return UVs.ToList().FirstOrDefault(uv => uv.Denomination == denomination);
        }

        public UV GetById(int id)
        {
            return UVs.Find(id);
        }

        public List<UV> GetLinkedUvs(string userId)
        {
            List<UV> maListe = UVs.ToList();
            string eMail = "";
            using (var identityDbContext = new IdentityDb())
            {
                eMail = identityDbContext.getUserMail(userId);
            }

            return maListe.FindAll(u => u.Owner.Equals(userId));
        }

        public void Save(UV uv)
        {
            UVs.Add(uv);
            SaveChanges();
            IdentityDb.GetInstance().AddSharedUV(uv.Owner, uv.IdUv);
        }

        public void Update(UV uv)
        {
            UV oldUV = UVs.First(u => u.IdUv == uv.IdUv);
            oldUV.Denomination = uv.Denomination;
            oldUV.Name = uv.Name;
            oldUV.Description = uv.Description;
            SaveChanges();
        }

        public void SaveOrUpdate(UV uv)
        {
            try
            {
                UVs.First(u => u.IdUv == uv.IdUv);
                Update(uv);
            }
            catch (InvalidOperationException)
            {
                Save(uv);
            }
        }

        public void DeleteByDenomination(string denomination)
        {
            UV uv = UVs.First(u => u.Denomination == denomination);
            UVs.Remove(uv);
            SaveChanges();
        }
    }
}