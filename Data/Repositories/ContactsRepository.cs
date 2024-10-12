using Microsoft.EntityFrameworkCore;
using Phonebook.Data.Intefaces;
using Phonebook.Enums;
using Phonebook.Models;
using System.Linq.Expressions;

namespace Phonebook.Data.Repositories;
public class ContactsRepository : IContactsRepository
{
    private readonly PhoneBookContext _context;

    public ContactsRepository(PhoneBookContext context)
    {
        _context = context;
    }

    public void AddContact(Contact contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
    }

    public void DeleteContact(int id)
    {
        var contact = _context.Contacts.Find(id);
        _context.Contacts.Remove(contact);
        _context.SaveChanges();
    }

    public List<Contact> GetAllContacts(
        SortingOptionsColumn sortingOptionColumn = SortingOptionsColumn.Name,
        SortingOptionsOrder sortingOptionOrder = SortingOptionsOrder.Ascending
    )
    {
        IQueryable<Contact> contactsQuery = _context.Contacts.Include(c => c.Category);

        Expression<Func<Contact, object>> keySelector = sortingOptionColumn switch
        {
            SortingOptionsColumn.Name => contact => contact.Name,
            SortingOptionsColumn.Email => contact => contact.Email ?? "",
            SortingOptionsColumn.CategoryName => contact => contact.Category != null ? contact.Category.Name : "",
            _ => contact => contact.Id,
        };

        if (sortingOptionOrder == SortingOptionsOrder.Descending)
        {
            contactsQuery = contactsQuery.OrderByDescending(keySelector);
        }
        else
        {
            contactsQuery = _context.Contacts.OrderBy(keySelector);
        }

        var contacts = contactsQuery.ToList();

        return contacts;
    }

    public List<Contact> GetContactsByCategory(int categoryId) =>
        _context.Contacts.Include(c => c.Category).Where(c => c.CategoryId == categoryId).ToList();

    public void UpdateContact(Contact contact)
    {
        _context.Contacts.Update(contact);
        _context.SaveChanges();
    }

    public bool PhoneNumberExists(string phoneNumber) => _context.Contacts.Any(c => c.PhoneNumber == phoneNumber);
}
