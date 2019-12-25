using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarRental.Models.Entities
{
    public class ModelOfBrand
    {
        public int Id { get; set; }

        [Required]
        public int BrandId { get; set; }
       
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        [Required]
        [Column(TypeName = "varchar"), MaxLength(20)]
        public string Model { get; set; }
    }
}