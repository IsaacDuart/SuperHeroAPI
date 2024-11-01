namespace CRUD.DOmain.Entities;

public abstract class Base
{
    public long Id { get; private set; }

    internal List<string> _errors;
    public IReadOnlyList<string> Errors => _errors;
    
    public abstract bool Validate();
}