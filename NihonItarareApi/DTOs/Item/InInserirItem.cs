using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.DTOs.Item
{
    public class InInserirItem
    {
        [Required]
        public int ProdutoId { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public string? Observacao { get; set; }
        [Required]
        public bool FoiEnviadoCozinha { get; set; }
    }
}
