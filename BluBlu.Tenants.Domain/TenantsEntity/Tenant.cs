using System.Text.RegularExpressions;

namespace BluBlu.Tenants.Domain.TenantsEntity;

public class Tenant
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Schema { get; set; }

    public Tenant(Guid? id, string name, string schema)
    {
        Id = id ?? Guid.NewGuid();
        Name = SanitizeName(name);
        Schema = SanitizeSchema(schema);
    }

    private string SanitizeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or empty.");

        return name.Trim();
    }

    private string SanitizeSchema(string schema)
    {
        if (string.IsNullOrWhiteSpace(schema))
            throw new ArgumentException("Schema cannot be null or empty.");

        if (!Regex.IsMatch(schema, "^[a-zA-Z0-9_]+$"))
            throw new ArgumentException("Schema must consist of letters, numbers, and underscores only.");

        return schema.Trim();
    }
}
