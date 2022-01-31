using Microsoft.AspNetCore.Identity;

namespace BluBlu.Auth.Domain.User;

public class BluBluIdentity : IdentityUser
{
    /// <summary>
    /// Gets or sets the display name for this user.
    /// </summary>
    [ProtectedPersonalData]
    public virtual string DisplayName { get; set; } = default!;
}