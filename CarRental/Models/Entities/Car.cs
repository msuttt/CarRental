using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarRental.Models.Entities
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public int ModelOfBrandId { get; set; }
        [ForeignKey("ModelOfBrandId")]
        public ModelOfBrand ModelOfBrand { get; set; }

        [Required]
        public string EngineCapacity { get; set; }

        [Required]
        public string EnginePower { get; set; }
        [Column(TypeName = "bit")]
        public bool AutomaticGear { get; set; }

        [Required]
        public string FuelType { get; set; }     

        [Required(ErrorMessage ="Boş geçilemez")]
        public string HirePrice { get; set; }                      

        [Required(ErrorMessage ="Bu alan boş geçilemez")]
        //[MaxLength(8, ErrorMessage = "8 karakterden fazla giremezsiniz"), MinLength(8, ErrorMessage = "8 karakterden az giremezsiniz")]
        public string Plate { get; set; }

        public int ColorId { get; set; }

        [ForeignKey("ColorId")]
        public Color Color { get; set; }       
        public DateTime PurchasingDate { get; set; }
        public string PhotoPath { get; set; }

    }
}