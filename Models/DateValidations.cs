using System.ComponentModel.DataAnnotations;

public class DateValidations : ValidationAttribute
{
  protected override ValidationResult IsValid(object value,
  ValidationContext context)
  {
    DateTime _dateJoin = Convert.ToDateTime(value);
    if (_dateJoin < DateTime.Now)
    {
      return ValidationResult.Success;
    }
    else 
    {
      return new ValidationResult("must be 18 years or older");
    }
  }
}