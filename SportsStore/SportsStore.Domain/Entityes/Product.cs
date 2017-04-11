using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace SportsStore.Domain.Entityes
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Категория")]
        public string Category { get; set; }
    }
}
