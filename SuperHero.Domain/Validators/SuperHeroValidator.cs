using CRUD.DOmain.Entities;
using FluentValidation;

namespace CRUD.DOmain.Validators;

public class SuperHeroValidator : AbstractValidator<SuperHero>
{
    public SuperHeroValidator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage("Entity can't be empty")
            .NotNull().WithMessage("Entity can't be null");
            
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .NotNull().WithMessage("Name can't be null")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters");
        
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName is required")
            .NotNull().WithMessage("FirstName can't be null")
            .MaximumLength(50).WithMessage("FirstName must not exceed 50 characters");
        
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("LastName is required")
            .NotNull().WithMessage("LastName can't be null")
            .MaximumLength(50).WithMessage("LastName must not exceed 50 characters");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .NotNull().WithMessage("Description can't be null")
            .MaximumLength(50).WithMessage("Description must not exceed 50 characters");


    }
}