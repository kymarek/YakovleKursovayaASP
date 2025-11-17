using System;
using System.Collections.Generic;

namespace YakovleKursovayaASP.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Weight { get; set; }

    public string? Size { get; set; }

    public string? Brand { get; set; }

    public string? Photo { get; set; }

    public decimal Price { get; set; }

    public int ProductType { get; set; }

    public virtual ICollection<BoardGame> BoardGames { get; set; } = new List<BoardGame>();

    public virtual ICollection<StudingBook> StudingBooks { get; set; } = new List<StudingBook>();
}
