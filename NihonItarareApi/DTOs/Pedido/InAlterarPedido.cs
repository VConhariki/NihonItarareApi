using NihonItarareApi.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.DTOs.Pedido
{
    public class InAlterarPedido
    {
        [Required]
        public int Id { get; set; }
        public int? MesaId { get; set; }
        public FormaPagamentoEnum? FormaPagamento { get; set; }
        public StatusPedidoEnum? Status { get; set; }
        public double? Total { get; set; }
    }
}
