using Phonebook.Models;
using Phonebook.Services;

namespace Phonebook.Controllers;

public class CategoriesController
{
    private readonly CategoriesService _categoriesService;

    public CategoriesController(CategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }

    public void AddCategory() => _categoriesService.AddCategory();

    public void UpdateCategory() => _categoriesService.UpdateCategory();

    public void DeleteCategory() => _categoriesService.DeleteCategory();

    public List<CategoryDTO> GetCategories() => _categoriesService.GetCategories();
}
