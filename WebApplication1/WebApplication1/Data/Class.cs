using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class Class
{
    public int Id { get; set; }

    public int? LectureId { get; set; }

    public int? Courseid { get; set; }

    public TimeOnly? Time { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Enreollement> Enreollements { get; set; } = new List<Enreollement>();

    public virtual Lecture? Lecture { get; set; }
}
