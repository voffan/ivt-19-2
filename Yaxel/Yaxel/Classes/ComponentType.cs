using System.ComponentModel;

namespace Yaxel.Classes
{
    enum ComponentType
    {
        [Description("Процессор")]
        CPU,
        [Description("Материнская плата")]
        Motherboard,
        [Description("ОЗУ")]
        RAM,
        [Description("Видеокарта")]
        Video,
        [Description("HDD")]
        HDD,
        [Description("SSD")]
        SSD,
        [Description("Сетевая карта")]
        Net,
        [Description("Корпус")]
        Box
    }
}
