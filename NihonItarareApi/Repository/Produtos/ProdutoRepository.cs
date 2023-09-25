using NihonItarareApi.Context;
using NihonItarareApi.Models;

namespace NihonItarareApi.Repository.Produtos
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Produto? ObterProdutoPorId(int id)
        {
            try
            {
                return _context.Produto
                    .FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Produto> ObterProdutos()
        {
            try
            {
                return _context.Produto.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Produto? InserirProduto(Produto produto)
        {
            try
            {
                _context.Produto.Add(produto);
                _context.SaveChanges();
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AlterarProduto(Produto produto)
        {
            try
            {
                _context.Produto.Update(produto);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeletarProduto(int id)
        {
            try
            {
                var atual = ObterProdutoPorId(id);
                if (atual != null)
                {
                    _context.Produto.Remove(atual);
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
