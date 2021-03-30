#region using List

using System;
using System.Drawing;
using System.Runtime.InteropServices;

#endregion

namespace CczEditor.Resources
{
	public class IconResources
	{
		#region APIs

		[DllImport("shell32.dll", EntryPoint = "ExtractIconA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern IntPtr ExtractIcon(int hInst, string lpszExeFileName, int nIconIndex);

		[DllImport("shell32.dll", CharSet = CharSet.Auto)]
		private static extern uint ExtractIconEx(string szFileName, int nIconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, uint nIcons);

		[DllImport("user32.dll", EntryPoint = "DestroyIcon", SetLastError = true)]
		private static extern unsafe int DestroyIcon(IntPtr hIcon);

		#endregion

		public static Icon ExtractIconFromFile(string fileName, int index)
		{
			return Icon.FromHandle(ExtractIcon(0, fileName, index));
		}

		public static Icon ExtractIconFromFile(string fileName, int index, bool isLarge)
		{
			unsafe
			{
				uint readIconCount;
				var hDummy = new IntPtr[1] { IntPtr.Zero };
				var hIconEx = new IntPtr[1] { IntPtr.Zero };

				try
				{
					readIconCount = isLarge ? ExtractIconEx(fileName, index, hIconEx, hDummy, 1) : ExtractIconEx(fileName, index, hDummy, hIconEx, 1);

					if (readIconCount >= 0 && hIconEx[0] != IntPtr.Zero)
					{
						return (Icon)Icon.FromHandle(hIconEx[0]).Clone();
					}
					else
					{
						return null;
					}
				}
				catch (Exception exc)
				{
					throw new ApplicationException("Could not extract icon", exc);
				}
				finally
				{
					foreach (var ptr in hIconEx)
					{
						if (ptr != IntPtr.Zero)
						{
							DestroyIcon(ptr);
						}
					}
					foreach (var ptr in hDummy)
					{
						if (ptr != IntPtr.Zero)
						{
							DestroyIcon(ptr);
						}
					}
				}
			}
		}
	}
}