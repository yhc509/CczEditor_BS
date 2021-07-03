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

        private StarData _starData;
        private ImsgData _imsgData;
        private ExeData _exeData;
        private Config _config;

        public ImsgData(string fileName) : base(fileName) { }

        public void Initialize(StarData starData, ImsgData imsgData, ExeData exeData, Config config)
        {
            _starData = starData;
            _imsgData = imsgData;
            _exeData = exeData;
            _config = config;
        }


        public byte[] UnitOriginalGet(int index)
		{
			var offset = _config.Imsg.UnitOriginalOffset;
            var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void UnitOriginalSet(int index, byte[] value)
		{
			var offset = _config.Imsg.UnitOriginalOffset;
            CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}

		public byte[] UnitExtensionGet(int index)
		{
			var offset = _config.Imsg.UnitExtensionOffset;
            var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void UnitExtensionSet(int index, byte[] value)
		{
			var offset = _config.Imsg.UnitExtensionOffset;
            CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}

		public byte[] ItemGet(int index)
		{
			var offset = _config.Imsg.ItemOffset;
            var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
            CurrentStream.Seek(offset + index * IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
            CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void ItemSet(int index, byte[] value)
		{
            var offset = _config.Imsg.ItemOffset;
            CurrentStream.Seek(offset + index * IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
            CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}

		public byte[] MagicGet(int index)
		{
			var offset = _config.Imsg.MagicOffset;
            var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void MagicSet(int index, byte[] value)
		{
			var offset = _config.Imsg.MagicOffset;
            CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}

		public List<string> GetStageNameList(bool hasFormater)
		{
			var count = _config.Imsg.StageCount;
            var offset = _config.Imsg.StageOffset;
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
			var offset = _config.Imsg.StageOffset;
            var msg = new byte[IMSG_STAGE_NAME_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_STAGE_NAME_LENGTH);
			return msg;
		}

		public void StageSet(int index, byte[] value)
		{
			var offset = _config.Imsg.StageOffset;
            CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_STAGE_NAME_LENGTH);
		}

		public byte[] ForceGet(int index)
		{
			var offset = _config.Imsg.ForceOffset;
            var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void ForceSet(int index, byte[] value)
		{
            var offset = _config.Imsg.ForceOffset;
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}

		public List<string> RetreatNameList(bool hasFormater)
		{
			var offset = _config.Imsg.RetreatOffset;
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
            var offset = _config.Imsg.RetreatOffset;
			var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void RetreatSet(int index, byte[] value)
		{
			var offset = _config.Imsg.RetreatOffset;
            CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}

		public List<string> CriticalNameList {
            get
            {
                var offset = _config.Imsg.CriticalOffset;
                var list = new List<string>();
                var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
                for (var i = 0; i < IMSG_CRITICAL_COUNT; i++)
                {
                    CurrentStream.Seek(offset + i * IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
                    CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
                    list.Add(string.Format("{0:D2},{1}", i, Utils.ByteToString(msg)));
                }
                return list;
            }
		}

		public byte[] CriticalGet(int index)
		{
            var offset = _config.Imsg.CriticalOffset;
			var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void CriticalSet(int index, byte[] value)
		{
			var offset = _config.Imsg.CriticalOffset;
            CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}

		public List<string> StaffNameList
		{
            get
            {
                var offset = _config.Imsg.StaffOffset;
                var list = new List<string>();
                var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
                for (var i = 0; i < IMSG_STAFF_COUNT; i++)
                {
                    CurrentStream.Seek(offset + i * IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
                    CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
                    list.Add(Utils.ByteToString(msg));
                }
                return list;
            }
		}

		public byte[] StaffGet(int index)
		{
            var offset = _config.Imsg.StaffOffset;
			var msg = new byte[IMSG_DATA_BLOCK_LENGTH];
			CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(msg, 0, IMSG_DATA_BLOCK_LENGTH);
			return msg;
		}

		public void StaffSet(int index, byte[] value)
		{
			var offset = _config.Imsg.StaffOffset;
            CurrentStream.Seek(offset+index*IMSG_DATA_BLOCK_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, IMSG_DATA_BLOCK_LENGTH);
		}
	}
}