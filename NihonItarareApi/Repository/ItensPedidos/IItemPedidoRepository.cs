using NihonItarareApi.Models;

namespace NihonItarareApi.Repository.ItensPedidos
{
    public interface IItemPedidoRepository
    {
        ItemPedido? ObterItemPedidoPorId(int id);
        IEnumerable<ItemPedido> ObterItensPedidos();
        ItemPedido? InserirItemPedido(ItemPedido itemPedido);
        bool AlterarItemPedido(ItemPedido itemPedido);
        bool DeletarItemPedido(int id);
    }

}
