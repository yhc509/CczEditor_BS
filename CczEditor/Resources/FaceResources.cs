#region using List

using System.Drawing;

#endregion

namespace CczEditor.Resources
{
	public class FaceResources : JpgResources
	{
		public FaceResources(string fileName) : base(fileName)
		{
		}

		public new Image GetImage(int index)
		{
			return base.GetImage(index);
		}
	}
}