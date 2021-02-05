using System;
using System.Text;

namespace Immortal.SDK.Extensions
{
	// Token: 0x02000016 RID: 22
	public class RandomGenerator
	{
		// Token: 0x06000042 RID: 66 RVA: 0x000063FC File Offset: 0x000045FC
		public int RandomNumber(int min, int max)
		{
			return this._random.Next(min, max);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000641C File Offset: 0x0000461C
		public string RandomString(int size, bool lowerCase = false)
		{
			StringBuilder stringBuilder = new StringBuilder(size);
			char c = lowerCase ? 'a' : 'A';
			for (int i = 0; i < size; i++)
			{
				char value = (char)this._random.Next((int)c, (int)(c + '\u001a'));
				stringBuilder.Append(value);
			}
			return lowerCase ? stringBuilder.ToString().ToLower() : stringBuilder.ToString();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00006488 File Offset: 0x00004688
		public string RandomPassword()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(this.RandomString(4, true));
			stringBuilder.Append(this.RandomNumber(1000, 9999));
			stringBuilder.Append(this.RandomString(2, false));
			return stringBuilder.ToString();
		}

		// Token: 0x04000100 RID: 256
		private readonly Random _random = new Random();
	}
}
