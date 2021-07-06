using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Vestris.ResourceLib;

namespace CczEditor.Resources
{
    public class ItemIconResources : DllResources
    {

        public static Image Load(int index)
        {
            var filePath = Path.Combine(Program.CurrentConfig.DirectoryPath, "Itemicon.dll");
            var result = GetImage(filePath, index);
            return result;
        }

        public static void Save(int index, string bitmapPath)
        {
            var filePath = Path.Combine(Program.CurrentConfig.DirectoryPath, "Itemicon.dll");
            SetImage(filePath, new IntPtr(index), bitmapPath);
        }
    }
}
