using FirstWebAppRwad.Models;
using FirstWebAppRwad.Models.Context;
using System.ComponentModel.DataAnnotations;

namespace FirstWebAppRwad.CustomValidation
{
    public class UniqueName: ValidationAttribute
    {
        //public UniqueName()
        //{
        //    ErrorMessage = "this name is alreay found";
        //}
        //public override bool IsValid(object? value)
        //{
        //    ApplicationContext context = new ApplicationContext();
        //    string name = value.ToString();
        //  var  emp= context.Employees.Where(x => x.Name == name);
        //    if(emp is null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //       // return base.IsValid(value);
        //}

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //Employee empParam = (Employee)validationContext.ObjectInstance;
            ApplicationContext context = new ApplicationContext();
            string name = value.ToString();
            var emp = context.Employees.Where(x => x.Name == name);
            if(emp is null)

            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($" employee name {name} is already found at db");
            }


               // return base.IsValid(value, validationContext);
        }
    }
}
