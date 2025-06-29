using CleanArch.StarterKit.Domain.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace CleanArch.StarterKit.Domain.Entities;
public sealed class User : IdentityUser<Guid>, IAuditable
{

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public User()
    {
        Id = Guid.NewGuid();
    }


    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid? DeletedBy { get; set; }
}
