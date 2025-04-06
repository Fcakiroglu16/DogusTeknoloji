using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DogusTeknoloji.Web.Models.Services.ViewModels;

public class EditProductViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ürün ismi boş olamaz")]
    [Display(Name = "Product Name :")]
    public string? Name { get; set; } = null!;


    [Required(ErrorMessage = "Ürün açıklaması boş olamaz")]
    [Display(Name = "Description :")]
    public string? Description { get; set; }


    [Required(ErrorMessage = "Ürün fiyat boş olamaz")]
    [Range(1, 10000, ErrorMessage = "ürün fiyatı 0 ile 10000 arasında olmalıdır")]
    [Display(Name = "Price :")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "Ürün stock boş olamaz")]
    [Range(1, 500, ErrorMessage = "ürün stok sayısı 1 ile 500 arasında olmalıdır")]
    [Display(Name = "Stock :")]
    public int? Stock { get; set; }

    [Required(ErrorMessage = "Kategori seçiniz")]
    [Display(Name = "Category :")]
    public int? CategoryId { get; set; }

    [Display(Name = "Is Published :")] public bool IsPublished { get; set; }

    [ValidateNever] public SelectList CategoryList { get; set; } = null!;
}