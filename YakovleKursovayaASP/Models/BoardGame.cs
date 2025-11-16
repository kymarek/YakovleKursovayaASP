using System;
using System.Collections.Generic;

namespace YakovleKursovayaASP.Models;

public partial class BoardGame
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? Thematics { get; set; }

    public string? Genre { get; set; }

    public string? GameTime { get; set; }

    public string? GameType { get; set; }

    public int? PlayersCount { get; set; }

    public virtual Product Product { get; set; } = null!;
}
