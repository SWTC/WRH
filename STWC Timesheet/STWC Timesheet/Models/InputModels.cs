using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace STWC_Timesheet.Models
{
    public class InputModel
    {
        [Required]
        [Display(Name = "Crew Member")]
        public string CrewMember { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string Position { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }

        [Display(Name = "Service Terms")]
        public string ServiceTerms { get; set; }

        [Display(Name = "Non Conformities")]
        public string NonConformities { get; set; }
    }

    
}
