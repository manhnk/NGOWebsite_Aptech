using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
   public class Menu
    {
        [Key]   
        public int Id { get; set; }

        [Required(ErrorMessage = "Please type Subject!")]
        [Remote("CheckSubjectExisted", "Menus", HttpMethod = "POST", ErrorMessage = "Subject is existed. Please enter a different subject.", AdditionalFields = "Id")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

       [Display(Name="Text Tooltip")]
        public string TextTooltip { get; set; }

        [Display(Name = "Position")]
        [RegularExpression("^[1-9][0-9]?$", ErrorMessage = "Position must be a number greater than 0 !")]
        public Nullable<int> Position { get; set; }
        public int IsDeleted{ get; set; }

        [Display(Name = "Links")]
        public string Links { get; set; }
    }
}
