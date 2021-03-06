﻿using System;
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

        public Nullable<int> ProgramId { get; set; }
        public string ProgramName { get; set; }

        [Required(ErrorMessage = "Please type Full name!")]
        [Display(Name = "Full Name")]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "Please type email!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$", ErrorMessage = "Email address is not valid!")]        
        public string SenderEmail { get; set; }

        [Required(ErrorMessage = "Please type content!")]
        [Display(Name = "Message")]
        public string Messages { get; set; }
        public int Status { get; set; }
        public int IsDeleted { get; set; }

        public Nullable<int> ReplierId { get; set; }

        public string Replier { get; set; }

        [Display(Name="Total Message")]
        public int TotalMessage { get; set; }
        [Display(Name = "Total New Message")]
        public int TotalNewMessage { get; set; }
        [Display(Name = "Total Read Message")]
        public int TotalReadMessage { get; set; }
        [Display(Name = "Total Replied Message")]
        public int TotalRepliedMessage { get; set; }

        [Required(ErrorMessage = "Please type content!")]
        [Display(Name = "Content")]
        public string MessageReply { get; set; }
    }
}
