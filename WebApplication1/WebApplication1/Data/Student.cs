using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LasrtName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public virtual ICollection<Enreollement> Enreollements { get; set; } = new List<Enreollement>();
}
