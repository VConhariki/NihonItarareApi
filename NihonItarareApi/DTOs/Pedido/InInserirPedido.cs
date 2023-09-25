using NihonItarareApi.Utils.Enums;

namespace NihonItarareApi.DTOs.Pedido
{
    public class InInserirPedido
    {
        public int? ItemId { get; set; }
        public int MesaId { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public StatusPedidoEnum Status { get; set; }
        public double Total { get; set; }
    }
}
