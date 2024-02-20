using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Marcenaria.Models
{
    [Table("Pagamento")]
    public class Pagamento
    {
        [Column("PagamentoId")]
        [Display(Name = "Id do Pagamento")]

        public int PagamentoId { get; set; }

        [Column("PagamentoForma")]
        [Display(Name = "Forma do Pagamento")]

        public string PagamentoForma { get; set; } = string.Empty;
    }
}
