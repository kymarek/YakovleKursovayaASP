using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YakovleKursovayaASP.Models;

public partial class ArtisticBookView
{
    [Display(Name = "ID")]
    public int Id { get; set; }

    [Display(Name = "Название")]
    public string? Name { get; set; }

    [Display(Name = "Вес")]
    public int? Weight { get; set; }

    [Display(Name = "Размер")]
    public string? Size { get; set; }

    [Display(Name = "Бренд")]
    public string? Brand { get; set; }

    [Display(Name = "Фотография")]
    public string? Photo { get; set; }

    [Display(Name = "Тематика")]
    public string? Thematics { get; set; }

    [Display(Name = "Жанр")]
    public string? Genre { get; set; }

    [Display(Name = "Серия")]
    public string? Series { get; set; }

    [Display(Name = "Количество страниц")]
    public int Pages { get; set; }

    [Display(Name = "Тип переплета")]
    public string? BindingType { get; set; }

    [Display(Name = "Цена")]
    public decimal Price { get; set; }

    [Display(Name = "Тип продукта")]
    public int ProductType { get; set; }
}
