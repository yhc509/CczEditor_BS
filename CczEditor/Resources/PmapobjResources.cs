#region using List

using System.Drawing;

#endregion

namespace CczEditor.Resources
{
	public class PmapobjResources : ImageResources
	{
		public PmapobjResources(string fileName)
			: base(fileName)
		{
			ImageWidth = 48;
			ImageHeight = 1280;
		}

		public new Image GetImage(int index)
		{
			return base.GetImage(index);
		}
        
        public Bitmap GetImageCrop(int index, int actionIndex)
        {

            var bitmap = new Bitmap(ImageWidth, ImageHeight);
            Rectangle rect = new Rectangle(0, actionIndex * 64, ImageWidth, 64);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(GetImage(index) as Bitmap, 0, 0, rect, GraphicsUnit.Pixel);
                return bitmap;
            }
        }
        
    }
}