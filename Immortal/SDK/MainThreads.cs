using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Immortal.SDK.Extensions;

namespace Immortal.SDK
{
	// Token: 0x02000008 RID: 8
	internal class MainThreads
	{
		// Token: 0x0600002D RID: 45 RVA: 0x00005C20 File Offset: 0x00003E20
		public static void thTriggerBot()
		{
			DateTime now = DateTime.Now;
			for (;;)
			{
				Task.Delay(1);
				Thread.Sleep(20);
				bool flag = ProcessUtils.getForegroundProcess().ProcessName.Contains("VALORANT");
				if (flag)
				{
					bool triggerBot = MainThreads.TriggerBot;
					if (triggerBot)
					{
						Rectangle rect = new Rectangle(Screen.PrimaryScreen.Bounds.Width / 2 - MainThreads.TriggerbotCrossRadius, Screen.PrimaryScreen.Bounds.Height / 2 - MainThreads.TriggerbotCrossRadius, MainThreads.TriggerbotCrossRadius * 2, MainThreads.TriggerbotCrossRadius * 2);
						Point[] array = BitmapExtensions.PixelSearch(rect, Color.FromArgb(MainThreads.EnemyOutlineColor), 32);
						bool flag2 = array.Length != 0;
						if (flag2)
						{
							bool flag3 = DXKeyboard.IsKeyPushedDown(Keys.LButton);
							if (flag3)
							{
								DXKeyboard.mouse_event(4U, 0U, 0U, 0U, 0);
							}
							DXKeyboard.mouse_event(2U, 0U, 0U, 0U, 0);
							DXKeyboard.mouse_event(4U, 0U, 0U, 0U, 0);
							now = DateTime.Now;
							bool flag4 = MainThreads.TriggerBotShotDelay != 1;
							if (flag4)
							{
								Thread.Sleep(MainThreads.TriggerBotShotDelay);
							}
							Task.Delay(1);
						}
					}
					bool autoStop = MainThreads.AutoStop;
					if (autoStop)
					{
						bool flag5 = DXKeyboard.IsKeyPushedDown(Keys.LButton);
						if (flag5)
						{
							bool flag6 = DXKeyboard.IsKeyPushedDown(Keys.D);
							if (flag6)
							{
								DXKeyboard.SendKey(DXKeyboard.DirectXKeyStrokes.DIK_A, false, DXKeyboard.InputType.Keyboard);
								Thread.Sleep(60);
								DXKeyboard.SendKey(DXKeyboard.DirectXKeyStrokes.DIK_A, true, DXKeyboard.InputType.Keyboard);
							}
							else
							{
								bool flag7 = DXKeyboard.IsKeyPushedDown(Keys.A);
								if (flag7)
								{
									DXKeyboard.SendKey(DXKeyboard.DirectXKeyStrokes.DIK_D, false, DXKeyboard.InputType.Keyboard);
									Thread.Sleep(60);
									DXKeyboard.SendKey(DXKeyboard.DirectXKeyStrokes.DIK_D, true, DXKeyboard.InputType.Keyboard);
								}
							}
							bool flag8 = DXKeyboard.IsKeyPushedDown(Keys.W);
							if (flag8)
							{
								DXKeyboard.SendKey(DXKeyboard.DirectXKeyStrokes.DIK_S, false, DXKeyboard.InputType.Keyboard);
								Thread.Sleep(60);
								DXKeyboard.SendKey(DXKeyboard.DirectXKeyStrokes.DIK_S, true, DXKeyboard.InputType.Keyboard);
							}
							else
							{
								bool flag9 = DXKeyboard.IsKeyPushedDown(Keys.S);
								if (flag9)
								{
									DXKeyboard.SendKey(DXKeyboard.DirectXKeyStrokes.DIK_W, false, DXKeyboard.InputType.Keyboard);
									Thread.Sleep(60);
									DXKeyboard.SendKey(DXKeyboard.DirectXKeyStrokes.DIK_W, true, DXKeyboard.InputType.Keyboard);
								}
							}
							Thread.Sleep(10);
						}
					}
				}
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00005E1C File Offset: 0x0000401C
		public static void thBunnyHop()
		{
			for (;;)
			{
				Thread.Sleep(10);
				bool flag = ProcessUtils.getForegroundProcess().ProcessName.Contains("VALORANT");
				if (flag)
				{
					bool bunnyHop = MainThreads.BunnyHop;
					if (bunnyHop)
					{
						bool flag2 = DXKeyboard.IsKeyPushedDown(Keys.Space);
						if (flag2)
						{
							DXKeyboard.SendKey(DXKeyboard.DirectXKeyStrokes.DIK_SPACE, true, DXKeyboard.InputType.Keyboard);
							DXKeyboard.SendKey(DXKeyboard.DirectXKeyStrokes.DIK_SPACE, false, DXKeyboard.InputType.Keyboard);
						}
					}
				}
				Task.Delay(1);
				Thread.Sleep(MainThreads.BunnyHopDelay);
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00005E94 File Offset: 0x00004094
		public static void thAutopistol()
		{
			for (;;)
			{
				Thread.Sleep(10);
				bool flag = ProcessUtils.getForegroundProcess().ProcessName.Contains("VALORANT");
				if (flag)
				{
					bool flag2 = DXKeyboard.IsKeyPushedDown(MainThreads.AutoPistolKey);
					if (flag2)
					{
						DXKeyboard.mouse_event(4U, 0U, 0U, 0U, 0);
						Thread.Sleep(5);
						DXKeyboard.mouse_event(2U, 0U, 0U, 0U, 0);
						Thread.Sleep(5);
						DXKeyboard.mouse_event(4U, 0U, 0U, 0U, 0);
						bool flag3 = MainThreads.AutoPistolShotDelay != 1;
						if (flag3)
						{
							Thread.Sleep(MainThreads.AutoPistolShotDelay);
						}
					}
				}
				Task.Delay(1);
				Thread.Sleep(MainThreads.BunnyHopDelay);
			}
		}

		// Token: 0x04000035 RID: 53
		public static Thread thTriggerBotHandle = new Thread(new ThreadStart(MainThreads.thTriggerBot));

		// Token: 0x04000036 RID: 54
		public static Thread thBunnyHopHandle = new Thread(new ThreadStart(MainThreads.thBunnyHop));

		// Token: 0x04000037 RID: 55
		public static Thread thAutoPistolHandle = new Thread(new ThreadStart(MainThreads.thAutopistol));

		// Token: 0x04000038 RID: 56
		public static int EnemyOutlineColor = 11801877;

		// Token: 0x04000039 RID: 57
		public static bool TriggerBot = false;

		// Token: 0x0400003A RID: 58
		public static int TriggerbotCrossRadius = 20;

		// Token: 0x0400003B RID: 59
		public static int TriggerBotShotDelay = 1;

		// Token: 0x0400003C RID: 60
		public static bool BunnyHop = false;

		// Token: 0x0400003D RID: 61
		public static int BunnyHopDelay = 20;

		// Token: 0x0400003E RID: 62
		public static bool AutoStop = false;

		// Token: 0x0400003F RID: 63
		public static bool AutoPistol = false;

		// Token: 0x04000040 RID: 64
		public static int AutoPistolShotDelay = 1;

		// Token: 0x04000041 RID: 65
		public static Keys AutoPistolKey = Keys.MButton;
	}
}
