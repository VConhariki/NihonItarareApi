using NihonItarareApi.DTOs.Produto;
using NihonItarareApi.Models;
using NihonItarareApi.Repository.Produtos;

namespace NihonItarareApi.Services.Produtos
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Produto? ObterProdutoPorId(int id) => _produtoRepository.ObterProdutoPorId(id);
        public IEnumerable<Produto> ObterProdutos()
        {
            return _produtoRepository.ObterProdutos();
        }

        public Produto? InserirProduto(InInserirProduto inProduto)
        {
            Produto produto = new()
            {
                Descricao = inProduto.Descricao,
                Preco = inProduto.Preco
            };

            return _produtoRepository.InserirProduto(produto);
        }

        public bool AlterarProduto(InAlterarProduto novoProduto)
        {
            var produto = _produtoRepository.ObterProdutoPorId(novoProduto.Id);

            if (produto == null)
                throw new Exception("Produto não encontrado");

            produto.Descricao = novoProduto.Descricao ?? produto.Descricao;
            produto.Preco = novoProduto.Preco ?? produto.Preco;

            return _produtoRepository.AlterarProduto(produto);
        }

        public bool DeletarProduto(int id) => _produtoRepository.DeletarProduto(id);
    }
}
