using Microsoft.EntityFrameworkCore;
using NihonItarareApi.Context;
using NihonItarareApi.Models;

namespace NihonItarareApi.Repository.Itens
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public Item? ObterItemPorId(int id)
        {
            try
            {
                return _context.Item
                    .Include(i => i.Produto)
                    .FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Item> ObterItens()
        {
            try
            {
                return _context.Item.Include(i => i.Produto).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Item? InserirItem(Item item)
        {
            try
            {
                _context.Item.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AlterarItem(Item item)
        {
            try
            {
                _context.Item.Update(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeletarItem(int id)
        {
            try
            {
                var atual = ObterItemPorId(id);
                if (atual != null)
                {
                    _context.Item.Remove(atual);
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
