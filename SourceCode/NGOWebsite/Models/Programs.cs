using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
    public class Programs
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please type name!")]
        [Remote("CheckNameExisted", "ProgramsAD", HttpMethod = "POST", ErrorMessage = "Program name is existed. Please enter a different name.", AdditionalFields = "Id")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 100 charactes !")]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name="Content")]
        [Required(ErrorMessage="Please type Content")]
        public string Contents { get; set; }

        public int Status { get; set; }

        [Required(ErrorMessage = "Please select field !")]        
        public int CauseId { get; set; }

        [Display(Name="Field")]
        public string Cause { get; set; }

        public int IsDeleted { get; set; }
    }
}
