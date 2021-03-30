#region

using System;
using System.IO;

#endregion

namespace CczEditor.CompressionAlgorithms
{
	/// <summary>
	/// ls11压缩算法
	/// </summary>
	public class Ls11
	{
#pragma warning disable 0675
		protected int m_srcpos;
		protected int m_destpos;
		protected int m_bitpos;
		protected byte[] m_pDest;
		protected byte[] m_pSrc;

		protected const int DICT_OFFSET = 0x10;
		protected const int DICT_LEN = 0x100;
		protected const int INDEX_OFFSET = 0x110;

		/// <summary>
		/// 将源数据编码为ls11压缩格式
		/// </summary>
		/// <param name="pDict">编码用数据字典</param>
		/// <param name="pSrc">源数据缓冲</param>
		/// <param name="pDest">目标数据缓冲</param>
		/// <param name="nLenActual"></param>
		/// <param name="nLenSrc">源数据缓冲区大小</param>
		/// <param name="nLenDest">目标数据缓冲区大小</param>
		/// <param name="bCompress"></param>
		/// <returns></returns>
		protected int Encode(byte[] pDict, byte[] pSrc, byte[] pDest, int nLenActual, int nLenSrc, int nLenDest, bool bCompress)
		{
			int off, len, lenmax, offmax;
			var pNewDict = new byte[DICT_LEN];

			m_pDest = pDest;
			m_pSrc = pSrc;
			m_srcpos = 0;
			m_destpos = 0;
			m_bitpos = 0;

			ReorderDict(pDict, pNewDict, DICT_LEN);

			// If no compress needs to be taken, use dictionary only.
			if (!bCompress)
			{
				while (m_srcpos < nLenActual && m_destpos < nLenDest)
				{
					SetCode(pNewDict[m_pSrc[m_srcpos++]]);
				}
			}
			else
			{
				while (m_srcpos < nLenActual && m_destpos < nLenDest)
				{
					// Scan whole text
					for (off = 1, lenmax = 0, offmax = 1; off <= m_srcpos; off++)
					{
						for (len = 0; len+m_srcpos < nLenSrc && m_pSrc[m_srcpos-off+len] == m_pSrc[m_srcpos+len]; len++) {}
						if (len > lenmax)
						{
							lenmax = len;
							offmax = off;
						}
					}
					// Replace the duplicated string with two number: offmax + 256 and lenmax - 3
					if (lenmax >= 3)
					{
						SetCode((uint)(offmax+256));
						SetCode((uint)(lenmax-3));

						m_srcpos += lenmax;
					}
					else
					{
						SetCode(pNewDict[m_pSrc[m_srcpos++]]);
					}
				}
			}

			while (m_bitpos != 0)
			{
				m_pDest[m_destpos] <<= 1;
				m_bitpos++;
				if (m_bitpos > 7)
				{
					m_bitpos = 0;
					m_destpos++;
					break;
				}
			}

			return m_destpos;
		}

		protected int Decode(byte[] pDict, byte[] pSrc, byte[] pDest, int nLenActual, int nLenSrc, int nLenDest)
		{
			uint code, off, len;
			m_pSrc = pSrc;
			m_destpos = 0;
			m_srcpos = 0;
			m_bitpos = 7;

			while (m_srcpos < nLenSrc && m_destpos < nLenActual)
			{
				code = GetCode();
				if (code < 256)
				{
					pDest[m_destpos++] = pDict[code];
				}
				else
				{
					off = code-256;
					len = GetCode()+3;
					for (uint i = 0; i < len && m_destpos < nLenDest; i++)
					{
						pDest[m_destpos] = pDest[m_destpos-off];
						m_destpos++;
					}
				}
			}
			// Padding
			while (m_destpos < nLenActual)
			{
				pDest[m_destpos++] = pDict[0];
			}
			return m_destpos;
		}

		protected void SetCode(uint code)
		{
			uint temp, code1, code2;
			int len, i;
			temp = code;
			len = 0;
			code1 = 0;
			// How many valid bits are contained in variable code
			while (temp > 1)
			{
				temp >>= 1;
				code1 = (code1<<1)|0x01;
				len++;
			}
			if ((code1<<1) <= code)
			{
				len++;
				code1 = (uint)(code&(~1));
			}
			else
			{
				code1--;
			}

			code2 = code-code1;

			// Output bits of code1
			for (i = len-1; i >= 0; i--)
			{
				m_pDest[m_destpos] = (byte)((m_pDest[m_destpos]<<1)|(code1>>i));
				m_bitpos++;
				if (m_bitpos > 7)
				{
					m_bitpos = 0;
					m_destpos++;
				}
			}
			// Output bits of code2
			for (i = len-1; i >= 0; i--)
			{
				m_pDest[m_destpos] = (byte)((m_pDest[m_destpos]<<1)|(code2>>i));
				m_bitpos++;
				if (m_bitpos > 7)
				{
					m_bitpos = 0;
					m_destpos++;
				}
			}
		}

