using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Marcenaria.Models
{
    [Table("VendaHasProduto")]
    public class VendaHasProduto
    {
        [Column("VendaHasProdutoId")]
        [Display(Name = "Cód. da venda do produto")]

        public int Id { get; set; }

        [ForeignKey("VendaId")]

        public int VendaId { get; set; }

        public Venda? Venda { get; set; }

        [ForeignKey("ProdutoId")]

        public int ProdutoId { get; set; }

        public Produto? Produto { get; set; }
    }
}
