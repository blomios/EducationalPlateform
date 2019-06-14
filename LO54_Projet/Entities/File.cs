using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace LO54_Projet.Entities
{
    public class File
    {
        [Key]
        public int IdFile { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FilePath { get; set; }

        [Required]
        public UV Uv { get; set; }

        public File() { }

        public File(string Name, string FilePath, UV uv)
        {
            this.Name = Name;
            this.FilePath = FilePath;
            this.Uv = uv;
        }
    }
}