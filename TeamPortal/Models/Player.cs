using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TeamPortal.Models
{
    public class Player
    {
        //public string Foo { get; set; }

        public Guid Id { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        [Required]
        [DisplayName("First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [DisplayName("Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        
        public string PhotoUri { get; set; }
        
        [DataType(DataType.ImageUrl)]
        [DisplayName("Photo")]
        public string PhotoToUpload { get; set; }
        
        [DisplayName("Jersey #")]
        public int? JerseyNumber { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        [StringLength(80)]
        public string EmailAddress { get; set; }
        
        [DisplayName("Street Address")]
        [StringLength(80)]
        public string StreetAddress { get; set; }
        
        public string City { get; set; }
        
        [DisplayName("State")]
        public int StateId { get; set; }

        public virtual State State { get; set; }
        
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }

    }
}