﻿using System;
using System.Collections.Generic;

namespace BussiessObjects.Entities;

public partial class AccountMember
{
    public string MemberId { get; set; } = null!;

    public string MemberPassword { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public int MemberRole { get; set; }
}
