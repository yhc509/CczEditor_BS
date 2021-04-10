#region using List

using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

#endregion

namespace CczEditor
{
	public static class Utils
	{
		public static void HintUser(string message)
		{
			MessageBox.Show(message.Replace("\0", ""), "정보표시", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
        
		public static bool QuestionUser(string message)
		{
            return MessageBox.Show(message.Replace("\0", ""), "정보표시", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}
        
		public static void ShowError(string message)
		{
            MessageBox.Show(message.Replace("\0", ""), "정보표시", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void ChangeByteValue(byte[] o, byte[] n, int startIndex)
		{
			for (var i = 0; i < n.Length; i++)
			{
				o[startIndex++] = n[i];
			}
		}
        
		public static void ChangeByteValue(byte[] o, byte[] n, int startIndex, int copyCount)
		{
			var i = 0;
			for (; i < n.Length && i < copyCount; i++)
			{
				o[startIndex++] = n[i];
			}
			for (; i < copyCount; i++)
			{
				o[startIndex++] = 0;
			}
		}
        
		public static string ByteToString(byte[] p)
		{
			return Program.Encoder.GetString(p).TrimEnd('\0');
		}
        
		public static string ByteToString(byte[] p, int startIndex, int length)
		{
			return ByteToString(Program.Encoder, p, startIndex, length);
            
		}
        
		public static string ByteToString(Encoding encoding, byte[] p, int startIndex, int length)
		{
			return encoding.GetString(p, startIndex, length).TrimEnd('\0');
		}
        
		public static int GetId(object value)
		{
			if (value != null)
			{
				var item = value.ToString();
				return int.Parse(item.Substring(0, item.IndexOf(",")), NumberStyles.HexNumber);
			}
			return -1;
		}
        
		public static string GetString(object value)
		{
			if (value != null)
			{
				try
				{
					var item = value.ToString();
					return item.Split(',')[1];
				}
				catch (Exception)
				{
					return string.Empty;
				}
			}
			return string.Empty;
		}

		public static string GetString(byte value)
		{
			return GetString((int)value);
		}

		public static string GetString(short value)
		{
			return GetString((int)value);
		}

		public static string GetString(ushort value)
		{
			return GetString((int)value);
		}

		public static string GetString(int value)
		{
			return string.Format("{0:X2},", value);
		}

		public static byte[] GetBytes(string value)
		{
			return Program.Encoder.GetBytes(value);
		}

        public static byte[] GetCode(string codeValues)
        {
            string[] arr = codeValues.Split(' ');
            byte[] code = new byte[arr.Length];
            for(int i = 0; i < code.Length; i++)
            {
                code[i] = byte.Parse(arr[i], NumberStyles.HexNumber);
            }
            return code;
        }
	}
}