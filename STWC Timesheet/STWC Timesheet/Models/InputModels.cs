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
    public class InputModels
    {
        public user UserModel { get; set; }
        public user_entry UserEntryModel { get; set; }
        public ship ShipModel { get; set; }
    }
}

namespace STWC_Timesheet
{
    [MetadataType(typeof(UserHelper))]
    public partial class user
    {
        
    }

    public class UserHelper
    {
        [Display(Name = "Rank")]
        [Required(ErrorMessage = "Rank is required")]
        public string rank_id;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"(\w[-._\w]*\w@\w[-._\w]*\w\.\w[\w]*\w)", ErrorMessage = "Invalid email format")]
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

        [Display(Name = "CDC Number")]
        [Required(ErrorMessage = "CDC number is required")]
        public string cdc_number;

        [Display(Name = "Sign on Date")]
        [Required(ErrorMessage = "Sign on date is required")]
        public string signon_date;

        [Display(Name = "Sign off Date")]
        public string signoff_date;

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string user_name;

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string password;
    }

    [MetadataType(typeof(UserEntryHelper))]
    public partial class user_entry
    {

    }

    public class UserEntryHelper
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Select crew member")]
        public string user_id;

        [Display(Name = "Worked hours")]
        public string total_hours;

        [Display(Name = "Comments")]
        public string comments;

        [Display(Name = "Service Terms")]
        public string nc_remarks;
    }

    [MetadataType(typeof(ShipHelper))]
    public partial class ship
    {
        public string comp_name
        {
            get { return System.Environment.MachineName; }
            set { comp_name = System.Environment.MachineName; }
        }
    }

    public class ShipHelper
    {
        [Display(Name = "Ship Name")]
        [Required(ErrorMessage = "Ship name is required")]
        public string ship_name;

        [Display(Name = "IMO")]
        [Required(ErrorMessage = "IMO is required")]
        public string ship_IMO;

        [Display(Name = "Flag")]
        [Required(ErrorMessage = "Flag is required")]
        public string flag;

        [Display(Name = "Serial No.")]
        public string serial_number;

        [Display(Name = "licence key")]
        public string licence_key;

        [Display(Name = "Computer Name")]
        public string comp_name;
    }

}
