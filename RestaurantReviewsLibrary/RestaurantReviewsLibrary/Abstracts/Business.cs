using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewsLibrary.Abstracts
{
    public abstract class Business
    {
        public string Name { get; set; }
        public string Location { get; set; }

        protected Business() { }

        protected Business(string name, string loc)
        {
            Name = name;
            Location = loc;
        }
    }
}
