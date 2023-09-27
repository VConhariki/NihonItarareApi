using NihonItarareApi.DTOs.ItemPedido;
using NihonItarareApi.Models;

namespace NihonItarareApi.Services.ItensPedidos
{
    public interface IItemPedidoService
    {
        ItemPedido? ObterItemPedidoPorId(int id);
        IEnumerable<ItemPedido> ObterItensPedidos();
        ItemPedido? InserirItemPedido(InInserirItemPedido inItemPedido);
        bool AlterarItemPedido(InAlterarItemPedido novoItemPedido);
        bool DeletarItemPedido(int id);
    }
}
