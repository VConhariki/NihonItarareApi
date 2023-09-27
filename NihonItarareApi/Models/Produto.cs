using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Descricao { get; set; }
        [Required]
        public double Preco { get; set; }
    }
}