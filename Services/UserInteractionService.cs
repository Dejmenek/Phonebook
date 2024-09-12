using Phonebook.Enums;
using Phonebook.Models;
using Spectre.Console;

namespace Phonebook.Services;

public class UserInteractionService
{
    public string GetContactName() =>
        AnsiConsole.Prompt(
            new TextPrompt<string>("Enter contact's name")
                .ValidationErrorMessage("Your input must not be empty!")
                .Validate(Validation.IsValidString)
        );

    public string GetCategoryName() =>
        AnsiConsole.Prompt(
            new TextPrompt<string>("Enter category's name")
                .ValidationErrorMessage("Your input must not be empty")
                .Validate(Validation.IsValidString)
        );

    public Category GetCategory(List<Category> categories) =>
        AnsiConsole.Prompt(
            new SelectionPrompt<Category>()
                .Title("Select contact's category")
                .UseConverter(category => $"{category.Name}")
                .AddChoices(categories)
        );

    public void GetUserInputToContinue()
    {
        AnsiConsole.MarkupLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public string GetPhoneNumber() =>
        AnsiConsole.Prompt(
            new TextPrompt<string>("Enter a phone number with country code, including area code (e.g., +1 (212) 555 1212 for USA, +44 (20) 7946 0123 for UK): ")
                .Validate(Validation.IsValidPhoneNumber)
        );

    public string GetEmail() =>
        AnsiConsole.Prompt(
            new TextPrompt<string>("Enter email for example test@gmail.com")
                .ValidationErrorMessage("This is not a valid email format!")
                .Validate(Validation.IsValidEmail)
        );

    public string GetEmailBody() =>
        AnsiConsole.Prompt(
            new TextPrompt<string>("Enter details in the message body")
        );

    public string GetEmailSubject() =>
        AnsiConsole.Prompt(
            new TextPrompt<string>("Enter the subject line for your email")
        );

    public string GetUsername() =>
        AnsiConsole.Prompt(
            new TextPrompt<string>("Enter username")
                .ValidationErrorMessage("Your input must not be empty!")
                .Validate(Validation.IsValidString)
        );

    public string GetPassword() =>
        AnsiConsole.Prompt(
            new TextPrompt<string>("Enter password")
                .ValidationErrorMessage("Your input must not be empty!")
                .Validate(Validation.IsValidString)
        );

    public bool GetConfirmation(string title) => AnsiConsole.Confirm(title);

    public Contact GetContact(List<Contact> contacts) =>
        AnsiConsole.Prompt(
            new SelectionPrompt<Contact>()
                .Title("Select your contact")
                .UseConverter(contact => $"{contact.Name} {contact.PhoneNumber}")
                .AddChoices(contacts)
        );

    public MenuOptions GetMenuOption() =>
        AnsiConsole.Prompt(
            new SelectionPrompt<MenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(Enum.GetValues<MenuOptions>())
        );

    public ManageCategoriesOptions GetManageCategoriesOption() =>
        AnsiConsole.Prompt(
            new SelectionPrompt<ManageCategoriesOptions>()
                .Title("What would you like to do with contact's categories?")
                .AddChoices(Enum.GetValues<ManageCategoriesOptions>())
        );

    public ManageContactsOptions GetManageContactsOptions() =>
        AnsiConsole.Prompt(
            new SelectionPrompt<ManageContactsOptions>()
                .Title("What would you like to do with contacts?")
                .AddChoices(Enum.GetValues<ManageContactsOptions>())
        );
}
