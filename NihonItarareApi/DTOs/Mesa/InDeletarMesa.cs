using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.DTOs.Mesa
{
    public class InDeletarMesa
    {
        [Required]
        public int Id { get; set; }
    }
}
