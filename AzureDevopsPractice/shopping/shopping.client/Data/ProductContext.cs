using shopping.client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopping.client.Data
{
    public class ProductContext
    {
        public static readonly List<Product> Products = new List<Product>
        {
            new Product()
            {
                Name="Mouse",
                Description="New Phone Launched of logitect wireless mouse",
                Image="product-1.jpg",
                Categories="Accesories"

            },
            new Product()
            {
                Name="KeyBoard",
                Description="new device os a awseome keyboard thatv is mechanical and also have cherry mx blue click buttons",
                Image="product-3.jpg",
                Categories="Accesories"

            },
        };
    }
}
