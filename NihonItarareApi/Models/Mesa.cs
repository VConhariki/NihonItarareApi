using NihonItarareApi.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.Models
{
    public class Mesa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Numero { get; set; }
        public StatusMesaEnum Status { get; set; }
    }
}