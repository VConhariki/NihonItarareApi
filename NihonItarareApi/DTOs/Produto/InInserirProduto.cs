using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.DTOs.Produto
{
    public class InInserirProduto
    {
        [Required]
        public string Descricao { get; set; } = "Sem Descrição";
        [Required]
        public double Preco { get; set; }
        [Required]
        public bool IsMateriaPrima { get; set; }
    }
}
