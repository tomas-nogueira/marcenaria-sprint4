using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marcenaria.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Column("ClienteId")]
        [Display(Name = "Id do Cliente")]

        public int ClienteId { get; set; }

        [Column("ClienteNome")]
        [Display(Name = "Nome do cliente")]

        public string ClienteNome { get; set; } = string.Empty;

        [Column("ClienteTel")]
        [Display(Name = "Telefone do cliente")]

        public string ClienteTel { get; set; } = string.Empty;

        [Column("ClienteEmail")]
        [Display(Name = "Email do cliente")]

        public string ClienteEmail { get; set; } = string.Empty;
    }
}