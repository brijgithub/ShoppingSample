using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSample.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

         [Required]
        [StringLength(20, ErrorMessage = "Must be between 10 and 20 characters", MinimumLength = 6)]
        public string UserName { get; set; }
         [Required]
        [StringLength(20, ErrorMessage = "Must be between 10 and 20 characters", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Password should have atleast One lower case ,upper case,number and special character")]
        public string Password { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Must be between 10 and 20 characters", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Password should have atleast One lower case ,upper case,number and special character")]
        [Compare("Password",ErrorMessage ="Confirm Password should match the password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPhone { get; set; }



    }
}
