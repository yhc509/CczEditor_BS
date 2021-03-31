using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

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
    }
}
