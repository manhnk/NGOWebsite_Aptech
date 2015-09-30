using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public int ProgramId { get; set; }
        public string ProgramName { get; set; }

        [Required(ErrorMessage = "Please type Full name!")]
        [Display(Name = "Full Name")]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "Please type email!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string SenderEmail { get; set; }

        [Required(ErrorMessage = "Please type content!")]
        [Display(Name = "Content")]
        public string Messages { get; set; }
        public int Status { get; set; }
        public int IsDeleted { get; set; }

        public int ReplierId { get; set; }

        public string Replier { get; set; }
    }
}
