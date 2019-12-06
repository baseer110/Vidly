using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if(customer.DateOfBirth == null)
            {
                return new ValidationResult("Birthday is required");
            }

            var age = DateTime.Now.Year - customer.DateOfBirth.Value.Year;

            if(age < 18)
            {
                return new ValidationResult("Customer should be at least 18 years old to go on a membership.");
            } else
            {
                return ValidationResult.Success;
            }

        }
    }
}