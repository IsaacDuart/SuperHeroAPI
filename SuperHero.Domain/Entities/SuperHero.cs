using System.Runtime.InteropServices.JavaScript;
using CRUD.Core.Exceptions;
using CRUD.DOmain.Validators;

namespace CRUD.DOmain.Entities;

public class SuperHero : Base
{
    public string Name { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Description { get; private set; }


    protected SuperHero()
    {
        
    }
    
    public SuperHero(string name, string firstName, string lastName, string description)
    {
        Name = name;
        FirstName = firstName;
        LastName = lastName;
        Description = description;
        _errors = new List<string>();

        Validate();
    }
    
    

    public sealed override bool Validate()
    {
        var validator = new SuperHeroValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            {
                _errors.Add(error.ErrorMessage);
                throw new DomainException("Some errors were encountered", _errors);
            }
        }

        return true;
    }
}