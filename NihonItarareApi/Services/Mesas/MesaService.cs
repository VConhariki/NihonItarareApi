using NihonItarareApi.DTOs.Mesa;
using NihonItarareApi.Models;
using NihonItarareApi.Repository.Mesas;

namespace NihonItarareApi.Services.Mesas
{
    public class MesaService : IMesaService
    {
        private readonly IMesaRepository _mesaRepository;

        public MesaService(IMesaRepository mesaRepository)
        {
            _mesaRepository = mesaRepository;
        }

        public Mesa? ObterMesaPorId(int id) => _mesaRepository.ObterMesaPorId(id);
        public IEnumerable<Mesa> ObterMesas()
        {
            return _mesaRepository.ObterMesas();
        }

        public Mesa? InserirMesa(InInserirMesa inMesa)
        {
            Mesa Mesa = new()
            {
                Numero = inMesa.Numero,
                Status = inMesa.Status
            };

            return _mesaRepository.InserirMesa(Mesa);
        }

        public bool AlterarMesa(InAlterarMesa novaMesa)
        {
            var mesa = _mesaRepository.ObterMesaPorId(novaMesa.Id);
            if (mesa == null)
                throw new Exception("Mesa não encontrado");

            mesa.Numero = novaMesa.Numero ?? mesa.Numero;
            mesa.Status = novaMesa.Status ?? mesa.Status;

            return _mesaRepository.AlterarMesa(mesa);
        }

        public bool DeletarMesa(int id) => _mesaRepository.DeletarMesa(id);
    }
}
