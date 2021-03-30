#region

using System.Collections.Generic;
using System.IO;

#endregion

namespace CczEditor.Data
{
	public class ImsgData : FileData
	{
		public const int IMSG_DATA_BLOCK_LENGTH = Program.IMSG_DATA_BLOCK_LENGTH;
		public const int IMSG_STAGE_NAME_LENGTH = Program.IMSG_STAGE_NAME_LENGTH;
		public const int IMSG_RETREAT_COUNT = Program.IMSG_RETREAT_COUNT;
		public const int IMSG_CRITICAL_COUNT = Program.IMSG_CRITICAL_COUNT;
		public const int IMSG_STAFF_COUNT = Program.IMSG_STAFF_COUNT;

		public ImsgData(string fileName) : base(fileName) { }

		public byte[] UnitOriginalGet(int index)
		{
			var offset = Program.CurrentConfig.Imsg.UnitOriginalOffset;
            var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void UnitOriginalSet(int index, byte[] value)
		{
			var offset = Program.CurrentConfig.Imsg.UnitOriginalOffset;
            CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}

		public byte[] UnitExtensionGet(int index)
		{
			var offset = Program.CurrentConfig.Imsg.UnitExtensionOffset;
            var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void UnitExtensionSet(int index, byte[] value)
		{
			var offset = Program.CurrentConfig.Imsg.UnitExtensionOffset;
            CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}

		public byte[] ItemGet(int index)
		{
			var offset = Program.CurrentConfig.Imsg.ItemOffset;
            var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
            CurrentStream.Seek(offset + index * IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
            CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void ItemSet(int index, byte[] value)
		{
            var offset = Program.CurrentConfig.Imsg.ItemOffset;
            CurrentStream.Seek(offset + index * IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
            CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}

		public byte[] MagicGet(int index)
		{
			var offset = Program.CurrentConfig.Imsg.MagicOffset;
            var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void MagicSet(int index, byte[] value)
		{
			var offset = Program.CurrentConfig.Imsg.MagicOffset;
            CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}

		public List<string> StageNameList(bool hasFormater)
		{
			var count = Program.CurrentConfig.Imsg.StageCount;
            var offset = Program.CurrentConfig.Imsg.StageOffset;
            var list = new List<string>();
			var text = new byte[IMSG_STAGE_NAME_LENGTH];
			for (var i = 0; i < count; i++)
			{
				CurrentStream.Seek(offset+i*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
				CurrentStream.Read(text, 0, IMSG_STAGE_NAME_LENGTH);
				list.Add(hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_DEC2, i, Utils.ByteToString(text)) : Utils.ByteToString(text));
			}
			return list;
		}

		public byte[] StageGet(int index)
		{
			var offset = Program.CurrentConfig.Imsg.StageOffset;
            var msg = new byte[IMSG_STAGE_NAME_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_STAGE_NAME_LENGTH);
			return msg;
		}

		public void StageSet(int index, byte[] value)
		{
			var offset = Program.CurrentConfig.Imsg.StageOffset;
            CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_STAGE_NAME_LENGTH);
		}

		public byte[] ForceGet(int index)
		{
			var offset = Program.CurrentConfig.Imsg.ForceOffset;
            var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void ForceSet(int index, byte[] value)
		{
            var offset = Program.CurrentConfig.Imsg.ForceOffset;
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}

		public List<string> RetreatNameList(bool hasFormater)
		{
			var offset = Program.CurrentConfig.Imsg.RetreatOffset;
            var list = new List<string>();
			var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			for (var i = 0; i < IMSG_RETREAT_COUNT; i++)
			{
				CurrentStream.Seek(offset+i*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
				CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
				list.Add(hasFormater ? string.Format("{0:D2},{1}", i, Utils.ByteToString(msg)) : Utils.ByteToString(msg));
			}
			return list;
		}

		public byte[] RetreatGet(int index)
		{
            var offset = Program.CurrentConfig.Imsg.RetreatOffset;
			var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void RetreatSet(int index, byte[] value)
		{
			var offset = Program.CurrentConfig.Imsg.RetreatOffset;
            CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}

		public List<string> CriticalNameList
		{
			get
			{
				var offset = Program.CurrentConfig.Imsg.CriticalOffset;
				var list = new List<string>();
				var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
				for (var i = 0; i < IMSG_CRITICAL_COUNT; i++)
				{
					CurrentStream.Seek(offset+i*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
					CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
					list.Add(string.Format("{0:D2},{1}", i, Utils.ByteToString(msg)));
				}
				return list;
			}
		}

		public byte[] CriticalGet(int index)
		{
            var offset = Program.CurrentConfig.Imsg.CriticalOffset;
			var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void CriticalSet(int index, byte[] value)
		{
			var offset = Program.CurrentConfig.Imsg.CriticalOffset;
            CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}

		public List<string> StaffNameList
		{
			get
			{
                var offset = Program.CurrentConfig.Imsg.StaffOffset;
				var list = new List<string>();
				var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
				for (var i = 0; i < IMSG_STAFF_COUNT; i++)
				{
					CurrentStream.Seek(offset+i*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
					CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
					list.Add(Utils.ByteToString(msg));
				}
				return list;
			}
		}

		public byte[] StaffGet(int index)
		{
            var offset = Program.CurrentConfig.Imsg.StaffOffset;
			var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void StaffSet(int index, byte[] value)
		{
			var offset = Program.CurrentConfig.Imsg.StaffOffset;
            CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}
	}
}