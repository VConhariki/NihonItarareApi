using NihonItarareApi.Models;

namespace NihonItarareApi.Repository.Pedidos
{
    public interface IPedidoRepository
    {
        Pedido? ObterPedidoPorId(int id);
        IEnumerable<Pedido> ObterPedidos();
        Pedido? InserirPedido(Pedido Pedido);
        bool AlterarPedido(Pedido Pedido);
        bool DeletarPedido(int id);
    }
}
