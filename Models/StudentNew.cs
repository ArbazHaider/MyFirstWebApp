using System;
using System.Collections.Generic;

namespace MyFirstWebApp.Models;

public partial class StudentNew
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Semester { get; set; }

    public int? Age { get; set; }

    public string? Contact { get; set; }
}
