using NihonItarareApi.DTOs.Estoque;
using NihonItarareApi.Models;
using NihonItarareApi.Repository.Estoques;
using NihonItarareApi.Repository.Produtos;

namespace NihonItarareApi.Services.Estoques
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IProdutoRepository _produtoRepository;

        public EstoqueService(IEstoqueRepository estoqueRepository, IProdutoRepository produtoRepository)
        {
            _estoqueRepository = estoqueRepository;
            _produtoRepository = produtoRepository;
        }

        public Estoque? ObterEstoquePorId(int id) => _estoqueRepository.ObterEstoquePorId(id);
        public IEnumerable<Estoque> ObterEstoques()
        {
            return _estoqueRepository.ObterEstoques();
        }

        public Estoque? InserirEstoque(InInserirEstoque inEstoque)
        {
            var produto = _produtoRepository.ObterProdutoPorId(inEstoque.ProdutoId);

            if (produto == null)
                throw new Exception("Produto não encontrado");

            Estoque estoque = new()
            {
                Produto = produto,
                ProdutoId = inEstoque.ProdutoId,
                Quantidade = inEstoque.Quantidade
            };

            return _estoqueRepository.InserirEstoque(estoque);
        }

        public bool AlterarEstoque(InAlterarEstoqueQuantidade novoEstoque)
        {
            var estoque = _estoqueRepository.ObterEstoquePorId(novoEstoque.Id);

            if(estoque == null)
                throw new Exception("Estoque não encontrado");

            estoque.Quantidade = novoEstoque.Quantidade;
            return _estoqueRepository.AlterarEstoque(estoque);
        }

        public bool DeletarEstoque(int id) => _estoqueRepository.DeletarEstoque(id);
    }
}
