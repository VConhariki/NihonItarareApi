using Microsoft.EntityFrameworkCore;
using NihonItarareApi.Context;
using NihonItarareApi.Models;

namespace NihonItarareApi.Repository.Estoques
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly AppDbContext _context;

        public EstoqueRepository(AppDbContext context)
        {
            _context = context;
        }

        public Estoque? ObterEstoquePorId(int id)
        {
            try
            {
                return _context.Estoque
                    .Include(i => i.Produto)
                    .FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Estoque> ObterEstoques()
        {
            try
            {
                return _context.Estoque.Include(i => i.Produto).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Estoque? InserirEstoque(Estoque estoque)
        {
            try
            {
                _context.Estoque.Add(estoque);
                _context.SaveChanges();
                return estoque;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AlterarEstoque(Estoque estoque)
        {
            try
            {
                _context.Estoque.Update(estoque);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeletarEstoque(int id)
        {
            try
            {
                var atual = ObterEstoquePorId(id);
                if (atual != null)
                {
                    _context.Estoque.Remove(atual);
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
