using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models
{
    public class Category
    {
        public int id { get; set; }

        [Display(Name ="Descrição")]
        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string description { get; set; }
    }
}