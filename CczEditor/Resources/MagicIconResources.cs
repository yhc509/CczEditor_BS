using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace CczEditor.Resources
{
    public class MagicIconResources : DllResources
    {

        public static Image Load(int index)
        {
            var filePath = Path.Combine(Program.CurrentConfig.DirectoryPath, "Mgcicon.dll");
            var result = GetImage(filePath, index);
            return result;
        }
    }
}
