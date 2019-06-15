using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LO54_Projet.Entities
{
    public class Project
    {
        [Key]
        public int IdProject { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [Required]
        public int IdUV { get; set; }

        public Project() { }

        public Project(string name, string desc, string ownerId, int idUV)
        {
            Name = name;
            Description = desc;
            OwnerId = ownerId;
            IdUV = idUV;
        }
    }
}