﻿using Phonebook.Data.Intefaces;
using Phonebook.Models;

namespace Phonebook.Data.Repositories;
public class CategoriesRepository : ICategoriesRepository
{
    private readonly PhoneBookContext _context;
    public CategoriesRepository(PhoneBookContext context)
    {
        _context = context;
    }

    public void AddCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
    }

    public bool CategoryExists(string name) => _context.Categories.Any(cat => cat.Name == name);

    public List<Category> GetCategories() => _context.Categories.ToList();
}
