using NihonItarareApi.DTOs.Pedido;
using NihonItarareApi.Models;
using NihonItarareApi.Repository.Itens;
using NihonItarareApi.Repository.Mesas;
using NihonItarareApi.Repository.Pedidos;
using NihonItarareApi.Utils.Enums;

namespace NihonItarareApi.Services.Pedidos
{
    //TODO: Rever relação entre item -> pedido
    public class PedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMesaRepository _mesaRepository;

        public PedidoService(IPedidoRepository pedidoRepository, IItemRepository itemRepository, IMesaRepository mesaRepository)
        {
            _pedidoRepository = pedidoRepository;
            _itemRepository = itemRepository;
            _mesaRepository = mesaRepository;
        }

        public Pedido? ObterPedidoPorId(int id) => _pedidoRepository.ObterPedidoPorId(id);
        public IEnumerable<Pedido> ObterPedidos()
        {
            return _pedidoRepository.ObterPedidos();
        }

        public Pedido? InserirPedido(InInserirPedido inPedido)
        {
            
            var mesa = _mesaRepository.ObterMesaPorId(inPedido.MesaId);

            Pedido pedido = new()
            {
                Mesa = mesa,
                MesaId = inPedido.MesaId,
                Total = 0,
                Status = StatusPedidoEnum.Iniciado
            };

            return _pedidoRepository.InserirPedido(pedido);
        }

        public bool AlterarPedido(InAlterarPedido novoPedido)
        {
            var pedido = _pedidoRepository.ObterPedidoPorId(novoPedido.Id);
            if (pedido == null)
                throw new Exception("Pedido não encontrado");

            return _pedidoRepository.AlterarPedido(pedido);
        }

        public bool DeletarPedido(int id) => _pedidoRepository.DeletarPedido(id);
    }
}
