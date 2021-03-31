using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

using CczEditor.CompressionAlgorithms;

namespace CczEditor.Resources
{
    public class JpgResources : Ls11
    {
        protected string FileName;

        public JpgResources(string fileName)
        {
            FileName = fileName;
        }

        public int GetLength()
        {
            return 0;
        }

        public Image GetImage(int index)
        {
            if (string.IsNullOrEmpty(FileName) || !File.Exists(FileName))
            {
                return null;
            }

            try
            {
                using (var fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Delete))
                {
                    var widthBinary = new byte[4];
                    var heightBinary = new byte[4];
                    var offsetBinary = new byte[4];

                    fs.Seek(0x110 + index * 0x0C, SeekOrigin.Begin);
                    fs.Read(widthBinary, 0, 4);
                    fs.Read(heightBinary, 0, 4);
                    fs.Read(offsetBinary, 0, 4);

                    var length = Convert(widthBinary);

                    var result = new byte[length];
                    var offset = Convert(offsetBinary);

                    fs.Seek(offset, SeekOrigin.Begin);
                    fs.Read(result, 0, length);

                    MemoryStream stream = new MemoryStream(result);
                    Bitmap bitmap = new Bitmap(stream);
                    bitmap.MakeTransparent(Color.FromArgb(247, 0, 255));
                    return bitmap;
                }
            } catch(Exception e)
            {
                return null;
            }
        }

        public bool Exists
        {
            get { return !string.IsNullOrEmpty(FileName) && File.Exists(FileName); }
        }
    }
}
