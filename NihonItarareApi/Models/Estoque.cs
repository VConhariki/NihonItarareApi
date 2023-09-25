using System.ComponentModel.DataAnnotations;
using NihonItarareApi.Context;

namespace NihonItarareApi.Models
{
    public class Estoque
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        public virtual Produto? Produto { get; set; }
        [Required]
        public int Quantidade { get; set; } = 0;
    }
}