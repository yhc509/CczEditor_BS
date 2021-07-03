#region using List

using System.Collections.Generic;
using System.IO;

#endregion

namespace CczEditor.Data
{
	public enum ItemType
	{
		Weapons = 0x1,
		Armor = 0x2,
		Auxiliary = 0x3,
		Consumables = 0x4,
        BombTools = 0x5,
        Bombs = 0x6,
        BombMines = 0x7,
		None = 0x8
	}

	public class GameData : FileData
	{
		public const int GAME_UNIT_LENGTH = Program.GAME_UNIT_LENGTH;
		public const int GAME_ITEM_LENGTH = Program.GAME_ITEM_LENGTH;
		public const int GAME_STORE_LENGTH = Program.GAME_STORE_LENGTH;
		public const int GAME_FORCE_LENGTH = Program.GAME_FORCE_LENGTH;
		public const int GAME_TERRAIN_LENGTH = Program.GAME_TERRAIN_LENGTH;
		public const int GAME_MAGIC_LENGTH = Program.GAME_MAGIC_LENGTH;

        private StarData _starData;
        private ImsgData _imsgData;
        private ExeData _exeData;
        private Config _config;

        public GameData(string fileName) : base(fileName)
        {
            if (IsLsFile && IsCompression && Utils.QuestionUser(string.Format("이 파일 [{0}]은 아직 해독되지 않았습니다.해독합니까?", CurrentFile.FullName)))
            {
                Decompression();
            }
        }

        public void Initialize(StarData starData, ImsgData imsgData, ExeData exeData, Config config)
        {
            _starData = starData;
            _imsgData = imsgData;
            _exeData = exeData;
            _config = config;

            _weapons = ConfigUtils.GetWeaponsTypes(_exeData, config, null);
            _armor = ConfigUtils.GetArmorTypes(_exeData, config, null);
            _auxiliary = ConfigUtils.GetAuxiliaryEffects(_exeData, config, null);
            _consumables = ConfigUtils.GetConsumablesEffects(_exeData, config, null);
            _bombs = ConfigUtils.GetBombsEffects(_exeData, config, null);
            _bombs2 = ConfigUtils.GetBombsEffects2(_exeData, config, null);
            _bombs3 = ConfigUtils.GetBombsEffects3(_exeData, config, null);
        }

        #region Unit
        public List<byte[]> UnitList
        {
            // 한번에 데이터를 입출력 해야할 때 사용. 캐싱해서 쓰지 말 것.
            get
            {
                var count = _config.Data.UnitCount;
                var offset = _config.Data.UnitOffset;
                var length = GAME_UNIT_LENGTH;

                var list = new List<byte[]>();
                for (var i = 0; i < count; i++)
                {
                    byte[] unitBinary = new byte[length];
                    CurrentStream.Read(unitBinary, offset, 1);
                    list.Add(unitBinary);
                }
                return list;
            }
        }

		public List<string> UnitNameList(bool hasFormater)
		{
            var count = _config.Data.UnitCount;
            var offset = _config.Data.UnitOffset;
			var list = new List<string>();
			var name = new byte[12];
			for (var i = 0; i < count; i++)
			{
				CurrentStream.Seek(offset+i*GAME_UNIT_LENGTH, SeekOrigin.Begin);
				CurrentStream.Read(name, 0, 12);
				list.Add(hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX3, i, Utils.ByteToString(name)) : Utils.ByteToString(name));
			}
			return list;
		}
        
