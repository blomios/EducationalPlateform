using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LO54_Projet.Tools
{
    public class CustomRoles
    {
        public enum roles {Admin,Prof,Etud};

        public string getAdmin() { return roles.Admin.ToString(); }
        public string getProf() { return roles.Prof.ToString(); }
        public string getEtud() { return roles.Etud.ToString(); }

        public CustomRoles()
        { }
        public bool isRole(string role)
        {
            return Enum.IsDefined(typeof(roles), role);
        }

        public bool isAdmin(string role)
        {
            return getAdmin().Equals(role);
        }
        public bool isProf(string role)
        {
            return getProf().Equals(role);
        }
    }
}