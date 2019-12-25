using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models.Entities
{
    public class CarRentalInfo
    {
        public int Id { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Boş geçemezsiniz")]
        public DateTime StartingDate { get; set; }
        [Required(ErrorMessage = "Boş geçemezsiniz")]
        public DateTime EndDate { get; set; }
        public DateTime? Cancel { get; set; }
       
     
    }
}