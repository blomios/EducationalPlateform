using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LO54_Projet.Models;

namespace LO54_Projet.Entities
{
    public class inscripition
    {
        [Key]
        public ApplicationUser user { get; set; }

        [Required]
        public List<UV> listUV { get; set; }

        public inscripition(ApplicationUser user, List<UV> listUV)
        {
            this.user = user;
            this.listUV = listUV;
        }
    }
}