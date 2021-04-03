#region using List

using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using CczEditor.CompressionAlgorithms;

#endregion

namespace CczEditor.Resources
{
	public class ImageResources : Ls11
	{
		protected string FileName;

		protected byte[] FileDict;

		protected int ImageWidth;

		protected int ImageHeight;

		protected byte[] BmpFileHeader = new byte[]
		                                 {
		                                 	0x42, 0x4D, 0x36, 0x18, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x04, 0x00, 0x00, 0x28, 0x00,
		                                 	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x08, 0x00, 0x00, 0x00,
		                                 	0x00, 0x00, 0x00, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
		                                 	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0xF7, 0x00, 0xFF, 0x00, 0xF7, 0x00, 0xFF, 0x00,
		                                 	0xF7, 0x00, 0xFF, 0x00, 0xF7, 0x00, 0xFF, 0x00, 0xF7, 0x00, 0xFF, 0x00, 0xF7, 0x00, 0xFF, 0x00,
		                                 	0xF7, 0x00, 0xFF, 0x00, 0xF7, 0x00, 0xFF, 0x00, 0xF7, 0x00, 0xFF, 0x00, 0xF7, 0x00, 0x63, 0x8C,
		                                 	0xFF, 0x00, 0x4A, 0x6B, 0xFF, 0x00, 0x39, 0x4A, 0xF7, 0x00, 0x29, 0x31, 0xAD, 0x00, 0x5A, 0xDE,
		                                 	0xFF, 0x00, 0x52, 0xCE, 0xFF, 0x00, 0x5A, 0xBD, 0xEF, 0x00, 0x52, 0x9C, 0xBD, 0x00, 0xFF, 0xFF,
		                                 	0xFF, 0x00, 0xEE, 0xEE, 0xEE, 0x00, 0xDD, 0xDD, 0xDD, 0x00, 0xCC, 0xCC, 0xCC, 0x00, 0xBB, 0xBB,
		                                 	0xBB, 0x00, 0xAA, 0xAA, 0xAA, 0x00, 0x99, 0x99, 0x99, 0x00, 0x88, 0x88, 0x88, 0x00, 0x77, 0x77,
		                                 	0x77, 0x00, 0x66, 0x66, 0x66, 0x00, 0x55, 0x55, 0x55, 0x00, 0x44, 0x44, 0x44, 0x00, 0x22, 0x22,
		                                 	0x22, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE1, 0xEF, 0xFD, 0x00, 0xB4, 0xD9, 0xFD, 0x00, 0x96, 0xCA,
		                                 	0xFE, 0x00, 0x69, 0xB3, 0xFE, 0x00, 0x2D, 0x95, 0xFF, 0x00, 0x00, 0x7F, 0xFF, 0x00, 0x00, 0x6E,
		                                 	0xFF, 0x00, 0x00, 0x4C, 0xFF, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00, 0x00, 0xE7, 0x00, 0x00, 0x00,
		                                 	0xC3, 0x00, 0x00, 0x00, 0xB7, 0x00, 0x00, 0x00, 0x9E, 0x00, 0x00, 0x00, 0x86, 0x00, 0x00, 0x00,
		                                 	0x6E, 0x00, 0x00, 0x00, 0x4A, 0x00, 0xFD, 0xFD, 0xD2, 0x00, 0xFD, 0xFD, 0xB4, 0x00, 0xFD, 0xFE,
		                                 	0x96, 0x00, 0xFD, 0xFE, 0x69, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0xFF, 0xDD, 0x00, 0x00, 0xFF, 0xBB,
		                                 	0x00, 0x00, 0xFF, 0x99, 0x00, 0x00, 0xFF, 0x77, 0x00, 0x00, 0xFF, 0x55, 0x00, 0x00, 0xFF, 0x00,
		                                 	0x00, 0x00, 0xE7, 0x00, 0x00, 0x00, 0xC3, 0x00, 0x00, 0x00, 0xAB, 0x00, 0x00, 0x00, 0x7A, 0x00,
		                                 	0x00, 0x00, 0x56, 0x00, 0x00, 0x00, 0xE1, 0xFD, 0xFD, 0x00, 0xB4, 0xFD, 0xFD, 0x00, 0x87, 0xFE,
		                                 	0xFE, 0x00, 0x5A, 0xFE, 0xFE, 0x00, 0x2D, 0xFF, 0xFF, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0xED,
		                                 	0xED, 0x00, 0x00, 0xDB, 0xDB, 0x00, 0x00, 0xC9, 0xC9, 0x00, 0x00, 0xB2, 0xB2, 0x00, 0x00, 0x9F,
		                                 	0x9F, 0x00, 0x00, 0x8B, 0x8B, 0x00, 0x00, 0x78, 0x78, 0x00, 0x00, 0x65, 0x65, 0x00, 0x00, 0x51,
		                                 	0x51, 0x00, 0x00, 0x3E, 0x3E, 0x00, 0xE1, 0xFD, 0xE1, 0x00, 0xC1, 0xFD, 0xC1, 0x00, 0xA1, 0xFE,
		                                 	0xA1, 0x00, 0x81, 0xFE, 0x81, 0x00, 0x60, 0xFE, 0x60, 0x00, 0x00, 0xFF, 0x00, 0x00, 0x00, 0xED,
		                                 	0x00, 0x00, 0x00, 0xDB, 0x00, 0x00, 0x00, 0xC9, 0x00, 0x00, 0x00, 0xB7, 0x00, 0x00, 0x00, 0xA5,
		                                 	0x00, 0x00, 0x00, 0x92, 0x00, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x6E, 0x00, 0x00, 0x00, 0x5C,
		                                 	0x00, 0x00, 0x00, 0x4A, 0x00, 0x00, 0x6E, 0x89, 0xAE, 0x00, 0x5E, 0x76, 0x98, 0x00, 0x48, 0x62,
		                                 	0x75, 0x00, 0x3F, 0x52, 0x64, 0x00, 0x36, 0x40, 0x4B, 0x00, 0x1E, 0x25, 0x2E, 0x00, 0xA5, 0xCE,
		                                 	0xE7, 0x00, 0x88, 0xC3, 0xEE, 0x00, 0x72, 0xAD, 0xE1, 0x00, 0x73, 0xA2, 0xD9, 0x00, 0x6C, 0x9A,
		                                 	0xCE, 0x00, 0xBD, 0xD6, 0xE7, 0x00, 0xB8, 0xD1, 0xE9, 0x00, 0xA5, 0xC6, 0xE7, 0x00, 0x94, 0xBD,
		                                 	0xDE, 0x00, 0x84, 0xB5, 0xDE, 0x00, 0xFD, 0xE1, 0xF7, 0x00, 0xE6, 0xC1, 0xDE, 0x00, 0xCE, 0xA1,
		                                 	0xC4, 0x00, 0xB7, 0x81, 0xAB, 0x00, 0x9F, 0x61, 0x92, 0x00, 0x88, 0x41, 0x79, 0x00, 0x70, 0x21,
		                                 	0x5F, 0x00, 0x59, 0x01, 0x46, 0x00, 0xFD, 0xE1, 0xFD, 0x00, 0xFE, 0xA9, 0xFE, 0x00, 0xFD, 0x86,
		                                 	0xFD, 0x00, 0xFF, 0x6A, 0xFF, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0xE8, 0x17, 0xE8, 0x00, 0xD1, 0x14,
		                                 	0xD1, 0x00, 0xBA, 0x12, 0xBA, 0x00, 0xCE, 0xF0, 0xF8, 0x00, 0xAB, 0xD0, 0xD9, 0x00, 0x88, 0xB0,
		                                 	0xBA, 0x00, 0x65, 0x90, 0x9B, 0x00, 0x55, 0x7F, 0x8A, 0x00, 0x45, 0x6F, 0x7A, 0x00, 0x34, 0x5E,
		                                 	0x69, 0x00, 0x24, 0x4D, 0x58, 0x00, 0xF2, 0xDE, 0xAB, 0x00, 0xCD, 0xB9, 0x85, 0x00, 0xA9, 0x93,
		                                 	0x5E, 0x00, 0x84, 0x6E, 0x38, 0x00, 0x77, 0x63, 0x30, 0x00, 0x6B, 0x57, 0x28, 0x00, 0x5E, 0x4C,
		                                 	0x20, 0x00, 0x51, 0x40, 0x18, 0x00, 0x80, 0xC3, 0x80, 0x00, 0x70, 0xB4, 0x70, 0x00, 0x61, 0xA5,
		                                 	0x61, 0x00, 0x51, 0x96, 0x51, 0x00, 0x41, 0x88, 0x41, 0x00, 0x31, 0x79, 0x31, 0x00, 0x22, 0x6A,
		                                 	0x22, 0x00, 0x12, 0x5B, 0x12, 0x00, 0x5D, 0x92, 0xBA, 0x00, 0x50, 0x84, 0xAB, 0x00, 0x44, 0x76,
		                                 	0x9D, 0x00, 0x37, 0x68, 0x8E, 0x00, 0x2A, 0x5B, 0x80, 0x00, 0x1D, 0x4D, 0x71, 0x00, 0x11, 0x3F,
		                                 	0x63, 0x00, 0x04, 0x31, 0x54, 0x00, 0x29, 0xC6, 0xBD, 0x00, 0x29, 0xBD, 0xAD, 0x00, 0x4A, 0xAD,
		                                 	0xAD, 0x00, 0x31, 0xAD, 0x94, 0x00, 0x31, 0x9C, 0x8C, 0x00, 0x31, 0x94, 0x73, 0x00, 0x31, 0x84,
		                                 	0x73, 0x00, 0x31, 0x7B, 0x63, 0x00, 0xBF, 0xA0, 0x22, 0x00, 0xAE, 0x80, 0x1A, 0x00, 0x9D, 0x60,
		                                 	0x11, 0x00, 0x8C, 0x3F, 0x09, 0x00, 0x7B, 0x1F, 0x00, 0x00, 0x02, 0x55, 0xC2, 0x00, 0x36, 0xAC,
		                                 	0xFF, 0x00, 0x21, 0x63, 0xE7, 0x00, 0x18, 0x42, 0xD6, 0x00, 0x18, 0x42, 0xAD, 0x00, 0x10, 0x31,
		                                 	0x8C, 0x00, 0x1F, 0x24, 0x2A, 0x00, 0x58, 0x01, 0x44, 0x00, 0x00, 0x01, 0x3A, 0x00, 0x00, 0x00,
		                                 	0x6F, 0x00, 0x0E, 0x38, 0x1F, 0x00, 0x0F, 0x42, 0x28, 0x00, 0x10, 0x4A, 0x2D, 0x00, 0x05, 0x30,
		                                 	0x54, 0x00, 0x12, 0x3F, 0x62, 0x00, 0x13, 0x50, 0x31, 0x00, 0x38, 0x3F, 0x4A, 0x00, 0x13, 0x56,
		                                 	0x35, 0x00, 0x14, 0x53, 0x33, 0x00, 0x16, 0x5D, 0x3A, 0x00, 0x15, 0x5A, 0x37, 0x00, 0x19, 0x63,
		                                 	0x3E, 0x00, 0x17, 0x61, 0x3D, 0x00, 0x1A, 0x65, 0x40, 0x00, 0x1A, 0x68, 0x42, 0x00, 0x3A, 0x5F,
		                                 	0x3C, 0x00, 0x1B, 0x6C, 0x45, 0x00, 0x14, 0x63, 0x4B, 0x00, 0x32, 0x50, 0x5C, 0x00, 0x1E, 0x4C,
		                                 	0x71, 0x00, 0x60, 0x6E, 0x44, 0x00, 0x55, 0x64, 0x3E, 0x00, 0x59, 0x68, 0x42, 0x00, 0x60, 0x71,
		                                 	0x49, 0x00, 0x4E, 0x6B, 0x4B, 0x00, 0x14, 0x69, 0x51, 0x00, 0x14, 0x6D, 0x54, 0x00, 0x16, 0x70,
		                                 	0x57, 0x00, 0x1D, 0x70, 0x47, 0x00, 0x15, 0x73, 0x59, 0x00, 0x2B, 0x5A, 0x7F, 0x00, 0x43, 0x71,
		                                 	0x4F, 0x00, 0x18, 0x75, 0x5C, 0x00, 0x37, 0x61, 0x6A, 0x00, 0x19, 0x78, 0x5D, 0x00, 0x6B, 0x78,
		                                 	0x47, 0x00, 0x63, 0x74, 0x4C, 0x00, 0x67, 0x78, 0x51, 0x00, 0x56, 0x74, 0x53, 0x00, 0x3D, 0x78,
		                                 	0x58, 0x00, 0x59, 0x6F, 0x55, 0x00, 0x63, 0x7A, 0x5A, 0x00, 0x6E, 0x7F, 0x56, 0x00, 0x19, 0x7B,
		                                 	0x60, 0x00, 0x19, 0x81, 0x65, 0x00, 0x1B, 0x85, 0x68, 0x00, 0x38, 0x67, 0x8E, 0x00, 0x1B, 0x7E,
		                                 	0x63, 0x00, 0x30, 0x72, 0x6D, 0x00, 0x26, 0x7D, 0x6C, 0x00, 0x59, 0x76, 0x5C, 0x00, 0x34, 0x7D,
		                                 	0x77, 0x00, 0x5B, 0x7C, 0x6A, 0x00, 0x3A, 0x76, 0x77, 0x00, 0x41, 0x7D, 0x81, 0x00, 0x74, 0x86,
		                                 	0x5C, 0x00, 0x60, 0x82, 0x73, 0x00, 0x47, 0x75, 0x9C, 0x00, 0x4D, 0x83, 0x8B, 0x00, 0x55, 0x84,
		                                 	0xAA, 0x00, 0x53, 0x9A, 0xBB, 0x00, 0x76, 0x9F, 0xCA, 0x00, 0x74, 0xB9, 0xE1, 0x00, 0xFF, 0x00,
		                                 	0xF7, 0x00, 0xFF, 0x00, 0xF7, 0x00, 0xFF, 0x00, 0xF7, 0x00, 0xFF, 0x00, 0xF7, 0x00, 0xFF, 0x00,
		                                 	0xF7, 0x00, 0xFF, 0x00, 0xF7, 0x00, 0xFF, 0x00, 0xF7, 0x00, 0xFF, 0x00, 0xF7, 0x00, 0xFF, 0x00,
		                                 	0xF7, 0x00, 0xFF, 0x00, 0xF7, 0x00
		                                 };

