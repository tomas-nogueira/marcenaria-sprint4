using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Marcenaria.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Column("CategoriaId")]
        [Display(Name = "Id da Categoria")]

        public int CategoriaId { get; set; }

        [Column("CategoriaNome")]
        [Display(Name = "Nome da Categoria")]

        public string CategoriaNome { get; set; } = string.Empty;
    }
}
