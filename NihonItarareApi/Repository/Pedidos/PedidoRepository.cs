using Microsoft.EntityFrameworkCore;
using NihonItarareApi.Context;
using NihonItarareApi.Models;

namespace NihonItarareApi.Repository.Pedidos
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Pedido? ObterPedidoPorId(int id)
        {
            try
            {
                return _context.Pedido
                    .Include(p=>p.Mesa)
                    .FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Pedido> ObterPedidos()
        {
            try
            {
                return _context.Pedido.Include(p => p.Mesa).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Pedido? InserirPedido(Pedido pedido)
        {
            try
            {
                _context.Pedido.Add(pedido);
                _context.SaveChanges();
                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AlterarPedido(Pedido pedido)
        {
            try
            {
                _context.Pedido.Update(pedido);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeletarPedido(int id)
        {
            try
            {
                var atual = ObterPedidoPorId(id);
                if (atual != null)
                {
                    _context.Pedido.Remove(atual);
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
