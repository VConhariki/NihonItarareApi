using NihonItarareApi.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public virtual Item? Item { get; set; }
        public int? MesaId { get; set; }
        public Mesa? Mesa { get; set; }
        public FormaPagamentoEnum? FormaPagamento{ get; set; }
        public StatusPedidoEnum Status { get; set; }
        public double Total { get; set; }
    }
}
