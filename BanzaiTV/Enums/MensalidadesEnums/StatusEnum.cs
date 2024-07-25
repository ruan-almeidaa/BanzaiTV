using System.ComponentModel;

namespace BanzaiTV.Enums.MensalidadesEnums
{
    public enum StatusEnum
    {
        [Description("Pendente")]
        Pendente = 1,
        [Description("Paga")]
        Paga = 2,
        [Description("Atrasada")]
        Atrasada = 3
    }
}
