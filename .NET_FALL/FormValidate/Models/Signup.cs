using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Formvalid.Models  
{
    public class Signup
    {

        [Required(ErrorMessage = "*Name is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "*Name must be between 4 and 50 characters")]
        [RegularExpression(@"^[A-Za-z\s\.\-]+$", ErrorMessage = "*Name can only contain letters, spaces, '.', and '-'")]
        public string name { get; set; }


        [Required(ErrorMessage = "*User ID is required")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "*User ID must be between 4 and 12 characters")]
        [RegularExpression(@"^[A-Za-z0-9_-]+$", ErrorMessage = "*User ID can only contain letters, numbers, '-', and '_'")]


        public string userid { get; set; }



        [Required(ErrorMessage = "*Password is required")]
        [StringLength(60, MinimumLength = 8, ErrorMessage = "*Password must be minimum 8 characters")]

        [RegularExpression(@"^(?=(?:[^A-Z]*[A-Z]){1})(?=(?:[^a-z]*[a-z]){2})[A-Za-z]{4}[0-9!@#$%^&*()-_+=]{4}.+$", ErrorMessage = "*It should start with atleast 4 alphabets with at least 1 Upper case and 2 lower case and the other 4 must be a combination of special characters and numbers")]
        public string password { get; set; }



        [Required(ErrorMessage = "*ID is required")]
        [RegularExpression(@"^\d{2}-\d{5}-\d$", ErrorMessage = "ID must be in the format 'xx-xxxxx-x' and contain only numbers.")]
        public string id { get; set; }

        [Required(ErrorMessage = "*Email is required")]
        [RegularExpression(@"^\d{2}-\d{5}-\d@student.aiub.edu$", ErrorMessage = "Email must be in the format 'xx-xxxxx-x@student.aiub.edu'")]
        public string email { get; set; }

        [Required(ErrorMessage = "*Date of Birth is required")]


        [Date(ErrorMessage = "Your Age is < 18")]
        public string dob { get; set; }

    }
}