		protected ImageResources(string fileName)
		{
			FileName = fileName;
			if (string.IsNullOrEmpty(FileName) || !File.Exists(FileName))
			{
				return;
			}
			try
			{
				using (var fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Delete))
				{
					FileDict = new byte[DICT_LEN];
					fs.Seek(DICT_OFFSET, SeekOrigin.Begin);
					fs.Read(FileDict, 0, DICT_LEN);
				}
			}
			catch (Exception)
			{
				return;
			}
		}

		public int GetLength()
		{
			if (string.IsNullOrEmpty(FileName) || !File.Exists(FileName) || BmpFileHeader == null)
			{
				return 0;
			}
			try
			{
				using (var fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Delete))
				{
					int length = 0, length1;
					var temp = new byte[4];
					while (true)
					{
						fs.Seek(INDEX_OFFSET+length*0xC, SeekOrigin.Begin);
						fs.Read(temp, 0, 4);
						length1 = Convert(temp);
						if (length1 == 0)
						{
							break;
						}
						length++;
					}
					return length;
				}
			}
			catch (Exception)
			{
				return 0;
			}
		}
        /*
		public Image GetImage(int index)
		{
			Utils.ChangeByteValue(BmpFileHeader, BitConverter.GetBytes(ImageWidth), 0x12);
			Utils.ChangeByteValue(BmpFileHeader, BitConverter.GetBytes(-(ImageHeight)), 0x16);
			if (string.IsNullOrEmpty(FileName) || !File.Exists(FileName) || BmpFileHeader == null)
			{
				return null;
			}
			try
			{
				using (var fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Delete))
				{
					if (FileDict == null)
					{
						FileDict = new byte[DICT_LEN];
						fs.Seek(DICT_OFFSET, SeekOrigin.Begin);
						fs.Read(FileDict, 0, DICT_LEN);
					}
					var temp = new byte[4];
					fs.Seek(INDEX_OFFSET+0xC*index, SeekOrigin.Begin);
					fs.Read(temp, 0, 4);
					var length1 = Convert(temp);
					if (length1 == 0)
					{
						return null;
					}
					fs.Read(temp, 0, 4);
					var length2 = Convert(temp);
					fs.Read(temp, 0, 4);
					var offset = Convert(temp);
					var fileLength = BmpFileHeader.Length+length2;
					var data = new byte[fileLength];
					BmpFileHeader.CopyTo(data, 0);
					if (offset >= fs.Length)
					{
						return null;
					}
					fs.Seek(offset, SeekOrigin.Begin);
					var body = new byte[length2];
					if (length1 == length2)
					{
						fs.Read(body, 0, length2);
					}
					else
					{
						var tBody = new byte[length1];
						fs.Read(tBody, 0, length1);
						Decode(FileDict, tBody, body, length2, length1, length2);
					}
					body.CopyTo(data, BmpFileHeader.Length);
					var img = new Bitmap(new MemoryStream(data));
					img.MakeTransparent(Color.FromArgb(247, 0, 255));
					return img;
				}
			}
			catch (Exception)
			{
				return null;
			}
		}
        */

        public Image GetImage(int index)
        {
            if (!string.IsNullOrEmpty(this.FileName))
            {
                if (File.Exists(this.FileName))
                {
                    try
                    {
                        using (FileStream fileStream = new FileStream(this.FileName, FileMode.Open, FileAccess.Read, FileShare.Delete))
                        {
                            if (this.FileDict == null)
                            {
                                this.FileDict = new byte[256];
                                fileStream.Seek(16L, SeekOrigin.Begin);
                                fileStream.Read(this.FileDict, 0, 256);
                            }
                            byte[] numArray1 = new byte[4];
                            fileStream.Seek((long)(272 + 12 * index), SeekOrigin.Begin);
                            fileStream.Read(numArray1, 0, 4);
                            int length1 = Ls11.Convert(numArray1);
                            if (length1 == 0)
                                return (Image)null;
                            fileStream.Read(numArray1, 0, 4);
                            int length2 = Ls11.Convert(numArray1);
                            fileStream.Read(numArray1, 0, 4);
                            int num = Ls11.Convert(numArray1);
                            byte[] buffer = new byte[length2];
                            fileStream.Seek((long)num, SeekOrigin.Begin);
                            byte[] numArray2 = new byte[length2];
                            if (length1 == length2)
                            {
                                fileStream.Read(numArray2, 0, length2);
                            }
                            else
                            {
                                byte[] numArray3 = new byte[length1];
                                fileStream.Read(numArray3, 0, length1);
                                this.Decode(this.FileDict, numArray3, numArray2, length2, length1, length2);
                            }
                            numArray2.CopyTo((Array)buffer, 0);
                            if (buffer[0] != byte.MaxValue && buffer[0] != (byte)66)
                            {
                                Utils.ChangeByteValue(this.BmpFileHeader, BitConverter.GetBytes(this.ImageWidth), 18);
                                Utils.ChangeByteValue(this.BmpFileHeader, BitConverter.GetBytes(-this.ImageHeight), 22);
                                buffer = new byte[this.BmpFileHeader.Length + length2];
                                this.BmpFileHeader.CopyTo((Array)buffer, 0);
                                if ((long)num >= fileStream.Length)
                                    return (Image)null;
                                fileStream.Seek((long)num, SeekOrigin.Begin);
                                byte[] numArray3 = new byte[length2];
                                if (length1 == length2)
                                {
                                    fileStream.Read(numArray3, 0, length2);
                                }
                                else
                                {
                                    byte[] numArray4 = new byte[length1];
                                    fileStream.Read(numArray4, 0, length1);
                                    this.Decode(this.FileDict, numArray4, numArray3, length2, length1, length2);
                                }
                                numArray3.CopyTo((Array)buffer, this.BmpFileHeader.Length);
                            }
                            Bitmap bitmap = new Bitmap((Stream)new MemoryStream(buffer));
                            bitmap.MakeTransparent(Color.FromArgb(247, 0, (int)byte.MaxValue));
                            return (Image)bitmap;
                        }
                    }
                    catch (Exception ex)
                    {
                        return (Image)null;
                    }
                }
            }
            return (Image)null;
        }

        public bool SetImage(int index, string ImageFile)
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
                            if (this.FileDict == null)
                            {
                                this.FileDict = new byte[256];
                                fileStream1.Seek(16L, SeekOrigin.Begin);
                                fileStream1.Read(this.FileDict, 0, 256);
                            }
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
                                                byte[] numArray2 = new byte[this.ImageWidth];
                                                for (int imageHeight = this.ImageHeight; imageHeight >= 1; --imageHeight)
                                                {
                                                    fileStream2.Seek((long)(1078 + (imageHeight - 1) * this.ImageWidth), SeekOrigin.Begin);
                                                    if (flag)
                                                        fileStream2.Read(buffer2, (this.ImageHeight - imageHeight) * this.ImageWidth, numArray2.Length);
                                                    else
                                                        fileStream2.Read(buffer2, (imageHeight - 1) * this.ImageWidth, numArray2.Length);
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