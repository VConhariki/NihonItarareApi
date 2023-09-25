using NihonItarareApi.Models;

namespace NihonItarareApi.Repository.Estoques
{
    public interface IEstoqueRepository
    {
        Estoque? ObterEstoquePorId(int id);
        IEnumerable<Estoque> ObterEstoques();
        Estoque? InserirEstoque(Estoque estoque);
        bool AlterarEstoque(Estoque estoque);
        bool DeletarEstoque(int id);
    }
}
