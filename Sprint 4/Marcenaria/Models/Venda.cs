using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Marcenaria.Models
{
    [Table("Venda")]
    public class Venda
    {
        [Column("VendaId")]
        [Display(Name = "Id da Venda")]

        public int VendaId { get; set; }

        [Column("VendaNome")]
        [Display(Name = "Nome da Venda")]

        public string VendaNome { get; set; } = string.Empty;

        [Column("VendaValor")]
        [Display(Name = "Valor da Venda")]

        public decimal VendaValor { get; set; }

        [Column("VendaData")]
        [Display(Name = "Data da Venda")]

        public DateTime VendaData { get; set; }

        [ForeignKey("ClienteId")]

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [ForeignKey("VendedorId")]

        public int VendedorId { get; set; }

        public Vendedor? Vendedor { get; set; }

        [ForeignKey("PagamentoId")]

        public int PagamentoId { get; set; }

        public Pagamento? Pagamento { get; set; }

        [NotMapped]
        public List<VendaHasProduto>? ProdutoList { get; set; }
    }
}
