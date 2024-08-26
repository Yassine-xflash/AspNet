using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class Lecture
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LasrtName { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
