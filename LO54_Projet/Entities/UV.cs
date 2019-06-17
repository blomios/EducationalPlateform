using LO54_Projet.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace LO54_Projet.Entities
{
    public class UV
    {
        [Key]
        public int IdUv { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(4)]
        public string Denomination { get; set; } // GL52, LO54 ...
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Owner { get; set; }

        public UV() {}

        public UV(string denom, string name, string desc, string owner)
        {
            Denomination = denom;
            Name = name;
            Description = desc;
            Owner = owner;
        }

        public static bool IsValidDenomination(string denomination)
        {
            // r reconnait donc les trucs sous la forme CCNN ou CCCN (2 lettres 2 chiffres/ 3 lettres un chiffre)
            Regex r = new Regex("(([A-Z]){2}([0-9]){2})|(([A-Z]){3} ([0-9]))");
            return denomination.Length == 4 && r.IsMatch(denomination);
        }
    }
}