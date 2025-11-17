using System;
using System.Collections.Generic;

namespace YakovleKursovayaASP.Models;

public partial class StudingBook
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int? Pages { get; set; }

    public string? BindingType { get; set; }

    public string? Subject { get; set; }

    public string? Class { get; set; }

    public string? StudingType { get; set; }

    public virtual Product Product { get; set; } = null!;
}
