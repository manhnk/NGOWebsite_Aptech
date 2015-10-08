using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
    public class Informations
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Subject")]
        [Remote("CheckSubjectExisted","Informations",HttpMethod="POST",ErrorMessage="Subject is existed ! Please type again !",AdditionalFields="Id")]
        [Required(ErrorMessage="Please type Subject!")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 50 charactes !")]
        public string Subject { get; set; }

        [Display(Name="Text Tooltip")]
        public string TextTooltip{ get; set; }

        [Display(Name = "Content")]
        public string Contents { get; set; }
        public int IsDeleted { get; set; }

        [Display(Name = "Position")]
        [RegularExpression("^[1-9][0-9]?$",ErrorMessage="Position must be a number greater than 0 !")]
        public Nullable<int> Position { get; set; }

        public Nullable<int> ParentId { get; set; }

        [Display(Name="Parent")]
        public string ParentName { get; set; }

        [Display(Name="Links")]
        public string Links { get; set; }
    }
}
