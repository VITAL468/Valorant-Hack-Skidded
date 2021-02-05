using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Immortal.SDK.Extensions
{
	// Token: 0x02000015 RID: 21
	internal class ProcessUtils
	{
		// Token: 0x0600003E RID: 62
		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		// Token: 0x0600003F RID: 63
		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

		// Token: 0x06000040 RID: 64 RVA: 0x000063C8 File Offset: 0x000045C8
		public static Process getForegroundProcess()
		{
			uint value = 0U;
			IntPtr foregroundWindow = ProcessUtils.GetForegroundWindow();
			uint windowThreadProcessId = ProcessUtils.GetWindowThreadProcessId(foregroundWindow, out value);
			return Process.GetProcessById(Convert.ToInt32(value));
		}
	}
}