		public byte[] UnitGet(int index)
        {
            var offset = _config.Data.UnitOffset;
            var unit = new byte[GAME_UNIT_LENGTH];
			CurrentStream.Seek(offset+index*GAME_UNIT_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(unit, 0, GAME_UNIT_LENGTH);
			return unit;
		}

		public void UnitSet(int index, byte[] value)
        {
            var offset = _config.Data.UnitOffset;
            CurrentStream.Seek(offset+index*GAME_UNIT_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, GAME_UNIT_LENGTH);
		}
        #endregion


        #region Item
        private Dictionary<int, string> _weapons;
        private Dictionary<int, string> _armor;
        private Dictionary<int, string> _auxiliary;
        private Dictionary<int, string> _consumables;
        private Dictionary<int, string> _bombs;
        private Dictionary<int, string> _bombs2;
        private Dictionary<int, string> _bombs3;

		public ItemType GetItemType(byte index)
		{
			if (_weapons.ContainsKey(index))
			{
				return ItemType.Weapons;
			}
			if (_armor.ContainsKey(index))
			{
				return ItemType.Armor;
			}
			if (_auxiliary.ContainsKey(index))
			{
				return ItemType.Auxiliary;
			}
            if (_consumables.ContainsKey(index))
            {
                return ItemType.Consumables;
            }
            if (_bombs.ContainsKey(index))
            {
                return ItemType.BombTools;
            }
            if (_bombs2.ContainsKey(index))
            {
                return ItemType.Bombs;
            }
            return _bombs3.ContainsKey(index) ? ItemType.BombMines : ItemType.None;
        }

        public List<string> GetItemNames(ItemType type, bool hasFormater)
		{
            var count = _config.Data.ItemCount;
            var offset = _config.Data.ItemOffset;
			var list = new List<string>();
			var data = new byte[GAME_ITEM_LENGTH*count];
			CurrentStream.Seek(offset, SeekOrigin.Begin);
			CurrentStream.Read(data, 0, GAME_ITEM_LENGTH*count);
			for (var i = 0; i < count; i++)
			{
				var t = data[17+GAME_ITEM_LENGTH*i];
				var s = hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, Utils.ByteToString(data, GAME_ITEM_LENGTH*i, 16)) : Utils.ByteToString(data, GAME_ITEM_LENGTH*i, 16);

                if(type == ItemType.Weapons && _weapons.ContainsKey(t)) list.Add(s);
                if (type == ItemType.Armor && _armor.ContainsKey(t)) list.Add(s);
                if (type == ItemType.Auxiliary && _auxiliary.ContainsKey(t)) list.Add(s);
                if (type == ItemType.Consumables && _consumables.ContainsKey(t)) list.Add(s);
                if (type == ItemType.BombTools && _bombs.ContainsKey(t)) list.Add(s);
                if (type == ItemType.Bombs && _bombs2.ContainsKey(t)) list.Add(s);
                if (type == ItemType.BombMines && _bombs3.ContainsKey(t)) list.Add(s);
                
            }
            return list;
		}

