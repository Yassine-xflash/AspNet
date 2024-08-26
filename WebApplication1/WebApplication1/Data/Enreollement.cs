using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class Enreollement
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? ClasseId { get; set; }

    public string? Grade { get; set; }

    public virtual Class? Classe { get; set; }

    public virtual Student? Student { get; set; }
}
