using System.ComponentModel;

namespace Yaxel.Classes
{
    enum Status
    {
        [Description("Работает")]
        Works,
        [Description("В ремонте")]
        InRepair,
        [Description("Не работает")]
        WritterOff
    }
}
