using System;
using System.Collections.Generic;

namespace StudentWebApi.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? FatherName { get; set; }

    public string? Address { get; set; }

    public int? Age { get; set; }

    public int? Class { get; set; }
}
