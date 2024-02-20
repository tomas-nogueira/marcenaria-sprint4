using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Marcenaria.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("ProdutoId")]
        [Display(Name = "Id do Produto")]

        public int ProdutoId { get; set; }

        [Column("ProdutoNome")]
        [Display(Name = "Nome do Produto")]

        public string ProdutoNome { get; set; } = string.Empty;

        [Column("ProdutoPreco")]
        [Display(Name = "Preço do Produto")]

        public decimal ProdutoPreco { get; set; }

        [Column("ProdutoEstoque")]
        [Display(Name = "Estoque do Produto")]

        public string ProdutoEstoque { get; set; } = string.Empty;

        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        [ForeignKey("FornecedorId")]

        public int FornecedorId { get; set; }

        public Fornecedor? Fornecedor { get; set; }
    }
}
