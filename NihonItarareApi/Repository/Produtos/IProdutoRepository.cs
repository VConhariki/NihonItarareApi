using NihonItarareApi.Models;

namespace NihonItarareApi.Repository.Produtos
{
    public interface IProdutoRepository
    {
        Produto? ObterProdutoPorId(int id);
        IEnumerable<Produto> ObterProdutos();
        Produto? InserirProduto(Produto produto);
        bool AlterarProduto(Produto produto);
        bool DeletarProduto(int id);
    }
}
