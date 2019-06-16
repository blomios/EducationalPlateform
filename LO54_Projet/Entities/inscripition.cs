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
        public int IdInscription { get; set; }

        public String IdUser { get; set; }

        [Required]
        public UV uv { get; set; }

        public inscripition(String userid, UV uv)
        {
            this.IdUser = userid;
            this.uv = uv;
        }
    }
}