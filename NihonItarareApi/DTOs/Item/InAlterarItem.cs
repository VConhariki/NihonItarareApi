using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.DTOs.Item
{
    public class InAlterarItem
    {
        [Required]
        public int Id { get; set; }
        public int? ProdutoId { get; set; }
        public int? Quantidade { get; set; }
        public string? Observacao { get; set; }
        public bool? FoiEnviadoCozinha { get; set; }
    }
}
