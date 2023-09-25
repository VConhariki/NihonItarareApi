using NihonItarareApi.Models;

namespace NihonItarareApi.Repository.Mesas
{
    public interface IMesaRepository
    {
        Mesa? ObterMesaPorId(int id);
        IEnumerable<Mesa> ObterMesas();
        Mesa? InserirMesa(Mesa Mesa);
        bool AlterarMesa(Mesa Mesa);
        bool DeletarMesa(int id);
    }
}
