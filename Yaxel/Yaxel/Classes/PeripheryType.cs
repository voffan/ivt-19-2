using System.ComponentModel;

namespace Yaxel.Classes
{
    enum PeripheryType
    {
        [Description("Монитор")]
        Monitor,
        [Description("Клавиатура")]
        Keyboard,
        [Description("Мышь")]
        Mouse,
        [Description("Графический планшет")]
        GraphicTablet,
        [Description("Микрофон")]
        Microphone,
        [Description("Камера")]
        Camera,
        [Description("Сканер")]
        Scanner,
        [Description("Принтер")]
        Printer
    }
}
