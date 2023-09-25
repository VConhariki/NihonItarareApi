using NihonItarareApi.Utils.Enums;

namespace NihonItarareApi.DTOs.Mesa
{
    public class InInserirMesa
    {
        public int Numero { get; set; }
        public StatusMesaEnum Status { get; set; } = StatusMesaEnum.Disponivel;
    }
}
