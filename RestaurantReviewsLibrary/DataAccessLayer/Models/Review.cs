using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Review : EntityBase
    {
        // public int Id { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [StringLength(25)]
        public string Username { get; set; }

        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        //public DateTime DateCreated { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
