using System.ComponentModel.DataAnnotations;

namespace CRUD.Api.ViewModels;

public class UpdateViewModel
{
    [Required(ErrorMessage = "Super Hero Id is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Super Hero Id must be at least 1")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Super Hero Name is required")]
    [MinLength(3, ErrorMessage = "Super Hero Name must be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Super Hero Name must be less than 50 characters")]
    public string Name { get;  set; }
    
    [Required(ErrorMessage = "Super Hero First Name is required")]
    [MinLength(3, ErrorMessage = "Super Hero First Name must be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Super Hero  First Name must be less than 50 characters")]
    public string FirstName { get;  set; }
    
    [Required(ErrorMessage = "Super Hero Last Name is required")]
    [MinLength(3, ErrorMessage = "Super Hero Last Name must be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Super Hero Last Name must be less than 50 characters")]
    public string LastName { get;  set; }
    
    [Required(ErrorMessage = "Super Hero Description is required")]
    [MaxLength(50, ErrorMessage = "Super Hero Description must be less than 50 characters")]
    public string Description { get;  set; }
}