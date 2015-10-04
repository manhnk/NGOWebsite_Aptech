using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please type user name!")]
        //[Remote("CheckNameExist", "Book", HttpMethod = "POST", ErrorMessage = "Book name already exists. Please enter a different user name.", AdditionalFields = "ID")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 50 charactes !")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please type password!")]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 50 charactes !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name="Gender")]
        [Required(ErrorMessage="Please choose gender!")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please type full name!")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Please type phone number!")]
        [Display(Name = "Phone number")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "Length must be between 9 and 15 charactes !")]        
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Please type Address!")]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Please type email!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$", ErrorMessage = "Email address is not valid!")]        
        public string Email { get; set; }


        public int IsMemberOfTeam { get; set; }
        public int IsDeleted { get; set; }

        public string Image { get; set; }
    }
}
