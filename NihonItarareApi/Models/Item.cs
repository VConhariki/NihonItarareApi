using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto? Produto { get; set; }
        public int Quantidade { get; set; }
        [MaxLength(255)]
        public string? Observacao { get; set; }
        public bool FoiEnviadoCozinha { get; set; }
    }
}