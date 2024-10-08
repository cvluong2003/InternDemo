using System;
using System.Collections.Generic;

namespace Data.EntityModels;

public partial class Sinhvien
{
    public string Masv { get; set; } = null!;

    public string? Tensv { get; set; }

    public DateOnly? Namsinh { get; set; }

    public string? Diachi { get; set; }

    public string? Malop { get; set; }

    public virtual ICollection<Ketqua> Ketquas { get; set; } = new List<Ketqua>();

    public virtual Lop? MalopNavigation { get; set; }
}