		protected uint GetCode()
		{
			uint code1 = 0, code2 = 0;
			int len = 0, bit;
			do
			{
				bit = (m_pSrc[m_srcpos]>>m_bitpos)&0x01;
				code1 = (uint)((code1<<1)|bit);
				len++;
				m_bitpos--;
				if (m_bitpos < 0)
				{
					m_bitpos = 7;
					m_srcpos++;
				}
			}
			while (bit != 0);
			for (var i = 0; i < len; i++)
			{
				bit = (m_pSrc[m_srcpos]>>m_bitpos)&0x01;
				code2 = (uint)((code2<<1)|bit);
				m_bitpos--;
				if (m_bitpos < 0)
				{
					m_bitpos = 7;
					m_srcpos++;
				}
			}

			return (code1+code2);
		}

		protected void ReorderDict(byte[] pDictSrc, byte[] pDictDest, int nLenDict)
		{
			for (var i = 0; i < nLenDict; i++)
			{
				for (var j = 0; j < nLenDict; j++)
				{
					if (pDictSrc[j] != i)
					{
						continue;
					}
					pDictDest[i] = (byte)j;
					break;
				}
			}
		}

		public static int Convert(int x)
		{
			return Convert(BitConverter.GetBytes(x));
		}

		public static int Convert(byte[] x)
		{
			var t = x[0];
			x[0] = x[3];
			x[3] = t;
			t = x[1];
			x[1] = x[2];
			x[2] = t;
			return BitConverter.ToInt32(x, 0);
		}

		public void Encode(string inputFileName, string outputFileName)
		{
			byte[] pDict, pSrc, pDest, temp;

			int length1, length2, inOffset, outOffset = 0, nLen;
			long iOffset;
			const int zero = 0;
			bool first = true;

			pDict = new byte[DICT_LEN];
			temp = new byte[4];

			using (var input = new FileStream(inputFileName, FileMode.Open))
			{
				using (var output = new FileStream(outputFileName, FileMode.Create))
				{
					input.Read(pDict, 0, 0x10);
					output.Write(pDict, 0, 0x10);

					input.Read(pDict, 0, DICT_LEN);
					output.Write(pDict, 0, DICT_LEN);

					iOffset = INDEX_OFFSET;
					nLen = 0;
					while (true)
					{
						input.Seek(iOffset, SeekOrigin.Begin);
						input.Read(temp, 0, 4);
						length1 = Convert(temp);
						if (length1 == zero)
						{
							output.Seek(iOffset, SeekOrigin.Begin);
							output.Write(BitConverter.GetBytes(zero), 0, 4);
							break;
						}
						pSrc = new byte[length1];
						input.Read(temp, 0, 4);
						length2 = Convert(temp);
						pDest = new byte[length2];
						input.Read(temp, 0, 4);
						inOffset = Convert(temp);
						iOffset = input.Position;
						if (first)
						{
							outOffset = inOffset;
							first = false;
						}
						else
						{
							outOffset += nLen;
						}
						input.Seek(inOffset, SeekOrigin.Begin);
						output.Seek(outOffset, SeekOrigin.Begin);
						if (length1 != length2)
						{
							input.Read(pSrc, 0, length1);
							pDest = pSrc;
							output.Write(pDest, 0, length2);
							nLen = length2;
							continue;
						}

						input.Read(pSrc, 0, length1);
						nLen = Encode(pDict, pSrc, pDest, length2, length1, length2, true);
						output.Write(pDest, 0, nLen);

						length1 = nLen;
						output.Seek(iOffset-12, SeekOrigin.Begin);
						temp = BitConverter.GetBytes(length1);
						temp = BitConverter.GetBytes(Convert(temp));
						output.Write(temp, 0, 4);
						temp = BitConverter.GetBytes(length2);
						temp = BitConverter.GetBytes(Convert(temp));
						output.Write(temp, 0, 4);
						temp = BitConverter.GetBytes(outOffset);
						temp = BitConverter.GetBytes(Convert(temp));
						output.Write(temp, 0, 4);
					}
				}
			}
		}

