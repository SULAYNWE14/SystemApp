using System;
using System.Collections.Generic;

namespace SystemApp.Models;

public partial class AccountUser
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? MailAddress { get; set; }

    public string? Phone { get; set; }

    public DateTime CreateDate { get; set; }
}
