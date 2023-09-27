using Microsoft.Build.Framework;

namespace NihonItarareApi.DTOs.ItemPedido
{
    public class InAlterarItemPedido
    {
        [Required]
        public int Id { get; set; }
        public int? PedidoId { get; set; }
        public int? ItemId { get; set; }
    }
}
