using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Marcenaria.Models
{
    [Table("Vendedor")]
    public class Vendedor
    {
        [Column("VendedorId")]
        [Display(Name = "Id do Vendedor")]

        public int VendedorId { get; set; }

        [Column("VendedorNome")]
        [Display(Name = "Nome do Vendedor")]

        public string VendedorNome { get; set; } = string.Empty;
    }
}
