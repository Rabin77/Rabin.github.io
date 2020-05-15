using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ghardailo.Models
{
    public class Product_Details
    {
        [Key]
        public int ProductId { get; set; }
        [Required]

        public int Stock { get; set; }

        public DateTime Manufacture { get; set; }

        public DateTime Expire { get; set; }

        public string ProductName { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        [NotMapped]
        public IFormFile BikeImage { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }

        public string ImageName { get; set; }

        public int CategoryId { get; set; }

    }
}
