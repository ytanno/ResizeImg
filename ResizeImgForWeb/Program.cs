using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace ResizeImgForWeb
{
	class Program
	{
		static void Main(string[] args)
		{
			var src = Environment.CurrentDirectory + @"\img\";
			var dst = Environment.CurrentDirectory + @"\dst\";

			if (!Directory.Exists(src)) Directory.CreateDirectory(src);
			if (!Directory.Exists(dst)) Directory.CreateDirectory(dst);

			int resizeWidth = 200;
			int resizeHeight = 150;
			var index = 1;
			foreach (var fi in new DirectoryInfo(src).GetFiles())
			{
				using (var bmp = new Bitmap(fi.FullName))
				using (var resize = new Bitmap(resizeWidth, resizeHeight))
				using (var g = Graphics.FromImage(resize))
				{
					g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
					//g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
					g.DrawImage(bmp, 0, 0, resizeWidth, resizeHeight);
					g.Dispose();

					var imgName = DateTime.Now.ToString("yyyy_MM_") + String.Format("{0:D2}", index) + ".png";
					resize.Save(dst + imgName, ImageFormat.Png);
					index++;
				}
			}





		}
	} 
}
