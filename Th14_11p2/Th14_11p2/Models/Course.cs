using System;
using System.Collections.Generic;

namespace Th14_11p2.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string Title { get; set; } = null!;

    public int Credits { get; set; }

    public virtual ICollection<Enrollment>? Enrollments { get; set; } = new List<Enrollment>();
}
