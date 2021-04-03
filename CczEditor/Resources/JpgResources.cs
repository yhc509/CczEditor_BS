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


        public bool SetImage(int index, int width, int height, string ImageFile)
        {
            List<byte[]> numArrayList = new List<byte[]>();
            if (!string.IsNullOrEmpty(this.FileName) && File.Exists(this.FileName) && !string.IsNullOrEmpty(ImageFile))
            {
                if (File.Exists(ImageFile))
                {
                    try
                    {
                        using (FileStream fileStream1 = new FileStream(this.FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Delete))
                        {
                            var fileDict = new byte[256];
                            fileStream1.Seek(16L, SeekOrigin.Begin);
                            fileStream1.Read(fileDict, 0, 256);

                            int num1 = 0;
                            byte[] numArray1 = new byte[4];
                            fileStream1.Seek((long)(280 + 12 * num1), SeekOrigin.Begin);
                            fileStream1.Read(numArray1, 0, 4);
                            int num2 = Ls11.Convert(numArray1);
                            while (272 + 12 * num1 + 4 < num2)
                            {
                                if (index == num1)
                                {
                                    using (FileStream fileStream2 = new FileStream(ImageFile, FileMode.Open, FileAccess.Read, FileShare.Delete))
                                    {
                                        byte[] buffer1 = new byte[2];
                                        fileStream2.Seek(0L, SeekOrigin.Begin);
                                        fileStream2.Read(buffer1, 0, buffer1.Length);
                                        if (buffer1[0] == (byte)66 && buffer1[1] == (byte)77)
                                        {
                                            fileStream2.Seek(28L, SeekOrigin.Begin);
                                            fileStream2.Read(buffer1, 0, buffer1.Length);
                                            if (buffer1[0] == (byte)8)
                                            {
                                                fileStream2.Seek(24L, SeekOrigin.Begin);
                                                fileStream2.Read(buffer1, 0, buffer1.Length);
                                                bool flag = buffer1[0] == (byte)0;
                                                byte[] buffer2 = new byte[fileStream2.Length - 1078L];
                                                byte[] numArray2 = new byte[width];
                                                for (int imageHeight = height; imageHeight >= 1; --imageHeight)
                                                {
                                                    fileStream2.Seek((long)(1078 + (imageHeight - 1) * width), SeekOrigin.Begin);
                                                    if (flag)
                                                        fileStream2.Read(buffer2, (height - imageHeight) * width, numArray2.Length);
                                                    else
                                                        fileStream2.Read(buffer2, (imageHeight - 1) * width, numArray2.Length);
                                                }
                                                numArrayList.Add(buffer2);
                                            }
                                            else if (buffer1[0] == (byte)24)
                                            {
                                                byte[] buffer2 = new byte[fileStream2.Length];
                                                fileStream2.Seek(0L, SeekOrigin.Begin);
                                                fileStream2.Read(buffer2, 0, buffer2.Length);
                                                numArrayList.Add(buffer2);
                                            }
                                        }
                                        else
                                        {
                                            byte[] buffer2 = new byte[fileStream2.Length];
                                            fileStream2.Seek(0L, SeekOrigin.Begin);
                                            fileStream2.Read(buffer2, 0, buffer2.Length);
                                            numArrayList.Add(buffer2);
                                        }
                                    }
                                }
                                else
                                {
                                    fileStream1.Seek((long)(272 + 12 * num1), SeekOrigin.Begin);
                                    fileStream1.Read(numArray1, 0, 4);
                                    if (Ls11.Convert(numArray1) == 0)
                                    {
                                        ++num1;
                                        continue;
                                    }
                                    fileStream1.Read(numArray1, 0, 4);
                                    byte[] buffer = new byte[Ls11.Convert(numArray1)];
                                    fileStream1.Read(numArray1, 0, 4);
                                    int num3 = Ls11.Convert(numArray1);
                                    fileStream1.Seek((long)num3, SeekOrigin.Begin);
                                    fileStream1.Read(buffer, 0, buffer.Length);
                                    numArrayList.Add(buffer);
                                }
                                ++num1;
                            }
                            for (int index1 = 0; index1 < numArrayList.Count; ++index1)
                            {
                                int num3 = 272 + 12 * index1;
                                int length = numArrayList[index1].Length;
                                int num4;
                                if (index1 == 0)
                                {
                                    num4 = numArrayList.Count * 12 + 280;
                                }
                                else
                                {
                                    int num5 = 280 + 12 * (index1 - 1);
                                    fileStream1.Seek((long)num5, SeekOrigin.Begin);
                                    byte[] numArray2 = new byte[4];
                                    fileStream1.Read(numArray2, 0, numArray2.Length);
                                    num4 = Ls11.Convert(numArray2) + numArrayList[index1 - 1].Length;
                                }
                                byte[] numArray3 = new byte[4];
                                byte[] bytes1 = BitConverter.GetBytes(length);
                                Ls11.Convert(bytes1);
                                byte[] numArray4 = new byte[4];
                                byte[] bytes2 = BitConverter.GetBytes(num4);
                                Ls11.Convert(bytes2);
                                fileStream1.Seek((long)num3, SeekOrigin.Begin);
                                fileStream1.Write(bytes1, 0, bytes1.Length);
                                fileStream1.Write(bytes1, 0, bytes1.Length);
                                fileStream1.Write(bytes2, 0, bytes2.Length);
                            }
                            byte[] buffer3 = new byte[4];
                            fileStream1.Write(buffer3, 0, buffer3.Length);
                            for (int index1 = 0; index1 < numArrayList.Count; ++index1)
                            {
                                int num3 = index1 * 12 + 280;
                                byte[] numArray2 = new byte[4];
                                fileStream1.Seek((long)num3, SeekOrigin.Begin);
                                fileStream1.Read(numArray2, 0, 4);
                                int num4 = Ls11.Convert(numArray2);
                                fileStream1.Seek((long)num4, SeekOrigin.Begin);
                                fileStream1.Write(numArrayList[index1], 0, numArrayList[index1].Length);
                            }
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public bool Exists
        {
            get { return !string.IsNullOrEmpty(FileName) && File.Exists(FileName); }
        }
    }
}
