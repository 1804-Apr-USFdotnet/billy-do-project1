using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Restaurant : EntityBase
    {
        // public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(40)]
        public string Street { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(20)]
        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        public List<Review> Reviews { get; set; }

        public double AverageRating
        {
            get
            {
                if (Reviews != null)
                    return Reviews.Sum(x => x.Id) / Reviews.Count();
                else
                    return 0;
            }
        }
    }
}
