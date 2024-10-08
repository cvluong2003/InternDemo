using System;
using System.Collections.Generic;

namespace Data.EntityModels;

public partial class Giaovien
{
    public string Magv { get; set; } = null!;

    public string? Tengv { get; set; }

    public string? Pass { get; set; }

    public string? Malop { get; set; }

    public virtual Lop? MalopNavigation { get; set; }
}
