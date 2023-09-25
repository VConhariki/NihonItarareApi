using NihonItarareApi.DTOs.Item;
using NihonItarareApi.Models;
using NihonItarareApi.Repository.Itens;
using NihonItarareApi.Repository.Produtos;

namespace NihonItarareApi.Services.Itens
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IProdutoRepository _produtoRepository;

        public ItemService(IItemRepository itemRepository, IProdutoRepository produtoRepository)
        {
            _itemRepository = itemRepository;
            _produtoRepository = produtoRepository;
        }

        public Item? ObterItemPorId(int id) => _itemRepository.ObterItemPorId(id);
        public IEnumerable<Item> ObterItens()
        {
            return _itemRepository.ObterItens();
        }

        public Item? InserirItem(InInserirItem inItem)
        {
            var produto = _produtoRepository.ObterProdutoPorId(inItem.ProdutoId);

            if (produto == null)
                throw new Exception("Produto não encontrado");

            Item Item = new()
            {
                Produto = produto,
                ProdutoId = inItem.ProdutoId,
                Quantidade = inItem.Quantidade,
                FoiEnviadoCozinha = inItem.FoiEnviadoCozinha,
                Observacao = inItem.Observacao
            };

            return _itemRepository.InserirItem(Item);
        }

        public bool AlterarItem(InAlterarItem novoItem)
        {
            var item = _itemRepository.ObterItemPorId(novoItem.Id);
            if (item == null)
                throw new Exception("Item não encontrado");

            if(novoItem.ProdutoId != null)
            {
                var produto = _produtoRepository.ObterProdutoPorId(novoItem.ProdutoId ?? -1);
                if(produto == null)
                    throw new Exception("Produto não encontrado");
                item.Produto = produto;
                item.ProdutoId = novoItem.ProdutoId ?? -1;
            }

            item.Observacao = novoItem.Observacao ?? item.Observacao;
            item.Quantidade = novoItem.Quantidade ?? item.Quantidade;
            item.FoiEnviadoCozinha = novoItem.FoiEnviadoCozinha ?? item.FoiEnviadoCozinha;
            return _itemRepository.AlterarItem(item);
        }

        public bool DeletarItem(int id) => _itemRepository.DeletarItem(id);
    }
}
