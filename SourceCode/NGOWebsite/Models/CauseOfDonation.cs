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

        [Required(ErrorMessage = "Please type cause name!")]
        [Remote("CheckExist", "CauseOfDonation", HttpMethod = "POST", ErrorMessage = "Cause already exists. Please enter a different cause.", AdditionalFields = "Id")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 100 charactes !")]
        [Display(Name = "Cause Of Donation")]
        public string Description{ get; set; }

        public int IsDeleted { get; set; }

       [Display(Name="Is Field Of Program")]
        public int IsFieldOfPrograms { get; set; }
    }
}
