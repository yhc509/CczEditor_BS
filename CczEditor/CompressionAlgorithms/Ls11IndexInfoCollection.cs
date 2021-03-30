#region using List

using System.Collections.Generic;

#endregion

namespace CczEditor.CompressionAlgorithms
{
	public class Ls11IndexInfoCollection : List<Ls11IndexInfo>
	{
		public bool IsCompression
		{
			get
			{
				var flag = false;
				foreach (var index in this)
				{
					if (flag)
					{
						break;
					}
					flag = index.IsCompression;
				}
				return flag;
			}
		}
	}
}