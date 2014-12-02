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

    public partial class user
    {
        [Display(Name = "Rank")]
        [Required(ErrorMessage = "Rank is required")]
        public string rankid;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^(?:\d[ -]*?){13,16}$", ErrorMessage = "Invalid format")]
        public string email;

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string firstname;

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string lastname;

        [Display(Name = "Passport Number")]
        [Required(ErrorMessage = "Passport number is required")]
        public string passport_number;

        [Display(Name = "CNC Number")]
        [Required(ErrorMessage = "CNC number is required")]
        public string cdc_number;

        [Display(Name = "Sign on Date")]
        [Required(ErrorMessage = "Sign on date is required")]
        public string signon_date;

        [Display(Name = "Sign off Date")]
        public string signoff_date;

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string user_name;

    }
}
