using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marcenaria.Models
{
    [Table("Fornecedor")]
    public class Fornecedor
    {
        [Column("FornecedorId")]
        [Display(Name = "Id do Fornecedor")]

        public int FornecedorId { get; set; }

        [Column("FornecedorNome")]
        [Display(Name = "Nome do Fornecedor")]

        public string FornecedorNome { get; set; } = string.Empty;

        [Column("Cnpj")]
        [Display(Name = "CNPJ do Fornecedor")]

        public string Cnpj { get; set; } = string.Empty;
    }
}