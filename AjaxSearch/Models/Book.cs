using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjaxSearch.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "укажите название книги")]
        [DisplayName("Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "укажите автора книги")]
        [DisplayName("Автор")]
        public string Author { get; set; }

        [Required(ErrorMessage = "укажите стоимость книги")]
        [Range(typeof(decimal), "0,1", "999999,99",
            ErrorMessage = "введите положительную цену")]
        [Column(TypeName = "decimal(6,2)")]
        [DisplayName("Цена")]
        public decimal Price { get; set; }
    }
}
