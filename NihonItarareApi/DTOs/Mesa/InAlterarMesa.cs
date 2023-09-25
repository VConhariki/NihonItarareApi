using NihonItarareApi.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.DTOs.Mesa
{
    public class InAlterarMesa
    {
        [Required]
        public int Id { get; set; }
        public int? Numero { get; set; }
        public StatusMesaEnum? Status { get; set; }
    }
}
