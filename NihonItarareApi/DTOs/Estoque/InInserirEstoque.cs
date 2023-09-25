using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.DTOs.Estoque
{
    public class InInserirEstoque
    {
        [Required]
        public int ProdutoId { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
}
