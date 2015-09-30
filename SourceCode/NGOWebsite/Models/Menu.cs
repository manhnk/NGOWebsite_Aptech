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
        //[Remote("CheckNameExist", "Book", HttpMethod = "POST", ErrorMessage = "Book name already exists. Please enter a different user name.", AdditionalFields = "ID")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        public string TextTooltip { get; set; }
        public int Position { get; set; }
        public int IsDeleted{ get; set; }
    }
}
