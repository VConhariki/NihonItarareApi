using System.ComponentModel;

namespace NihonItarareApi.Utils.Enums
{
    public enum FormaPagamentoEnum
    {
        [Description("Cartão de Crédito")]
        CartaoCredito = 1,
        [Description("Cartão de Débito")]
        CartaoDebito = 2,
        [Description("Dinheiro")]
        Dinheiro = 3,
        [Description("Pix")]
        Pix = 4
    }
}