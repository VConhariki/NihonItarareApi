using NihonItarareApi.DTOs.Item;
using NihonItarareApi.Models;

namespace NihonItarareApi.Services.Itens
{
    public interface IItemService
    {
        Item? ObterItemPorId(int id);
        IEnumerable<Item> ObterItens();
        Item? InserirItem(InInserirItem inItem);
        bool AlterarItem(InAlterarItem novoItem);
        bool DeletarItem(int id);
    }
}
