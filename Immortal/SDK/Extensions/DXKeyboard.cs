using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Immortal.SDK.Extensions
{
	// Token: 0x0200000A RID: 10
	public class DXKeyboard
	{
		// Token: 0x06000035 RID: 53
		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint SendInput(uint nInputs, DXKeyboard.Input[] pInputs, int cbSize);

		// Token: 0x06000036 RID: 54
		[DllImport("user32.dll")]
		private static extern IntPtr GetMessageExtraInfo();

		// Token: 0x06000037 RID: 55 RVA: 0x00006268 File Offset: 0x00004468
		public static void SendKey(DXKeyboard.DirectXKeyStrokes key, bool KeyUp, DXKeyboard.InputType inputType)
		{
			uint dwFlags;
			if (KeyUp)
			{
				dwFlags = 10U;
			}
			else
			{
				dwFlags = 8U;
			}
			DXKeyboard.Input[] array = new DXKeyboard.Input[]
			{
				new DXKeyboard.Input
				{
					type = (int)inputType,
					u = new DXKeyboard.InputUnion
					{
						ki = new DXKeyboard.KeyboardInput
						{
							wVk = 0,
							wScan = (ushort)key,
							dwFlags = dwFlags,
							dwExtraInfo = DXKeyboard.GetMessageExtraInfo()
						}
					}
				}
			};
			DXKeyboard.SendInput((uint)array.Length, array, Marshal.SizeOf(typeof(DXKeyboard.Input)));
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00006308 File Offset: 0x00004508
		public static void SendKey(ushort key, bool KeyUp, DXKeyboard.InputType inputType)
		{
			uint dwFlags;
			if (KeyUp)
			{
				dwFlags = 10U;
			}
			else
			{
				dwFlags = 8U;
			}
			DXKeyboard.Input[] array = new DXKeyboard.Input[]
			{
				new DXKeyboard.Input
				{
					type = (int)inputType,
					u = new DXKeyboard.InputUnion
					{
						ki = new DXKeyboard.KeyboardInput
						{
							wVk = 0,
							wScan = key,
							dwFlags = dwFlags,
							dwExtraInfo = DXKeyboard.GetMessageExtraInfo()
						}
					}
				}
			};
			DXKeyboard.SendInput((uint)array.Length, array, Marshal.SizeOf(typeof(DXKeyboard.Input)));
		}

		// Token: 0x06000039 RID: 57
		[DllImport("user32.dll")]
		public static extern bool SetCursorPos(int X, int Y);

		// Token: 0x0600003A RID: 58
		[DllImport("user32.dll")]
		public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

		// Token: 0x0600003B RID: 59
		[DllImport("user32.dll")]
		private static extern short GetAsyncKeyState(Keys vKey);

		// Token: 0x0600003C RID: 60 RVA: 0x000063A4 File Offset: 0x000045A4
		public static bool IsKeyPushedDown(Keys vKey)
		{
			return ((int)DXKeyboard.GetAsyncKeyState(vKey) & 32768) != 0;
		}

		// Token: 0x0200000B RID: 11
		[Flags]
		public enum InputType
		{
			// Token: 0x04000043 RID: 67
			Mouse = 0,
			// Token: 0x04000044 RID: 68
			Keyboard = 1,
			// Token: 0x04000045 RID: 69
			Hardware = 2
		}

		// Token: 0x0200000C RID: 12
		[Flags]
		public enum KeyEventF
		{
			// Token: 0x04000047 RID: 71
			KeyDown = 0,
			// Token: 0x04000048 RID: 72
			ExtendedKey = 1,
			// Token: 0x04000049 RID: 73
			KeyUp = 2,
			// Token: 0x0400004A RID: 74
			Unicode = 4,
			// Token: 0x0400004B RID: 75
			Scancode = 8
		}

		// Token: 0x0200000D RID: 13
		public enum DirectXKeyStrokes
		{
			// Token: 0x0400004D RID: 77
			DIK_ESCAPE = 1,
			// Token: 0x0400004E RID: 78
			DIK_1,
			// Token: 0x0400004F RID: 79
			DIK_2,
			// Token: 0x04000050 RID: 80
			DIK_3,
			// Token: 0x04000051 RID: 81
			DIK_4,
			// Token: 0x04000052 RID: 82
			DIK_5,
			// Token: 0x04000053 RID: 83
			DIK_6,
			// Token: 0x04000054 RID: 84
			DIK_7,
			// Token: 0x04000055 RID: 85
			DIK_8,
			// Token: 0x04000056 RID: 86
			DIK_9,
			// Token: 0x04000057 RID: 87
			DIK_0,
			// Token: 0x04000058 RID: 88
			DIK_MINUS,
			// Token: 0x04000059 RID: 89
			DIK_EQUALS,
			// Token: 0x0400005A RID: 90
			DIK_BACK,
			// Token: 0x0400005B RID: 91
			DIK_TAB,
			// Token: 0x0400005C RID: 92
			DIK_Q,
			// Token: 0x0400005D RID: 93
			DIK_W,
			// Token: 0x0400005E RID: 94
			DIK_E,
			// Token: 0x0400005F RID: 95
			DIK_R,
			// Token: 0x04000060 RID: 96
			DIK_T,
			// Token: 0x04000061 RID: 97
			DIK_Y,
			// Token: 0x04000062 RID: 98
			DIK_U,
			// Token: 0x04000063 RID: 99
			DIK_I,
			// Token: 0x04000064 RID: 100
			DIK_O,
			// Token: 0x04000065 RID: 101
			DIK_P,
			// Token: 0x04000066 RID: 102
			DIK_LBRACKET,
			// Token: 0x04000067 RID: 103
			DIK_RBRACKET,
			// Token: 0x04000068 RID: 104
			DIK_RETURN,
			// Token: 0x04000069 RID: 105
			DIK_LCONTROL,
			// Token: 0x0400006A RID: 106
			DIK_A,
			// Token: 0x0400006B RID: 107
			DIK_S,
			// Token: 0x0400006C RID: 108
			DIK_D,
			// Token: 0x0400006D RID: 109
			DIK_F,
			// Token: 0x0400006E RID: 110
			DIK_G,
			// Token: 0x0400006F RID: 111
			DIK_H,
			// Token: 0x04000070 RID: 112
			DIK_J,
			// Token: 0x04000071 RID: 113
			DIK_K,
			// Token: 0x04000072 RID: 114
			DIK_L,
			// Token: 0x04000073 RID: 115
			DIK_SEMICOLON,
			// Token: 0x04000074 RID: 116
			DIK_APOSTROPHE,
			// Token: 0x04000075 RID: 117
			DIK_GRAVE,
			// Token: 0x04000076 RID: 118
			DIK_LSHIFT,
			// Token: 0x04000077 RID: 119
			DIK_BACKSLASH,
			// Token: 0x04000078 RID: 120
			DIK_Z,
			// Token: 0x04000079 RID: 121
			DIK_X,
			// Token: 0x0400007A RID: 122
			DIK_C,
			// Token: 0x0400007B RID: 123
			DIK_V,
			// Token: 0x0400007C RID: 124
			DIK_B,
			// Token: 0x0400007D RID: 125
			DIK_N,
			// Token: 0x0400007E RID: 126
			DIK_M,
			// Token: 0x0400007F RID: 127
			DIK_COMMA,
			// Token: 0x04000080 RID: 128
			DIK_PERIOD,
			// Token: 0x04000081 RID: 129
			DIK_SLASH,
			// Token: 0x04000082 RID: 130
			DIK_RSHIFT,
			// Token: 0x04000083 RID: 131
			DIK_MULTIPLY,
			// Token: 0x04000084 RID: 132
			DIK_LMENU,
			// Token: 0x04000085 RID: 133
			DIK_SPACE,
			// Token: 0x04000086 RID: 134
			DIK_CAPITAL,
			// Token: 0x04000087 RID: 135
			DIK_F1,
			// Token: 0x04000088 RID: 136
			DIK_F2,
			// Token: 0x04000089 RID: 137
			DIK_F3,
			// Token: 0x0400008A RID: 138
			DIK_F4,
			// Token: 0x0400008B RID: 139
			DIK_F5,
			// Token: 0x0400008C RID: 140
			DIK_F6,
			// Token: 0x0400008D RID: 141
			DIK_F7,
			// Token: 0x0400008E RID: 142
			DIK_F8,
			// Token: 0x0400008F RID: 143
			DIK_F9,
			// Token: 0x04000090 RID: 144
			DIK_F10,
			// Token: 0x04000091 RID: 145
			DIK_NUMLOCK,
			// Token: 0x04000092 RID: 146
			DIK_SCROLL,
			// Token: 0x04000093 RID: 147
			DIK_NUMPAD7,
			// Token: 0x04000094 RID: 148
			DIK_NUMPAD8,
			// Token: 0x04000095 RID: 149
			DIK_NUMPAD9,
			// Token: 0x04000096 RID: 150
			DIK_SUBTRACT,
			// Token: 0x04000097 RID: 151
			DIK_NUMPAD4,
			// Token: 0x04000098 RID: 152
			DIK_NUMPAD5,
			// Token: 0x04000099 RID: 153
			DIK_NUMPAD6,
			// Token: 0x0400009A RID: 154
			DIK_ADD,
			// Token: 0x0400009B RID: 155
			DIK_NUMPAD1,
			// Token: 0x0400009C RID: 156
			DIK_NUMPAD2,
			// Token: 0x0400009D RID: 157
			DIK_NUMPAD3,
			// Token: 0x0400009E RID: 158
			DIK_NUMPAD0,
			// Token: 0x0400009F RID: 159
			DIK_DECIMAL,
			// Token: 0x040000A0 RID: 160
			DIK_F11 = 87,
			// Token: 0x040000A1 RID: 161
			DIK_F12,
			// Token: 0x040000A2 RID: 162
			DIK_F13 = 100,
			// Token: 0x040000A3 RID: 163
			DIK_F14,
			// Token: 0x040000A4 RID: 164
			DIK_F15,
			// Token: 0x040000A5 RID: 165
			DIK_KANA = 112,
			// Token: 0x040000A6 RID: 166
			DIK_CONVERT = 121,
			// Token: 0x040000A7 RID: 167
			DIK_NOCONVERT = 123,
			// Token: 0x040000A8 RID: 168
			DIK_YEN = 125,
			// Token: 0x040000A9 RID: 169
			DIK_NUMPADEQUALS = 141,
			// Token: 0x040000AA RID: 170
			DIK_CIRCUMFLEX = 144,
			// Token: 0x040000AB RID: 171
			DIK_AT,
			// Token: 0x040000AC RID: 172
			DIK_COLON,
			// Token: 0x040000AD RID: 173
			DIK_UNDERLINE,
			// Token: 0x040000AE RID: 174
			DIK_KANJI,
			// Token: 0x040000AF RID: 175
			DIK_STOP,
			// Token: 0x040000B0 RID: 176
			DIK_AX,
			// Token: 0x040000B1 RID: 177
			DIK_UNLABELED,
			// Token: 0x040000B2 RID: 178
			DIK_NUMPADENTER = 156,
			// Token: 0x040000B3 RID: 179
			DIK_RCONTROL,
			// Token: 0x040000B4 RID: 180
			DIK_NUMPADCOMMA = 179,
			// Token: 0x040000B5 RID: 181
			DIK_DIVIDE = 181,
			// Token: 0x040000B6 RID: 182
			DIK_SYSRQ = 183,
			// Token: 0x040000B7 RID: 183
			DIK_RMENU,
			// Token: 0x040000B8 RID: 184
			DIK_HOME = 199,
			// Token: 0x040000B9 RID: 185
			DIK_UP,
			// Token: 0x040000BA RID: 186
			DIK_PRIOR,
			// Token: 0x040000BB RID: 187
			DIK_LEFT = 203,
			// Token: 0x040000BC RID: 188
			DIK_RIGHT = 205,
			// Token: 0x040000BD RID: 189
			DIK_END = 207,
			// Token: 0x040000BE RID: 190
			DIK_DOWN,
			// Token: 0x040000BF RID: 191
			DIK_NEXT,
			// Token: 0x040000C0 RID: 192
			DIK_INSERT,
			// Token: 0x040000C1 RID: 193
			DIK_DELETE,
			// Token: 0x040000C2 RID: 194
			DIK_LWIN = 219,
			// Token: 0x040000C3 RID: 195
			DIK_RWIN,
			// Token: 0x040000C4 RID: 196
			DIK_APPS,
			// Token: 0x040000C5 RID: 197
			DIK_BACKSPACE = 14,
			// Token: 0x040000C6 RID: 198
			DIK_NUMPADSTAR = 55,
			// Token: 0x040000C7 RID: 199
			DIK_LALT,
			// Token: 0x040000C8 RID: 200
			DIK_CAPSLOCK = 58,
			// Token: 0x040000C9 RID: 201
			DIK_NUMPADMINUS = 74,
			// Token: 0x040000CA RID: 202
			DIK_NUMPADPLUS = 78,
			// Token: 0x040000CB RID: 203
			DIK_NUMPADPERIOD = 83,
			// Token: 0x040000CC RID: 204
			DIK_NUMPADSLASH = 181,
			// Token: 0x040000CD RID: 205
			DIK_RALT = 184,
			// Token: 0x040000CE RID: 206
			DIK_UPARROW = 200,
			// Token: 0x040000CF RID: 207
			DIK_PGUP,
			// Token: 0x040000D0 RID: 208
			DIK_LEFTARROW = 203,
			// Token: 0x040000D1 RID: 209
			DIK_RIGHTARROW = 205,
			// Token: 0x040000D2 RID: 210
			DIK_DOWNARROW = 208,
			// Token: 0x040000D3 RID: 211
			DIK_PGDN,
			// Token: 0x040000D4 RID: 212
			DIK_LEFTMOUSEBUTTON = 256,
			// Token: 0x040000D5 RID: 213
			DIK_RIGHTMOUSEBUTTON,
			// Token: 0x040000D6 RID: 214
			DIK_MIDDLEWHEELBUTTON,
			// Token: 0x040000D7 RID: 215
			DIK_MOUSEBUTTON3,
			// Token: 0x040000D8 RID: 216
			DIK_MOUSEBUTTON4,
			// Token: 0x040000D9 RID: 217
			DIK_MOUSEBUTTON5,
			// Token: 0x040000DA RID: 218
			DIK_MOUSEBUTTON6,
			// Token: 0x040000DB RID: 219
			DIK_MOUSEBUTTON7,
			// Token: 0x040000DC RID: 220
			DIK_MOUSEWHEELUP,
			// Token: 0x040000DD RID: 221
			DIK_MOUSEWHEELDOWN
		}

		// Token: 0x0200000E RID: 14
		[Flags]
		public enum MouseEventFlags : uint
		{
			// Token: 0x040000DF RID: 223
			LEFTDOWN = 2U,
			// Token: 0x040000E0 RID: 224
			LEFTUP = 4U,
			// Token: 0x040000E1 RID: 225
			MIDDLEDOWN = 32U,
			// Token: 0x040000E2 RID: 226
			MIDDLEUP = 64U,
			// Token: 0x040000E3 RID: 227
			MOVE = 1U,
			// Token: 0x040000E4 RID: 228
			ABSOLUTE = 32768U,
			// Token: 0x040000E5 RID: 229
			RIGHTDOWN = 8U,
			// Token: 0x040000E6 RID: 230
			RIGHTUP = 16U,
			// Token: 0x040000E7 RID: 231
			WHEEL = 2048U,
			// Token: 0x040000E8 RID: 232
			XDOWN = 128U,
			// Token: 0x040000E9 RID: 233
			XUP = 256U
		}

		// Token: 0x0200000F RID: 15
		public enum MouseEventDataXButtons : uint
		{
			// Token: 0x040000EB RID: 235
			XBUTTON1 = 1U,
			// Token: 0x040000EC RID: 236
			XBUTTON2
		}

		// Token: 0x02000010 RID: 16
		public struct Input
		{
			// Token: 0x040000ED RID: 237
			public int type;

			// Token: 0x040000EE RID: 238
			public DXKeyboard.InputUnion u;
		}

		// Token: 0x02000011 RID: 17
		[StructLayout(LayoutKind.Explicit)]
		public struct InputUnion
		{
			// Token: 0x040000EF RID: 239
			[FieldOffset(0)]
			public readonly DXKeyboard.MouseInput mi;

			// Token: 0x040000F0 RID: 240
			[FieldOffset(0)]
			public DXKeyboard.KeyboardInput ki;

			// Token: 0x040000F1 RID: 241
			[FieldOffset(0)]
			public readonly DXKeyboard.HardwareInput hi;
		}

		// Token: 0x02000012 RID: 18
		public struct MouseInput
		{
			// Token: 0x040000F2 RID: 242
			public readonly int dx;

			// Token: 0x040000F3 RID: 243
			public readonly int dy;

			// Token: 0x040000F4 RID: 244
			public readonly uint mouseData;

			// Token: 0x040000F5 RID: 245
			public readonly uint dwFlags;

			// Token: 0x040000F6 RID: 246
			public readonly uint time;

			// Token: 0x040000F7 RID: 247
			public readonly IntPtr dwExtraInfo;
		}

		// Token: 0x02000013 RID: 19
		public struct KeyboardInput
		{
			// Token: 0x040000F8 RID: 248
			public ushort wVk;

			// Token: 0x040000F9 RID: 249
			public ushort wScan;

			// Token: 0x040000FA RID: 250
			public uint dwFlags;

			// Token: 0x040000FB RID: 251
			public readonly uint time;

			// Token: 0x040000FC RID: 252
			public IntPtr dwExtraInfo;
		}

		// Token: 0x02000014 RID: 20
		public struct HardwareInput
		{
			// Token: 0x040000FD RID: 253
			public readonly uint uMsg;

			// Token: 0x040000FE RID: 254
			public readonly ushort wParamL;

			// Token: 0x040000FF RID: 255
			public readonly ushort wParamH;
		}
	}
}
