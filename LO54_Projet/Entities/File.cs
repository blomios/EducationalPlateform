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
        public int idUv { get; set; }

        public File() { }

        public File(string Name, string FilePath, int idUv)
        {
            this.Name = Name;
            this.FilePath = FilePath;
            this.idUv = idUv;
        }
    }
}