		public void Decode(Stream input)
		{
			if (input.CanRead && input.CanWrite)
			{
				byte[] pDict, pSrc, pDest, temp;

				int length1, length2, inOffset, outOffset = 0, nLen;
				long iOffset;
				const int zero = 0;
				bool first = true;

				pDict = new byte[DICT_LEN];
				temp = new byte[4];

				var output = new MemoryStream();
				input.Seek(0, SeekOrigin.Begin);
				output.Seek(0, SeekOrigin.Begin);
				input.Read(pDict, 0, 0x10);
				output.Write(pDict, 0, 0x10);

				input.Read(pDict, 0, DICT_LEN);
				output.Write(pDict, 0, DICT_LEN);

				iOffset = INDEX_OFFSET;
				nLen = 0;
				while (true)
				{
					input.Seek(iOffset, SeekOrigin.Begin);
					input.Read(temp, 0, 4);
					length1 = Convert(temp);
					if (length1 == zero)
					{
						output.Seek(iOffset, SeekOrigin.Begin);
						output.Write(BitConverter.GetBytes(zero), 0, 4);
						break;
					}
					pSrc = new byte[length1];
					input.Read(temp, 0, 4);
					length2 = Convert(temp);
					pDest = new byte[length2];
					input.Read(temp, 0, 4);
					inOffset = Convert(temp);
					iOffset = input.Position;
					if (first)
					{
						outOffset = inOffset;
						first = false;
					}
					else
					{
						outOffset += nLen;
					}
					input.Seek(inOffset, SeekOrigin.Begin);
					output.Seek(outOffset, SeekOrigin.Begin);
					if (length1 == length2)
					{
						input.Read(pSrc, 0, length1);
						pDest = pSrc;
						output.Write(pDest, 0, length2);
						nLen = length2;
						continue;
					}

					input.Read(pSrc, 0, length1);
					nLen = Decode(pDict, pSrc, pDest, length2, length1, length2);
					output.Write(pDest, 0, nLen);

					length1 = length2 = nLen;
					output.Seek(iOffset - 12, SeekOrigin.Begin);
					temp = BitConverter.GetBytes(length1);
					temp = BitConverter.GetBytes(Convert(temp));
					output.Write(temp, 0, 4);
					temp = BitConverter.GetBytes(length2);
					temp = BitConverter.GetBytes(Convert(temp));
					output.Write(temp, 0, 4);
					temp = BitConverter.GetBytes(outOffset);
					temp = BitConverter.GetBytes(Convert(temp));
					output.Write(temp, 0, 4);
				}
				input.Seek(0, SeekOrigin.Begin);
				output.Seek(0, SeekOrigin.Begin);
				output.WriteTo(input);
			}
		}

		public void Decode(string inputFileName, string outputFileName)
		{
			byte[] pDict, pSrc, pDest, temp;

			int length1, length2, inOffset, outOffset = 0, nLen;
			long iOffset;
			const int zero = 0;
			bool first = true;

			pDict = new byte[DICT_LEN];
			temp = new byte[4];

			using (var input = new FileStream(inputFileName, FileMode.Open))
			{
				using (var output = new FileStream(outputFileName, FileMode.Create))
				{
					input.Read(pDict, 0, 0x10);
					output.Write(pDict, 0, 0x10);

					input.Read(pDict, 0, DICT_LEN);
					output.Write(pDict, 0, DICT_LEN);

					iOffset = INDEX_OFFSET;
					nLen = 0;
					while (true)
					{
						input.Seek(iOffset, SeekOrigin.Begin);
						input.Read(temp, 0, 4);
						length1 = Convert(temp);
						if (length1 == zero)
						{
							output.Seek(iOffset, SeekOrigin.Begin);
							output.Write(BitConverter.GetBytes(zero), 0, 4);
							break;
						}
						pSrc = new byte[length1];
						input.Read(temp, 0, 4);
						length2 = Convert(temp);
						pDest = new byte[length2];
						input.Read(temp, 0, 4);
						inOffset = Convert(temp);
						iOffset = input.Position;
						if (first)
						{
							outOffset = inOffset;
							first = false;
						}
						else
						{
							outOffset += nLen;
						}
						input.Seek(inOffset, SeekOrigin.Begin);
						output.Seek(outOffset, SeekOrigin.Begin);
						if (length1 == length2)
						{
							input.Read(pSrc, 0, length1);
							pDest = pSrc;
							output.Write(pDest, 0, length2);
							nLen = length2;
							continue;
						}

						input.Read(pSrc, 0, length1);
						nLen = Decode(pDict, pSrc, pDest, length2, length1, length2);
						output.Write(pDest, 0, nLen);

						length1 = length2 = nLen;
						output.Seek(iOffset-12, SeekOrigin.Begin);
						temp = BitConverter.GetBytes(length1);
						temp = BitConverter.GetBytes(Convert(temp));
						output.Write(temp, 0, 4);
						temp = BitConverter.GetBytes(length2);
						temp = BitConverter.GetBytes(Convert(temp));
						output.Write(temp, 0, 4);
						temp = BitConverter.GetBytes(outOffset);
						temp = BitConverter.GetBytes(Convert(temp));
						output.Write(temp, 0, 4);
					}
				}
			}
		}
#pragma warning restore 0675
	}
}