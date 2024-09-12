using Phonebook.Models;

namespace Phonebook.Helpers;
public static class Mapper
{
    public static ContactDTO ToContactDTO(Contact contact) =>
        new ContactDTO
        {
            Name = contact.Name,
            Email = contact.Email ?? "",
            PhoneNumber = contact.PhoneNumber,
            CategoryName = contact.Category?.Name ?? ""
        };

    public static CategoryDTO ToCategoryDTO(Category category) =>
        new CategoryDTO { Name = category.Name };

    public static List<ContactDTO> ToContactDTOs(List<Contact> contacts)
    {
        List<ContactDTO> contactDTOs = new List<ContactDTO>();

        foreach (var contact in contacts)
        {
            contactDTOs.Add(ToContactDTO(contact));
        }

        return contactDTOs;
    }

    public static List<CategoryDTO> ToCategoryDTOs(List<Category> categories)
    {
        List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();

        foreach (var category in categories)
        {
            categoryDTOs.Add(ToCategoryDTO(category));
        }

        return categoryDTOs;
    }
}
