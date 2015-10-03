using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
    public class ContactDetails
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please type Address!")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 100 charactes !")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please type Phone!")]
        [Display(Name = "Phone")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "Length must be between 9 and 15 charactes !")]
        [RegularExpression("^\\d{1,15}$", ErrorMessage = "Phone number is not valid !")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please type Email!")]
        [Display(Name = "Email")]
        [RegularExpression("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$", ErrorMessage = "Email address is not valid!")]        
        public string Email { get; set; }
    }
}
