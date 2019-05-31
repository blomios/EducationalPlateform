using LO54_Projet.Entities;
using LO54_Projet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Providers.Entities;
using System.Web.UI.WebControls;

namespace LO54_Projet.Services
{
    public class UVService
    {
        private static UVDb uvContext = new UVDb();

        public UV getByDenomination(string denomination)
        {
            try
            {
                return uvContext.UVs.First(uv => uv.Denomination == denomination);
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                return null;
            }
        }
        
        public void save(UV uv)
        {
            uvContext.UVs.Add(uv);
            uvContext.SaveChanges();
        }
    }
}