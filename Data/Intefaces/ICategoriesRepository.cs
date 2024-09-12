using Phonebook.Models;

namespace Phonebook.Data.Intefaces;

public interface ICategoriesRepository
{
    void AddCategory(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(int id);
    bool CategoryExists(string name);
    List<Category> GetCategories();
}
