using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please type user name!")]
        [Remote("CheckAccExisted", "Admin", HttpMethod = "POST", ErrorMessage = "User name is existed. Please enter a different user name.", AdditionalFields = "Id")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 50 charactes !")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Please type password!")]
        [Remote("CheckPassword", "Admin", HttpMethod = "POST", ErrorMessage = "Password is wrong !")]        
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 50 charactes !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please type full name!")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please choose gender!")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Please type phone number!")]
        [Display(Name = "Phone")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "Length must be between 9 and 15 charactes !")]        
        [RegularExpression("^\\d{1,15}$",ErrorMessage="Phone number is not valid !")]    
        public string Phone { get; set; }


        [Required(ErrorMessage = "Please type Address!")]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Please type email!")]
        [Display(Name = "Email")]
        [RegularExpression("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$", ErrorMessage = "Email address is not valid!")]        
        public string Email { get; set; }
        
        [Display(Name="Is Actived")]
        public bool IsActived { get; set; }

        public bool IsSuperAdmin { get; set; }

        [Display(Name="New Password")]
        [Required(ErrorMessage="Please type new password !")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 50 charactes !")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm New Password")]
        [Required(ErrorMessage = "Please type confirm password !")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 50 charactes !")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
