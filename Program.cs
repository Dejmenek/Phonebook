﻿using Phonebook.Controllers;
using Phonebook.Data;
using Phonebook.Data.Repositories;
using Phonebook.Enums;
using Phonebook.Helpers;
using Phonebook.Services;

internal class Program
{
    private static void Main()
    {
        var phonebookContext = new PhoneBookContext();
        bool exitMainMenu = false;

        var categoriesRepository = new CategoriesRepository(phonebookContext);
        var contactsRepository = new ContactsRepository(phonebookContext);

        var userInteractionService = new UserInteractionService();
        var sendEmailService = new SendEmailService(userInteractionService);
        var categoriesService = new CategoriesService(userInteractionService, categoriesRepository);
        var contactsService = new ContactsService(contactsRepository, categoriesRepository, userInteractionService, sendEmailService);

        var categoriesController = new CategoriesController(categoriesService);
        var contactsController = new ContactsController(contactsService);


        while (!exitMainMenu)
        {
            var userOption = userInteractionService.GetMenuOption();

            switch (userOption)
            {
                case MenuOptions.Exit:
                    exitMainMenu = true;
                    break;

                case MenuOptions.ManageContacts:
                    ContactsMenu(userInteractionService, contactsController);
                    break;

                case MenuOptions.ManageCategories:
                    CategoriesMenu(userInteractionService, categoriesController);
                    break;
            }
        }
    }
    private static void ContactsMenu(UserInteractionService userInteractionService, ContactsController contactsController)
    {
        bool exitManageContacts = false;
        while (!exitManageContacts)
        {
            var userManageContactsOption = userInteractionService.GetManageContactsOptions();

            switch (userManageContactsOption)
            {
                case ManageContactsOptions.Exit:
                    exitManageContacts = true;
                    break;

                case ManageContactsOptions.AddContact:
                    contactsController.AddContact();
                    userInteractionService.GetUserInputToContinue();
                    Console.Clear();
                    break;

                case ManageContactsOptions.UpdateContact:
                    contactsController.UpdateContact();
                    userInteractionService.GetUserInputToContinue();
                    Console.Clear();
                    break;

                case ManageContactsOptions.DeleteContact:
                    contactsController.DeleteContact();
                    userInteractionService.GetUserInputToContinue();
                    Console.Clear();
                    break;

                case ManageContactsOptions.ViewAllContacts:
                    var selectedSortingOptionColumn = userInteractionService.GetSortingOptionColumn();
                    var selectedSortingOptionOrder = userInteractionService.GetSortingOptionOrder();
                    var contacts = contactsController.GetAllContacts(selectedSortingOptionColumn, selectedSortingOptionOrder);
                    DataVisualizer.DisplayContacts(contacts);
                    userInteractionService.GetUserInputToContinue();
                    Console.Clear();
                    break;

                case ManageContactsOptions.ViewContactsByCategory:
                    var contactsByCategory = contactsController.GetContactsByCategory();
                    DataVisualizer.DisplayContacts(contactsByCategory);
                    userInteractionService.GetUserInputToContinue();
                    Console.Clear();
                    break;

                case ManageContactsOptions.SendEmail:
                    contactsController.SendEmail();
                    userInteractionService.GetUserInputToContinue();
                    Console.Clear();
                    break;
            }
        }
    }

    private static void CategoriesMenu(UserInteractionService userInteractionService, CategoriesController categoriesController)
    {
        bool exitCategoriesMenu = false;

        while (!exitCategoriesMenu)
        {
            var userManageCategoriesOption = userInteractionService.GetManageCategoriesOption();

            switch (userManageCategoriesOption)
            {
                case ManageCategoriesOptions.Exit:
                    exitCategoriesMenu = true;
                    break;

                case ManageCategoriesOptions.AddCategory:
                    categoriesController.AddCategory();
                    userInteractionService.GetUserInputToContinue();
                    Console.Clear();
                    break;

                case ManageCategoriesOptions.DeleteCategory:
                    categoriesController.DeleteCategory();
                    userInteractionService.GetUserInputToContinue();
                    Console.Clear();
                    break;

                case ManageCategoriesOptions.UpdateCategory:
                    categoriesController.UpdateCategory();
                    userInteractionService.GetUserInputToContinue();
                    Console.Clear();
                    break;

                case ManageCategoriesOptions.ViewCategories:
                    var categories = categoriesController.GetCategories();
                    DataVisualizer.DisplayCategories(categories);
                    userInteractionService.GetUserInputToContinue();
                    Console.Clear();
                    break;
            }
        }
    }
}