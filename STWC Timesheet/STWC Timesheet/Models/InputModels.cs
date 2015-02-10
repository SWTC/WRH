using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.NetworkInformation;
using System.Management;

namespace STWC_Timesheet.Models
{
    public class InputModels
    {
        public user UserModel { get; set; }
        public user_entry UserEntryModel { get; set; }
        public ship ShipModel { get; set; }
    }

    public class Registration
    {
        public static string GetMacAddress()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                macAddresses = nic.GetPhysicalAddress().ToString();
                break;
            }
            return macAddresses;
        }

        public static string GetCpuId()
        {
            string cpuid = null;
            try
            {
                ManagementObjectSearcher mo = new ManagementObjectSearcher("select * from Win32_Processor");
                foreach (var item in mo.Get())
                {
                    cpuid = item["ProcessorId"].ToString();
                }
                return cpuid;
            }
            catch
            {
                return null;
            }
        }

        public static int GenerateKey()
        {
            string mac = GetMacAddress();
            int sum = 0;
            int index = 1;
            foreach (char c in mac)
            {
                if (char.IsDigit(c))
                    sum = sum + Convert.ToInt32(c) * (index * 2);
                else
                {
                    switch (c)
                    {
                        case 'A':
                            sum += sum + 10 * (index * 2);
                            break;
                        case 'B':
                            sum += sum + 11 * (index * 2);
                            break;
                        case 'C':
                            sum += sum + 12 * (index * 2);
                            break;
                        case 'D':
                            sum += sum + 13 * (index * 2);
                            break;
                        case 'E':
                            sum += sum + 14 * (index * 2);
                            break;
                        case 'F':
                            sum += sum + 15 * (index * 2);
                            break;
                    }
                }
                index++;
            }
            return sum;
        }
        public static bool ValidateRegistration(string registrationKey)
        {
            int serialKey = GenerateKey();
            serialKey = serialKey * serialKey + 53 / serialKey + 113 * (serialKey / 4);
            return serialKey.ToString() == registrationKey;
        }
    }
}

namespace STWC_Timesheet
{
    [MetadataType(typeof(UserHelper))]
    public partial class user
    {
        [Display(Name = "Confirm new password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
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

        [Display(Name = "Computer Name")]
        public string comp_name;
    }

    public partial class Key
    {
        public static bool ValidateKey(string serialKey, string activationKey)
        {
            return false;
        }
    }
}
