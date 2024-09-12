using Phonebook.Models;
using Phonebook.Services;

namespace Phonebook.Controllers;

public class ContactsController
{
    private readonly ContactsService _contactsService;

    public ContactsController(ContactsService contactsService)
    {
        _contactsService = contactsService;
    }

    public void AddContact() => _contactsService.AddContact();

    public void UpdateContact() => _contactsService.UpdateContact();

    public void DeleteContact() => _contactsService.DeleteContact();

    public List<ContactDTO> GetContactsByCategory() => _contactsService.GetContactsByCategory();

    public List<ContactDTO> GetAllContacts() => _contactsService.GetAllContacts();

    public void SendEmail() => _contactsService.SendEmail();
}
