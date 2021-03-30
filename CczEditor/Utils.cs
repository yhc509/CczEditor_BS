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
		/// <summary>
		/// 정보표시
		/// </summary>
		/// <param name="message">信息</param>
		public static void HintUser(string message)
		{
			MessageBox.Show(message.Replace("\0", ""), "정보표시", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// 选择提示
		/// </summary>
		/// <param name="message">信息</param>
		/// <returns>点击的按钮</returns>
		public static bool QuestionUser(string message)
		{
            return MessageBox.Show(message.Replace("\0", ""), "정보표시", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}

		/// <summary>
		/// 错误提示
		/// </summary>
		/// <param name="message">信息</param>
		public static void ShowError(string message)
		{
            MessageBox.Show(message.Replace("\0", ""), "정보표시", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// 将目标字节数组下标从startIndex开始的数据更改为新数据数组中的数据
		/// </summary>
		/// <param name="o">目标数组</param>
		/// <param name="n">新数据数组</param>
		/// <param name="startIndex">起始下标</param>
		public static void ChangeByteValue(byte[] o, byte[] n, int startIndex)
		{
			for (var i = 0; i < n.Length; i++)
			{
				o[startIndex++] = n[i];
			}
		}

		/// <summary>
		/// 将目标字节数组下标从startIndex开始的数据更改为新数据数组中的数据
		/// </summary>
		/// <param name="o">目标数组</param>
		/// <param name="n">新数据数组</param>
		/// <param name="startIndex">起始下标</param>
		/// <param name="copyCount">复制总数</param>
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

		/// <summary>
		/// 将字节数组按特定编码转换为字符串
		/// </summary>
		/// <param name="p">字节数组</param>
		/// <returns>字符串</returns>
		public static string ByteToString(byte[] p)
		{
			return Program.Encoder.GetString(p).TrimEnd('\0');
		}

		/// <summary>
		/// 将字节数组从起始下标开始的指定字节按特定编码转换为字符串
		/// </summary>
		/// <param name="p">字节数组</param>
		/// <param name="startIndex">起始下标</param>
		/// <param name="length">所需转换的字节长度</param>
		/// <returns>字符串</returns>
		public static string ByteToString(byte[] p, int startIndex, int length)
		{
			return ByteToString(Program.Encoder, p, startIndex, length);
            
		}

		/// <summary>
		/// 将字节数组从起始下标开始的指定字节按特定编码转换为字符串
		/// </summary>
		/// <param name="encoding">编码器</param>
		/// <param name="p">字节数组</param>
		/// <param name="startIndex">起始下标</param>
		/// <param name="length">所需转换的字节长度</param>
		/// <returns>字符串</returns>
		public static string ByteToString(Encoding encoding, byte[] p, int startIndex, int length)
		{
			return encoding.GetString(p, startIndex, length).TrimEnd('\0');
		}

		/// <summary>
		/// 从参数中分解得到ID号,失败则返回-1
		/// </summary>
		/// <param name="value">包含ID的数据</param>
		/// <returns>ID</returns>
		public static int GetId(object value)
		{
			if (value != null)
			{
				var item = value.ToString();
				return int.Parse(item.Substring(0, item.IndexOf(",")), NumberStyles.HexNumber);
			}
			return -1;
		}

		/// <summary>
		/// 从参数中分解得到去除ID后的字符串
		/// </summary>
		/// <param name="value">包含ID的数据</param>
		/// <returns>去除ID后的字符串</returns>
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
	}
}