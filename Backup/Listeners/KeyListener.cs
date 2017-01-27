using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using RUI;

namespace RUI.Listeners
{
    class KeyListener
    {
        //setup delegate and event
        public delegate void KeyPressHandler(object inputListener, KeyPressEventArgs KeyPressInfo);
        public event KeyPressHandler OnKeyPress;

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private static LowLevelKeyboardProc _proc;
        private static IntPtr _hookID = IntPtr.Zero;

        public KeyListener()
        {
            _proc = HookCallback;
        }

        public void Stop()
        {
            UnhookWindowsHookEx(_hookID);            
        }

        public void Run()
        {
            _hookID = SetHook(_proc);          
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                KeyPressEventArgs KeyPressInfo = new KeyPressEventArgs(Control.ModifierKeys, vkCode, DateTime.Now);
                if (OnKeyPress != null)
                {
                    OnKeyPress(this, KeyPressInfo);
                }
            }
            else if (nCode >= 0 && wParam == (IntPtr)WM_SYSKEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                KeyPressEventArgs KeyPressInfo = new KeyPressEventArgs(Control.ModifierKeys, vkCode, DateTime.Now);

                if (OnKeyPress != null)
                {
                    OnKeyPress(this, KeyPressInfo);
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }

    public class KeyPressEventArgs : EventArgs
    {
        public KeyPressEventArgs(Keys ModifierKeys, int KeyCode, DateTime now)
        {
            this.ModifierKeys = ModifierKeys;
            this.KeyCode = KeyCode;
            this.CurrentTime = now;
        }
        public readonly Keys ModifierKeys;
        public readonly int KeyCode;
        public readonly DateTime CurrentTime;
    } 
}
