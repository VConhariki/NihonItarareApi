using Microsoft.EntityFrameworkCore;
using NihonItarareApi.Context;
using NihonItarareApi.Models;

namespace NihonItarareApi.Repository.ItensPedidos
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly AppDbContext _context;

        public ItemPedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public ItemPedido? ObterItemPedidoPorId(int id)
        {
            try
            {
                return _context.ItemPedido
                    .Include(ip => ip.Pedido)
                    .Include(ip => ip.Item)
                    .FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ItemPedido> ObterItensPedidos()
        {
            try
            {
                return _context.ItemPedido
                    .Include(ip => ip.Pedido)
                    .Include(ip => ip.Item)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ItemPedido? InserirItemPedido(ItemPedido itemPedido)
        {
            try
            {
                _context.ItemPedido.Add(itemPedido);
                _context.SaveChanges();
                return itemPedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AlterarItemPedido(ItemPedido itemPedido)
        {
            try
            {
                _context.ItemPedido.Update(itemPedido);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeletarItemPedido(int id)
        {
            try
            {
                var atual = ObterItemPedidoPorId(id);
                if (atual != null)
                {
                    _context.ItemPedido.Remove(atual);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
