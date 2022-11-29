using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RiinvestTravel.Data.Entities
{
    [Table("UserPicture")]
    public partial class UserPicture
    {
        public UserPicture()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        [Key]
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        [StringLength(50)]
        public string Extension { get; set; } = null!;
        public string Path { get; set; } = null!;

        [InverseProperty("Picture")]
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
