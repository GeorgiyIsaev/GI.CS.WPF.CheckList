using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Copy
{
    public delegate void AddTextBoxDelegate(String text);

    public class CopyCtrl
    {
        public static AddTextBoxDelegate AddTextEvent;

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        #region Control + Q
        //обработчик сообщений для окна при нажатии горячих клавиг
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
        #endregion

        #region Control + W
        //обработчик сообщений для окна при нажатии горячих клавиг
        private static IntPtr WndProcW(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == ConstantKey.WM_HOTKEY)
            {
                AddTextEvent?.Invoke(Clipboard.GetText()); //вызвать вставку из буфера
                handled = true;
            }
            return IntPtr.Zero;
        }
        /*Метод который добавляет в приложение для окна вызов горячих клавиш*/
        public static void Window_LoadedKeyW(Window window)
        {
            /*Вставка*/
            WindowInteropHelper h = new System.Windows.Interop.WindowInteropHelper(window);
            System.Windows.Interop.HwndSource source = System.Windows.Interop.HwndSource.FromHwnd(h.Handle);
            source.AddHook(new System.Windows.Interop.HwndSourceHook(WndProcW));//регистрируем обработчик сообщений       
            bool res = ConstantKey.RegisterHotKey(h.Handle, 1, ConstantKey.MOD_CONTROL | ConstantKey.MOD_NOREPEAT, ConstantKey.KEY_W);
            if (res == false) MessageBox.Show("RegisterHotKey failed re2s");
        }
        #endregion
    }
}
