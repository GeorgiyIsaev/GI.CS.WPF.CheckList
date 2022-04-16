
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace Copy
{
    public static class ConstantKey
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);


        //необходимые константы
        public const int MOD_CONTROL = 0x2;
        public const int WM_HOTKEY = 0x312;
        public const uint MOD_NOREPEAT = 0;
        public const int KEY_C = 67;

        //несколько примеров виртуальных кодов
        public const uint KEY_1 = 0x31;
        public const uint KEY_2 = 0x32;
        public const uint KEY_3 = 0x33;
        public const uint KEY_5 = 0x34;

        public const uint KEY_Q = 0x51;
        public const uint KEY_W = 0x57;
        public const uint KEY_E = 0x45;
        public const uint KEY_R = 0x52;

    }
}
