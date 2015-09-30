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
        [Required(ErrorMessage="Please type Subject!")]
        public string Subject { get; set; }
        public string TextTooltip{ get; set; }
        public string Contents { get; set; }
        public int IsDeleted { get; set; }
        public int Position { get; set; }

        public int ParentId { get; set; }
        public string ParentName { get; set; }
    }
}
