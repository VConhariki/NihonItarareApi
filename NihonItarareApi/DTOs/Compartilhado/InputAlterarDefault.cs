using System.ComponentModel.DataAnnotations;

namespace NihonItarareApi.DTOs.Compartilhado
{
    public class InputAlterarDefault
    {
        [Required(ErrorMessage = "É necessário infromar o id para fazer uma alteração")]
        public int Id { get; set; }
    }
}
