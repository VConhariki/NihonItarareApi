using NihonItarareApi.Models;

namespace NihonItarareApi.Repository.Itens
{
    public interface IItemRepository
    {
        Item? ObterItemPorId(int id);
        IEnumerable<Item> ObterItens();
        Item? InserirItem(Item Item);
        bool AlterarItem(Item Item);
        bool DeletarItem(int id);
    }
}
