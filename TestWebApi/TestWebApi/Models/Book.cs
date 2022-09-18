using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestWebApi.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int PubId { get; set; }
        public int? Price { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
