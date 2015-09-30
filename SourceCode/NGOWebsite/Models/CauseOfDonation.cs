using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
   public class CauseOfDonation
    {
       [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please type Description!")]
        //[Remote("CheckNameExist", "Book", HttpMethod = "POST", ErrorMessage = "Book name already exists. Please enter a different user name.", AdditionalFields = "ID")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 100 charactes !")]
        [Display(Name = "Description")]
        public string Description{ get; set; }
        public int IsDeleted { get; set; }

        public int IsFieldOfPrograms { get; set; }
    }
}
