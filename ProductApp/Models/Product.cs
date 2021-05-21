using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models
{
    public class Product
    {
        public int id { get; set; }

        [Display(Name ="Descrição")]
        public string description { get; set; }
        
        [Display(Name ="Quantidade")]
        [Range(1, 10, ErrorMessage = "Valor Fora da faixa!")]
        public int quantity { get; set; }
        public int categoryId { get; set; }

        [Display(Name ="Categoria")]
        public Category category { get; set; }
    }
}