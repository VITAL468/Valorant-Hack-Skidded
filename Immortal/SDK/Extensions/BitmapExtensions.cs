using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;

namespace Immortal.SDK.Extensions
{
	// Token: 0x02000009 RID: 9
	internal class BitmapExtensions
	{
		// Token: 0x06000032 RID: 50 RVA: 0x00005FDC File Offset: 0x000041DC
		public static Bitmap CropImage(Image originalImage, Rectangle sourceRectangle, Rectangle? destinationRectangle = null)
		{
			bool flag = destinationRectangle == null;
			if (flag)
			{
				destinationRectangle = new Rectangle?(new Rectangle(Point.Empty, sourceRectangle.Size));
			}
			Bitmap bitmap = new Bitmap(destinationRectangle.Value.Width, destinationRectangle.Value.Height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.DrawImage(originalImage, destinationRectangle.Value, sourceRectangle, GraphicsUnit.Pixel);
			}
			return bitmap;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00006074 File Offset: 0x00004274
		public unsafe static Point[] PixelSearch(Rectangle rect, Color Pixel_Color, int Shade_Variation)
		{
			ArrayList arrayList = new ArrayList();
			Bitmap bitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppPArgb);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
			}
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			int[] array = new int[]
			{
				(int)Pixel_Color.B,
				(int)Pixel_Color.G,
				(int)Pixel_Color.R
			};
			for (int i = 0; i < bitmapData.Height; i++)
			{
				byte* ptr = (byte*)((void*)bitmapData.Scan0) + i * bitmapData.Stride;
				for (int j = 0; j < bitmapData.Width; j++)
				{
					bool flag = (int)ptr[j * 3] >= array[0] - Shade_Variation & (int)ptr[j * 3] <= array[0] + Shade_Variation;
					if (flag)
					{
						bool flag2 = (int)ptr[j * 3 + 1] >= array[1] - Shade_Variation & (int)ptr[j * 3 + 1] <= array[1] + Shade_Variation;
						if (flag2)
						{
							bool flag3 = (int)ptr[j * 3 + 2] >= array[2] - Shade_Variation & (int)ptr[j * 3 + 2] <= array[2] + Shade_Variation;
							if (flag3)
							{
								arrayList.Add(new Point(j + rect.X, i + rect.Y));
							}
						}
					}
				}
			}
			bitmap.Dispose();
			return (Point[])arrayList.ToArray(typeof(Point));
		}
	}
}
