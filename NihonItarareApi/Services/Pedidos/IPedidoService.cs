using NihonItarareApi.DTOs.Pedido;
using NihonItarareApi.Models;

namespace NihonItarareApi.Services.Pedidos
{
    public interface IPedidoService
    {
        Pedido? ObterPedidoPorId(int id);
        IEnumerable<Pedido> ObterPedidos();
        Pedido? InserirPedido(InInserirPedido inPedido);
        bool AlterarPedido(InAlterarPedido novoPedido);
        bool DeletarPedido(int id);
    }
}
