using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopping.API.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Categories { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Decimal Price { get; set; }
    }
}
