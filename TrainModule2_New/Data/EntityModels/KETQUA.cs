using System;
using System.Collections.Generic;

namespace Data.EntityModels;

public partial class Ketqua
{
    public string Masv { get; set; } = null!;

    public string Mamh { get; set; } = null!;

    public double? Diemso { get; set; }

    public string? Xeploai { get; set; }

    public virtual Monhoc MamhNavigation { get; set; } = null!;

    public virtual Sinhvien MasvNavigation { get; set; } = null!;
}
