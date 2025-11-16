using System;
using System.Collections.Generic;

namespace YakovleKursovayaASP.Models;

public partial class ArtisticBook
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? Thematics { get; set; }

    public string? Genre { get; set; }

    public string? Series { get; set; }

    public int Pages { get; set; }

    public string? BindingType { get; set; }

    public virtual Product Product { get; set; } = null!;
}
