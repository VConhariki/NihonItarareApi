using NihonItarareApi.DTOs.Estoque;
using NihonItarareApi.Models;

namespace NihonItarareApi.Services.Estoques
{
    public interface IEstoqueService
    {
        Estoque? ObterEstoquePorId(int id);
        IEnumerable<Estoque> ObterEstoques();
        Estoque? InserirEstoque(InInserirEstoque inEstoque);
        bool AlterarEstoque(InAlterarEstoqueQuantidade novoEstoque);
        bool DeletarEstoque(int id);
    }
}
