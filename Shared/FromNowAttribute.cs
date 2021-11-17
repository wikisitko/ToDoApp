using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Shared
{
    public class FromNowAttribute : ValidationAttribute
    {
        public FromNowAttribute() { }

        public string GetErrorMessage() => "Date must be past now";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = (DateTime)value;

            if (DateTime.Compare(date.Date, DateTime.Now.Date) < 0) return new ValidationResult(GetErrorMessage());
            else return ValidationResult.Success;
        }
    }
}
