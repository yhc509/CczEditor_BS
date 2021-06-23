using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CczEditor.Resources
{
    public class DllResources
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);
        
        protected static Image GetImage(string filePath, int index)
        {
            if(!File.Exists(filePath))
            {
                return null;
            }
            IntPtr libHandle = LoadLibrary(filePath);
            if (libHandle == IntPtr.Zero)
            {
                // failed
                var err = Marshal.GetLastWin32Error().ToString(); // returns 193
                Console.WriteLine(err);
                return null;
            }
            string bitmapName = string.Format("#{0}", index);
            Bitmap bitmap= null;
            try
            {
                bitmap = Bitmap.FromResource(libHandle, bitmapName);
            }
            catch(Exception e)
            {

            }
            finally
            {
                FreeLibrary(libHandle);
            }
            return bitmap;
        }
        
    }
}
