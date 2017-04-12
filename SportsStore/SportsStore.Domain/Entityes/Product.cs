using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace SportsStore.Domain.Entityes
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Не указано название.")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Не указано описание.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Не указана цена.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена не может иметь отрицательное значение.")]
        public decimal Price { get; set; }
        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Не указана категория.")]
        public string Category { get; set; }
    }
}
