using System;
using System.Collections.Generic;

namespace Data.EntityModels;

public partial class Monhoc
{
    public string Mamh { get; set; } = null!;

    public string? Tenmh { get; set; }

    public int? Sotc { get; set; }

    public virtual ICollection<Ketqua> Ketquas { get; set; } = new List<Ketqua>();
}
