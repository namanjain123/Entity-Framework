using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class Email
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string EmailId { get; set; }
    }
}
