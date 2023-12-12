using System.Text.RegularExpressions;

namespace BluBlu.Tenants.Domain.UsersEntity;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public User(Guid? id, string username, string firstName, string lastName, string email)
    {
        Id = id ?? Guid.NewGuid();
        Username = Sanitize(username, nameof(username));
        FirstName = Sanitize(firstName, nameof(firstName));
        LastName = Sanitize(lastName, nameof(lastName));
        Email = Sanitize(email, nameof(email));
    }

    private string Sanitize(string value, string variableName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{variableName} cannot be null or empty.");
        }

        value = value.Trim();

        if (!Regex.IsMatch(value, "^[a-zA-Z0-9_]+$"))
        {
            throw new ArgumentException($"{variableName} must consist of letters, numbers, and underscores only.");
        }

        return value;
    }
}