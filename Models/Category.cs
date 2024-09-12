using Microsoft.EntityFrameworkCore;

namespace Phonebook.Models;

[Index(nameof(Name), IsUnique = true)]
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Contact? Contact { get; set; }
}

public class CategoryDTO
{
    public string Name { get; set; } = null!;
}
