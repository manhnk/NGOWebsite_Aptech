using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Donation
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please type Full name!")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Length must be between 6 and 50 charactes !")]
        public string FullNameDonator { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please choose Gender!")]
        public string GenderDonator { get; set; }

        [Required(ErrorMessage = "Please type Email!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailDonator { get; set; }

        [Display(Name="Date Of Donation")]
        [DataType(DataType.Date)]
        public DateTime DateOfDonation { get; set; }

        [Display(Name="Amount")]
        [Required(ErrorMessage="Please type Amount!")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Display(Name = "Credit Type")]
        [Required(ErrorMessage = "Please choose Credit Type!")]
        public string CreditType { get; set; }

        [Display(Name = "Card Number")]
        [Required(ErrorMessage = "Please type Card Number!")]
        [DataType(DataType.CreditCard)]
        public string CardNumber { get; set; }

        public int CauseId { get; set; }
        public int ProgramId { get; set; }

        [Display(Name = "Cause Of Donation")]
        public string CauseOfDonation { get; set; }

        [Display(Name = "Program")]
        public string Program { get; set; }

        public int IsDeleted { get; set; }
    }
}
