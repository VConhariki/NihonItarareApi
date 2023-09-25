using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.DTOs.Produto
{
    public class InAlterarProduto
    {
        [Required]
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public double? Preco { get; set; }
        public bool? IsMateriaPrima { get; set; }
    }
}
