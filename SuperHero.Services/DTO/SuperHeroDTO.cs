namespace CRUD.Services.DTO;

public class SuperHeroDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }

    public SuperHeroDTO()
    {}

    public SuperHeroDTO( string name, string firstName, string lastName, string description)
    {
        Name = name;
        FirstName = firstName;
        LastName = lastName;
        Description = description;
    }
}