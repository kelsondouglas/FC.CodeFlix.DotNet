
using FC.CodeFlix.Catalog.Domain.Exceptions;

namespace FC.CodeFlix.Catalog.Domain.Entity;

//Classe Public
public class Category
{
    //Declaração de atributos da classe
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    //Declarando construtor da Classe
    public Category(string name, string description, bool isActive = true)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        IsActive = isActive;
        CreatedAt = DateTime.Now;

        Validate();
    }

    public void Validate() { 
        if(String.IsNullOrWhiteSpace(Name))
            throw new EntityValidationException($"{nameof(Name)} should not be empty or null");

        if (Name.Length < 3)
            throw new EntityValidationException($"{nameof(Name)} should be at least 3 characters long");
 
        if (Name.Length > 255)
            throw new EntityValidationException($"{nameof(Name)} should be less or equal to 255 characters long");

        if (Description == null)
            throw new EntityValidationException($"{nameof(Description)} should not be empty or null");

        if (Description.Length > 10000)
            throw new EntityValidationException($"{nameof(Description)} should be less or equal to 10_000 characters");

    }
}
