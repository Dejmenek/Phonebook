using Phonebook.Models;

namespace Phonebook.Data.Intefaces;

public interface IContactsRepository
{
    void AddContact(Contact contact);
    void DeleteContact(int id);
    void UpdateContact(Contact contact);
    List<Contact> GetAllContacts();
    List<Contact> GetContactsByCategory(int categoryId);
    bool PhoneNumberExists(string phoneNumber);

}
