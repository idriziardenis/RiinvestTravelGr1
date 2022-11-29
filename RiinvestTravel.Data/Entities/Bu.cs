using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RiinvestTravel.Data.Entities
{
    [Table("Bus")]
    public partial class Bu
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; } = null!;
    }
}
