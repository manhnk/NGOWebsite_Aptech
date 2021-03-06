﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
   public class ImageGallery
    {
       [Key]
        public int Id { get; set; }

       public Nullable<int> ProgramId { get; set; }

        [Display(Name="Program")]
        public string ProgramName { get; set; }

        [Display(Name="Image Path")]
        [Required(ErrorMessage="Please select image!")]
        public string ImagePath { get; set; }

        [Display(Name="Description")]
        public string Description { get; set; }

       [Display(Name="Is Topic Imgae")]
        public Nullable<int> IsTopicImage { get; set; }
        public Nullable<int> IsSildeImage { get; set; }

        [RegularExpression("^[1-9][0-9]?$", ErrorMessage = "Position must be a number greater than 0 !")]
        public Nullable<int> PositionInSilde { get; set; }
        public int IsDeleted { get; set; }

        public int TotalImage { get; set; }
    }
}
