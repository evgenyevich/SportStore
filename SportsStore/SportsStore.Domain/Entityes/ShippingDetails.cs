using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entityes
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Пожалуйста, укажите свое имя")]
        public string Name  { get; set; }
        [Required(ErrorMessage = "Необходим адрес доставки")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Укажите город")]
        public string City { get; set; }
        public bool GiftWrap { get; set; }
    }
}
