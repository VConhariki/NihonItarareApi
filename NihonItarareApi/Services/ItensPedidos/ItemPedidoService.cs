using NihonItarareApi.DTOs.ItemPedido;
using NihonItarareApi.Models;
using NihonItarareApi.Repository.Itens;
using NihonItarareApi.Repository.ItensPedidos;
using NihonItarareApi.Repository.Pedidos;

namespace NihonItarareApi.Services.ItensPedidos
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public ItemPedidoService(IItemPedidoRepository itemPedidoRepository, IItemRepository itemRepository, IPedidoRepository pedidoRepository)
        {
            _itemPedidoRepository = itemPedidoRepository;
            _itemRepository = itemRepository;
            _pedidoRepository = pedidoRepository;
        }

        public ItemPedido? ObterItemPedidoPorId(int id) => _itemPedidoRepository.ObterItemPedidoPorId(id);
        public IEnumerable<ItemPedido> ObterItensPedidos() => _itemPedidoRepository.ObterItensPedidos();

        public ItemPedido? InserirItemPedido(InInserirItemPedido inItemPedido)
        {
            var pedido = _pedidoRepository.ObterPedidoPorId(inItemPedido.PedidoId);

            if (pedido == null)
                throw new Exception("Pedido não encontrado");

            var item = _itemRepository.ObterItemPorId(inItemPedido.ItemId);

            if (item == null)
                throw new Exception("Item não encontrado");

            ItemPedido itemPedido = new()
            {
                ItemId = item.Id,
                Item = item,
                PedidoId = pedido.Id,
                Pedido = pedido
            };

            return _itemPedidoRepository.InserirItemPedido(itemPedido);
        }

        public bool AlterarItemPedido(InAlterarItemPedido novoItemPedido)
        {
            var itemPedido = _itemPedidoRepository.ObterItemPedidoPorId(novoItemPedido.Id);

            if (itemPedido == null)
                throw new Exception("ItemPedido não encontrado");

            if (novoItemPedido.ItemId != null)
            {
                var item = _itemRepository.ObterItemPorId(novoItemPedido.ItemId.Value);

                if (item == null)
                    throw new Exception("Item não encontrado");

                itemPedido.Item = item;
                itemPedido.ItemId = item.Id;
            }

            if (novoItemPedido.PedidoId != null)
            {
                var pedido = _pedidoRepository.ObterPedidoPorId(novoItemPedido.PedidoId.Value);

                if (pedido == null)
                    throw new Exception("Pedido não encontrado");

                itemPedido.Pedido = pedido;
                itemPedido.PedidoId = pedido.Id;
            }

            return _itemPedidoRepository.AlterarItemPedido(itemPedido);
        }

        public bool DeletarItemPedido(int id) => _itemPedidoRepository.DeletarItemPedido(id);
    }
}
