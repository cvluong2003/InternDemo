using System;
using System.Collections.Generic;

namespace Data.EntityModels;

public partial class Lop
{
    public string Malop { get; set; } = null!;

    public string? Tenlop { get; set; }

    public int? Siso { get; set; }

    public virtual ICollection<Giaovien> Giaoviens { get; set; } = new List<Giaovien>();

    public virtual ICollection<Sinhvien> Sinhviens { get; set; } = new List<Sinhvien>();
}