		public List<string> ItemNameList(bool hasFormatter)
		{
            var count = _config.Data.ItemCount;
            var offset = _config.Data.ItemOffset;
			var list = new List<string>();
			var name = new byte[16];
			for (var i = 0; i < count; i++)
			{
                CurrentStream.Seek(offset + i * GAME_ITEM_LENGTH, SeekOrigin.Begin);
                CurrentStream.Read(name, 0, 16);
                list.Add(hasFormatter ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, Utils.ByteToString(name)) : Utils.ByteToString(name));
			}
			return list;
		}

        public int GetTreasureCount()
        {
            var item = new byte[1];
            int count = 0;
            int i = 0;
            for (; i < _config.Data.ItemCount; i++)
            {
                var offset = _config.Data.ItemOffset + 24;
                CurrentStream.Seek(offset + i * GAME_ITEM_LENGTH, SeekOrigin.Begin);
                CurrentStream.Read(item, 0, 1);
                if (item[0] == 1)
                {
                    count++;
                }
                item[0] = 0;
            }
            return count;
        }
        
		public byte[] ItemGet(int index)
		{
            var item = new byte[GAME_ITEM_LENGTH];
            if (index < 104)
            {
                var offset = _config.Data.ItemOffset;
                CurrentStream.Seek(offset + index * GAME_ITEM_LENGTH, SeekOrigin.Begin);
                CurrentStream.Read(item, 0, GAME_ITEM_LENGTH);
            }
            else
            {
                _starData.ItemGet(index+26,item);
            }
			return item;
		}

		public void ItemSet(int index, byte[] value)
		{
            if (index < 104)
            {
                var offset = _config.Data.ItemOffset;
                CurrentStream.Seek(offset + index * GAME_ITEM_LENGTH, SeekOrigin.Begin);
                CurrentStream.Write(value, 0, GAME_ITEM_LENGTH);
            }
            else
            {
                _starData.ItemSet(index+26, value);
            }

		}
        #endregion

        #region Shop
        public List<string> StoreNameList(bool hasFormater)
		{
			List<string> list;
			if (_imsgData == null || _imsgData.CurrentStream == null)
			{
				list = new List<string>();
                var count = _config.Imsg.StageCount;
				for (var i = 0; i < count; i++)
				{
					list.Add(string.Format("R_{0}", i.ToString("D2")));
				}
			}
			else
			{
				list = _imsgData.GetStageNameList(hasFormater);
			}
			return list;
		}

		public byte[] StoreGet(int index)
		{
            var offset = _config.Data.ShopOffset;
			var store = new byte[GAME_STORE_LENGTH];
			CurrentStream.Seek(offset+index*GAME_STORE_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(store, 0, GAME_STORE_LENGTH);
			return store;
		}

		public void StoreSet(int index, byte[] value)
		{
			var offset = _config.Data.ShopOffset;
            CurrentStream.Seek(offset+index*GAME_STORE_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, GAME_STORE_LENGTH);
		}
        #endregion

        #region Force
        public byte[] ForceGet(int index)
		{
            var offset = _config.Data.ForceOffset;
            var length = _config.Data.ForceLength;
			var force = new byte[length];
			CurrentStream.Seek(offset+index*length, SeekOrigin.Begin);
			CurrentStream.Read(force, 0, length);
			return force;
		}

		public void ForceSet(int index, byte[] value)
		{
			var offset = _config.Data.ForceOffset;
            var length = _config.Data.ForceLength;
            CurrentStream.Seek(offset+index*length, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, length);
		}
        #endregion

        #region Terrain
        public byte[] TerrainGet(int index)
		{
            var offset = _config.Data.TerrainOffset;
			var terrain = new byte[GAME_TERRAIN_LENGTH];
			CurrentStream.Seek(offset+index*GAME_TERRAIN_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(terrain, 0, GAME_TERRAIN_LENGTH);
			return terrain;
		}

		public void TerrainSet(int index, byte[] value)
		{
			var offset = _config.Data.TerrainOffset;
            CurrentStream.Seek(offset+index*GAME_TERRAIN_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, GAME_TERRAIN_LENGTH);
		}
        #endregion

        #region Magic
        public List<string> MagicNameList(bool hasFormater)
		{
            var count = _config.Data.MagicCount;
            var offset = _config.Data.MagicOffset;
            var length = _config.Data.MagicLength;
			var list = new List<string>();
			var name = new byte[10];
			for (var i = 0; i < count; i++)
			{
				CurrentStream.Seek(offset+i*length, SeekOrigin.Begin);
				CurrentStream.Read(name, 0, 10);
				list.Add(hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, Utils.ByteToString(name)) : Utils.ByteToString(name));
			}
			return list;
		}

		public byte[] MagicGet(int index)
		{
            var offset = _config.Data.MagicOffset;
            var length = _config.Data.MagicLength;
			var magic = new byte[length];
			CurrentStream.Seek(offset+index*length, SeekOrigin.Begin);
			CurrentStream.Read(magic, 0, length);
			return magic;
		}

		public void MagicSet(int index, byte[] value)
		{
            var offset = _config.Data.MagicOffset;
            var length = _config.Data.MagicLength;
			CurrentStream.Seek(offset+index*length, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, length);
		}
        #endregion
    }
}