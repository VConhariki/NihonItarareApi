using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.Models
{
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        [Required]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
