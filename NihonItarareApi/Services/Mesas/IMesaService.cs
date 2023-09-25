using NihonItarareApi.DTOs.Mesa;
using NihonItarareApi.Models;

namespace NihonItarareApi.Services.Mesas
{
    public interface IMesaService
    {
        Mesa? ObterMesaPorId(int id);
        IEnumerable<Mesa> ObterMesas();
        Mesa? InserirMesa(InInserirMesa inMesa);
        bool AlterarMesa(InAlterarMesa novaMesa);
        bool DeletarMesa(int id);
    }
}
