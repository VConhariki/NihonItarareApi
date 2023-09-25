using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.DTOs.Estoque
{
    public class InAlterarEstoqueQuantidade
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
}
