using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarRental.Models.Entities
{
    public class Customer
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage ="Boş bırakılamaz")]
        
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz")]

        public string LastName { get; set; }
      
        public string FullName
        {
            get
            {
                string full = FirstName +" "+ LastName;
                return full;
            }
            set
            {

            }
        }
        [Required(ErrorMessage ="Boş bırakılamaz")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [Column(TypeName = "char"),MaxLength(11, ErrorMessage = "11'den fazla karakter giremezsiniz"),MinLength(11, ErrorMessage = "11'den az karakter giremezsiniz")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Boş bırakılamaz")]
        public string BloodGroup { get; set; }
        public string Adress { get; set; }
        [Required(ErrorMessage ="Boş bırakılamaz")]
        [Column(TypeName = "char"), MaxLength(11, ErrorMessage = "11'den fazla karakter giremezsiniz"), MinLength(11, ErrorMessage = "11'den az karakter giremezsiniz")]
        public string CreditCardNumber { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [Column(TypeName ="char"), MaxLength(11, ErrorMessage = "11'den fazla karakter giremezsiniz"), MinLength(11, ErrorMessage = "11'den az karakter giremezsiniz")]
        public string TC { get; set; }
        [Required(ErrorMessage ="Boş bırakılamaz")]
        [Column(TypeName = "bit")]
        public bool Licence { get; set; }

    }
}