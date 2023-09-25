using NihonItarareApi.DTOs.Produto;
using NihonItarareApi.Models;

namespace NihonItarareApi.Services.Produtos
{
    public interface IProdutoService
    {
        Produto? ObterProdutoPorId(int id);
        IEnumerable<Produto> ObterProdutos();
        Produto? InserirProduto(InInserirProduto inProduto);
        bool AlterarProduto(InAlterarProduto novoProduto);
        bool DeletarProduto(int id);
     }
}
