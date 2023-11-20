using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.DTO
{
    public class RequestDTO
    {



        public int req_id { get; set; }

        [Required(ErrorMessage = "*Provide Food type")]
        public string food_type { get; set; }



        [Required(ErrorMessage = "*Provide you email")]

        /*        [RegularExpression("^\\@gmail.com$", ErrorMessage = "email format no correct")]
        */
        public string Email { get; set; }


        public string Phone { get; set; }

        [Required(ErrorMessage = "*Provide Quantity")]

        public string quantity { get; set; }

        [Required(ErrorMessage = "*Provide maximum prevention time")]
        public string max_preservation_time { get; set; }

        [Required(ErrorMessage = "*Provide location")]
        public string location { get; set; }


        public string status { get; set; }
        public Nullable<int> rest_id { get; set; }
        public Nullable<int> assigned_employee_id { get; set; }

        [Required(ErrorMessage = "*Provide details")]
        public string details_food { get; set; }

        public Nullable<System.DateTime> date_of_order { get; set; }
    }
}