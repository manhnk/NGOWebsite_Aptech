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
        [Remote("CheckNameExist", "User", HttpMethod = "POST", ErrorMessage = "Username already exists. Please enter a different user name.", AdditionalFields = "ID")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 50 charactes !")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please type password!")]
        [Display(Name = "Password")]
        [Remote("CheckPassword", "User", HttpMethod = "POST", ErrorMessage = "Password is wrong !")]        
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 50 charactes !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "Please type new password !")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 50 charactes !")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm New Password")]
        [Required(ErrorMessage = "Please type confirm password !")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 50 charactes !")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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

        [Display(Name="Joined Team")]
        public int IsMemberOfTeam { get; set; }
        public int IsDeleted { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        
    }
}
