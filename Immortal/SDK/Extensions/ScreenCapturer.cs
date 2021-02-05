using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Immortal.SDK.Extensions
{
	// Token: 0x02000017 RID: 23
	internal class ScreenCapturer
	{
		// Token: 0x06000046 RID: 70
		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		// Token: 0x06000047 RID: 71
		[DllImport("user32.dll")]
		private static extern IntPtr GetWindowRect(IntPtr hWnd, ref ScreenCapturer.Rect rect);

		// Token: 0x06000048 RID: 72 RVA: 0x000064F0 File Offset: 0x000046F0
		public Bitmap Capture(ScreenCapturer.enmScreenCaptureMode screenCaptureMode = ScreenCapturer.enmScreenCaptureMode.Window)
		{
			bool flag = screenCaptureMode == ScreenCapturer.enmScreenCaptureMode.Screen;
			Rectangle bounds;
			if (flag)
			{
				bounds = Screen.GetBounds(Point.Empty);
				this.CursorPosition = Cursor.Position;
			}
			else
			{
				IntPtr foregroundWindow = ScreenCapturer.GetForegroundWindow();
				ScreenCapturer.Rect rect = default(ScreenCapturer.Rect);
				ScreenCapturer.GetWindowRect(foregroundWindow, ref rect);
				bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
				this.CursorPosition = new Point(Cursor.Position.X - rect.Left, Cursor.Position.Y - rect.Top);
			}
			Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
			}
			return bitmap;
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00006614 File Offset: 0x00004814
		// (set) Token: 0x0600004A RID: 74 RVA: 0x0000661C File Offset: 0x0000481C
		public Point CursorPosition { get; protected set; }

		// Token: 0x02000018 RID: 24
		public enum enmScreenCaptureMode
		{
			// Token: 0x04000103 RID: 259
			Screen,
			// Token: 0x04000104 RID: 260
			Window
		}

		// Token: 0x02000019 RID: 25
		private struct Rect
		{
			// Token: 0x04000105 RID: 261
			public int Left;

			// Token: 0x04000106 RID: 262
			public int Top;

			// Token: 0x04000107 RID: 263
			public int Right;

			// Token: 0x04000108 RID: 264
			public int Bottom;
		}
	}
}
