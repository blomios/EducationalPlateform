using LO54_Projet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LO54_Projet.Entities
{

    public class UserSharedUV
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("UV")]
        public int UVId { get; set; }

        public ApplicationUser User { get; set; }
        public UV UV { get; set; }

        public UserSharedUV() { }

        public UserSharedUV(ApplicationUser user, UV uv)
        {
            User = user;
            UV = uv;
        }

        public UserSharedUV(string user, int uv)
        {
            UserId = user;
            UVId = uv;
        }
    }
}