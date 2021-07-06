using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Resources;
using Vestris.ResourceLib;

namespace CczEditor.Resources
{
    public class DllResources
    {
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResData);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "LoadLibraryExW")]
        internal static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, uint dwFlags);

        [DllImport("kernel32.dll", EntryPoint = "FindResourceExW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr FindResourceEx(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, UInt16 wLanguage);

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", EntryPoint = "BeginUpdateResourceW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr BeginUpdateResource(string pFileName, bool bDeleteExistingResources);

        [DllImport("kernel32.dll", EntryPoint = "UpdateResourceW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool UpdateResource(IntPtr hUpdate, IntPtr lpType, IntPtr lpName, UInt16 wLanguage, byte[] lpData, UInt32 cbData);

        [DllImport("kernel32.dll", EntryPoint = "EndUpdateResourceW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);

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
        
        protected static void SetImage(string filePath, IntPtr index, string bitmapPath)
        {
            if (string.IsNullOrEmpty(bitmapPath) || !File.Exists(bitmapPath))
            {
                return;
            }

            byte[] data = File.ReadAllBytes(bitmapPath);
            var _header = new Gdi32.BITMAPFILEHEADER();

            IntPtr pFileHeaderData = Marshal.AllocHGlobal(Marshal.SizeOf(_header));
            try
            {
                Marshal.Copy(data, 0, pFileHeaderData, Marshal.SizeOf(_header));
                _header = (Gdi32.BITMAPFILEHEADER)Marshal.PtrToStructure(
                    pFileHeaderData, typeof(Gdi32.BITMAPFILEHEADER));
            }
            finally
            {
                Marshal.FreeHGlobal(pFileHeaderData);
            }

            Int32 size = data.Length - Marshal.SizeOf(_header);
            byte[] bitmapData = new byte[size];
            Buffer.BlockCopy(data, Marshal.SizeOf(_header), bitmapData, 0, size);
            
            var type = new ResourceId(Kernel32.ResourceTypes.RT_BITMAP);
            ushort lang = 1041;
            var name = new ResourceId(index);

            IntPtr h = BeginUpdateResource(filePath, false);
            if (h == IntPtr.Zero)
                return;

            try
            {
                if (bitmapData != null && bitmapData.Length == 0)
                {
                    bitmapData = null;
                }
                if (!UpdateResource(h, type.Id, name.Id,
                    lang, bitmapData, (bitmapData == null ? 0 : (uint)bitmapData.Length)))
                {
                    return;
                }
            }
            catch
            {
                EndUpdateResource(h, true);
                throw;
            }

            if (!EndUpdateResource(h, false))
                return;
        }
    }
}
