#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;


  public class Chef 
  {
    [Key]
    public int ChefId { get; set; }

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    public string FName { get; set; }

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters")]
    public string LName { get; set; }

    [Display(Name = "Date of Birth")]
    [Required(ErrorMessage = "is required")]
    [DateValidations]
    public DateTime DOB { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<Dish> Dishes { get; set; } = new List<Dish>();
    
    
    
    public int Age()
    {
      var today = DateTime.Today;
      var age = today.Year - this.DOB.Year;
      
      return age;
    }
  }

