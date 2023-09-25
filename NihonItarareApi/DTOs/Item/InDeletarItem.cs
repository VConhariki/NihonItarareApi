using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.DTOs.Item
{
    public class InDeletarItem
    {
        [Required]
        public int Id { get; set; }
    }
}
