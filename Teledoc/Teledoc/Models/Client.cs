using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Teledoc.Models
{
    public class Client
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите ИНН")]
        [RegularExpression(@"^(\d{10}|\d{12})$", ErrorMessage = "10 или 12 цифр (для юридических и физических лиц соответственно)")]
        [Display(Name = "ИНН")]
        public long Inn { get; set; }

        [Required(ErrorMessage = "Введите название организации")]
        [Display(Name = "Название организации")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите тип организации")]
        [Display(Name = "Тип")]
        public string Type { get; set; }

        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        public DateTime Date_Add { get; set; }

        [Display(Name = "Дата обновления")]
        [DataType(DataType.DateTime)]
        public DateTime Date_Upd { get; set; }

        public ICollection<Founder> Founders { get; set; }
        public Client()
        {
            Founders = new List<Founder>();
        }

    }
}