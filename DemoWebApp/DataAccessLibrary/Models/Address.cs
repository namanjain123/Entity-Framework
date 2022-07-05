using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class Address
    {
        //We will make it have better ones
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string StrertAddress { get; set; }
        [Required]
        [MaxLength(80)]
        public string City { get; set; }
        [Required]
        [MaxLength(100)]
        public string State { get; set; }
        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }


    }
}
