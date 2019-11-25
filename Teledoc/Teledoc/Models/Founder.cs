using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Teledoc.Models
{
    public class Founder
    {       
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите ИНН")]
        [RegularExpression(@"^(\d{10}|\d{12})$", ErrorMessage = "10 или 12 цифр (для юридических и физических лиц соответственно)")]
        [Display(Name = "ИНН")]
        public long Inn { get; set; }


        [RegularExpression(@"^[а-я, А-Я,-]+$", ErrorMessage = "Введите только буквы")]
        [Required(ErrorMessage = "Введите ФИО")]
        [Display(Name = "ФИО")]
        public string Fio { get; set; }

        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        public DateTime Date_Add { get; set; }

        [Display(Name = "Дата обновления")]
        [DataType(DataType.DateTime)]
        public DateTime Date_Upd { get; set; }

        [Display(Name = "Организация")]
        public int? ClientId { get; set; }
        public Client Client { get; set; }
    }
}