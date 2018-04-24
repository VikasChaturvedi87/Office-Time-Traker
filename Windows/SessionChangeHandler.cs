using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTraker.Windows {
    public class SessionChangeHandler : Control
    {
        [DllImport("WtsApi32.dll")]
        private static extern bool WTSRegisterSessionNotification(IntPtr hWnd, [MarshalAs(UnmanagedType.U4)]int dwFlags);
        [DllImport("WtsApi32.dll")]
        private static extern bool WTSUnRegisterSessionNotification(IntPtr hWnd);

        private const int NOTIFY_FOR_THIS_SESSION = 0;
        private const int WM_WTSSESSION_CHANGE = 0x2b1;
        private const int WTS_SESSION_LOCK = 0x7;
        private const int WTS_SESSION_UNLOCK = 0x8;

        public event EventHandler MachineLocked;
        public event EventHandler MachineUnlocked;

        public SessionChangeHandler() {
            if (!WTSRegisterSessionNotification(this.Handle, NOTIFY_FOR_THIS_SESSION)) {
                Marshal.ThrowExceptionForHR(Marshal.GetLastWin32Error());
            }
        }

        protected override void OnHandleDestroyed(EventArgs e) {
            // unregister the handle before it gets destroyed
            WTSUnRegisterSessionNotification(this.Handle);
            base.OnHandleDestroyed(e);
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == WM_WTSSESSION_CHANGE) {
                int value = m.WParam.ToInt32();
                if (value == WTS_SESSION_LOCK) {
                    OnMachineLocked(EventArgs.Empty);
                }
                else if (value == WTS_SESSION_UNLOCK) {
                    OnMachineUnlocked(EventArgs.Empty);
                }
            }
            base.WndProc(ref m);
        }

        protected virtual void OnMachineLocked(EventArgs e) {
            if (MachineLocked != null) {
                MachineLocked(this, e);
            }
        }

        protected virtual void OnMachineUnlocked(EventArgs e) {
            if (MachineUnlocked != null) {
                MachineUnlocked(this, e);
            }
        }
    }
}
