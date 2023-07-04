using System;
using System.Collections.Generic;

namespace NBA_Basketball.Models;

public partial class Admin
{
    public string Jobnumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string RoleId { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
