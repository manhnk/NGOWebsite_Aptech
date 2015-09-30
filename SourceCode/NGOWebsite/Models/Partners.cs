using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
    public class Partners
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please type name!")]
        //[Remote("CheckNameExist", "Book", HttpMethod = "POST", ErrorMessage = "Book name already exists. Please enter a different user name.", AdditionalFields = "ID")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 100 charactes !")]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please type phone number!")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "Length must be between 9 and 15 charactes !")]        
        public string Phone { get; set; }


        [Required(ErrorMessage = "Please type Address!")]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Please type email!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name="Logo")]
        public string Logo { get; set; }

        public string Profile { get; set; }

        public int IsDeleted { get; set; }

    }
}
