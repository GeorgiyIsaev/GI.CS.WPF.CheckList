using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Interop;
//Windows.Input.Key до System.Windows.Forms.Keys
//using System.Windows.Forms.Keys;

namespace MyTestCopy
{
    public delegate void AddTextBoxDelegate(String text);

    class CopyCtrl
    {
        public static AddTextBoxDelegate AddTextEvent;

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);


        //обработчик сообщений для окна
        private static IntPtr WndProcQ(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == ConstantKey.WM_HOTKEY)
            {    
                AddTextEvent?.Invoke(Clipboard.GetText()); //вызвать вставку из буфера
                handled = true;
            }
            return IntPtr.Zero;
        }

        /*Метод который добавляет в приложение для окна вызов горячих клавиш*/
        public static void Window_LoadedKeyQ(Window window)
        {
            /*Вставка*/
            WindowInteropHelper h = new System.Windows.Interop.WindowInteropHelper(window);
            System.Windows.Interop.HwndSource source = System.Windows.Interop.HwndSource.FromHwnd(h.Handle);
            source.AddHook(new System.Windows.Interop.HwndSourceHook(WndProcQ));//регистрируем обработчик сообщений       
            bool res = ConstantKey.RegisterHotKey(h.Handle, 1, ConstantKey.MOD_CONTROL | ConstantKey.MOD_NOREPEAT, ConstantKey.KEY_Q);
            if (res == false) MessageBox.Show("RegisterHotKey failed re2s");
        }
    }
}
