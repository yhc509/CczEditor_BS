#region using List

using System.Collections.Generic;
using System.IO;

#endregion

namespace CczEditor.Data
{
	/// <summary>
	/// 물품유형
	/// </summary>
	public enum ItemType
	{
		/// <summary>
		/// 무기
		/// </summary>
		Weapons = 0x1,
		/// <summary>
		/// 방어구
		/// </summary>
		Armor = 0x2,
		/// <summary>
		/// 보조도구
		/// </summary>
		Auxiliary = 0x3,
		/// <summary>
		/// 소모품
		/// </summary>
		Consumables = 0x4,
        /// <summary>
        /// 폭탄-매설/조종
        /// </summary>
        bombs = 0x5,
        /// <summary>
        /// 폭탄-지뢰
        /// </summary>
        bombs2 = 0x6,
        /// <summary>
        /// 폭탄-폭탄
        /// </summary>
        bombs3 = 0x7,
		/// <summary>
		/// 미지
		/// </summary>
		Unknow = 0x8
	}

	public class GameData : FileData
	{
		public const int GAME_UNIT_LENGTH = Program.GAME_UNIT_LENGTH;
		public const int GAME_ITEM_LENGTH = Program.GAME_ITEM_LENGTH;
		public const int GAME_STORE_LENGTH = Program.GAME_STORE_LENGTH;
		public const int GAME_FORCE_LENGTH = Program.GAME_FORCE_LENGTH;
		public const int GAME_TERRAIN_LENGTH = Program.GAME_TERRAIN_LENGTH;
		public const int GAME_MAGIC_LENGTH = Program.GAME_MAGIC_LENGTH;

		public GameData(string fileName) : base(fileName)
		{
			if (IsLsFile && IsCompression && Utils.QuestionUser(string.Format("이 파일 [{0}]은 아직 해독되지 않았습니다.해독합니까?", CurrentFile.FullName)))
			{
				Decompression();
			}
		}

		public List<string> UnitNameList(bool hasFormater)
		{
			var count = Program.CurrentConfig.Offsets["Game_Unit_Count"];
			var offset = Program.CurrentConfig.Offsets["Game_Unit_Offset"];
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

		public List<byte> UnitForce
		{
			get
			{
				var count = Program.CurrentConfig.Offsets["Game_Unit_Count"];
				var offset = Program.CurrentConfig.Offsets["Game_Unit_Offset"];
				var list = new List<byte>();
				for (var i = 0; i < count; i++)
				{
					CurrentStream.Seek(offset+i*GAME_UNIT_LENGTH+26, SeekOrigin.Begin);
					list.Add((byte)CurrentStream.ReadByte());
				}
				return list;
			}
		}

		public byte[] UnitGet(int index)
		{
			var offset = Program.CurrentConfig.Offsets["Game_Unit_Offset"];
			var unit = new byte[GAME_UNIT_LENGTH];
			CurrentStream.Seek(offset+index*GAME_UNIT_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(unit, 0, GAME_UNIT_LENGTH);
			return unit;
		}

		public void UnitSet(int index, byte[] value)
		{
			var offset = Program.CurrentConfig.Offsets["Game_Unit_Offset"];
			CurrentStream.Seek(offset+index*GAME_UNIT_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, GAME_UNIT_LENGTH);
		}

		private readonly Dictionary<int, string> _weapons = Program.CurrentConfig.ItemConfigs.WeaponsTypes(false);
		private readonly Dictionary<int, string> _armor = Program.CurrentConfig.ItemConfigs.ArmorTypes(false);
        private readonly Dictionary<int, string> _auxiliary = Program.CurrentConfig.ItemConfigs.AuxiliaryEffects(false);
        private readonly Dictionary<int, string> _consumables = Program.CurrentConfig.ItemConfigs.ConsumablesEffects(false);
        private readonly Dictionary<int, string> _bombs = Program.CurrentConfig.ItemConfigs.BombsEffects(false);
        private readonly Dictionary<int, string> _bombs2 = Program.CurrentConfig.ItemConfigs.BombsEffects2(false);
        private readonly Dictionary<int, string> _bombs3 = Program.CurrentConfig.ItemConfigs.BombsEffects3(false);

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
            if (Program.CurrentConfig.Starusing)
            {
                if (_consumables.ContainsKey(index))
                {
                    return ItemType.Consumables;
                }
                if (_bombs.ContainsKey(index))
                {
                    return ItemType.bombs;
                }
                if (_bombs2.ContainsKey(index))
                {
                    return ItemType.bombs2;
                }
                return _bombs3.ContainsKey(index) ? ItemType.bombs3 : ItemType.Unknow;
            }
            else
            {
                return _consumables.ContainsKey(index) ? ItemType.Consumables : ItemType.Unknow;
            }
		}

        public List<string> GetItemNames(ItemType type, bool hasFormater)
		{
			var count = Program.CurrentConfig.Offsets["Game_Item_Count"];
			var offset = Program.CurrentConfig.Offsets["Game_Item_Offset"];
			var list = new List<string>();
			var data = new byte[GAME_ITEM_LENGTH*count];
			CurrentStream.Seek(offset, SeekOrigin.Begin);
			CurrentStream.Read(data, 0, GAME_ITEM_LENGTH*count);
			for (var i = 0; i < count; i++)
			{
				var t = data[17+GAME_ITEM_LENGTH*i];
				var s = hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, Utils.ByteToString(data, GAME_ITEM_LENGTH*i, 16)) : Utils.ByteToString(data, GAME_ITEM_LENGTH*i, 16);
				switch (type)
				{
					case ItemType.Weapons:
					{
						if (_weapons.ContainsKey(t))
						{
							list.Add(s);
                        }
						break;
					}
					case ItemType.Armor:
					{
						if (_armor.ContainsKey(t))
						{
							list.Add(s);
						}
						break;
					}
					case ItemType.Auxiliary:
					{
						if (_auxiliary.ContainsKey(t))
						{
							list.Add(s);
						}
						break;
					}
					case ItemType.Consumables:
					{
						if (_consumables.ContainsKey(t))
						{
							list.Add(s);
						}
						break;
					}
                    case ItemType.bombs:
                    {
                        if (_bombs.ContainsKey(t))
                        {
                            list.Add(s);
                        }
                        break;
                    }
                    case ItemType.bombs2:
                    {
                        if (_bombs2.ContainsKey(t))
                        {
                            list.Add(s);
                        }
                        break;
                    }
                    case ItemType.bombs3:
                    {
                        if (_bombs3.ContainsKey(t))
                        {
                            list.Add(s);
                        }
                        break;
                    }
					default:
						break;
				}
            }
            if (Program.CurrentConfig.Starusing)
            {
                if (Program.StarData != null && Program.StarData.CurrentFile != null && Program.StarData.CurrentStream != null)
                {
                    list.AddRange(Program.StarData.GetItemNames(type, true));
                }
            }
			return list;
		}

		public List<string> ItemNameList(bool hasFormater)
		{
			var count = Program.CurrentConfig.Offsets["Game_Item_Count"];
			var offset = Program.CurrentConfig.Offsets["Game_Item_Offset"];
			var list = new List<string>();
			var name = new byte[16];
			for (var i = 0; i < count; i++)
			{
                CurrentStream.Seek(offset + i * GAME_ITEM_LENGTH, SeekOrigin.Begin);
                CurrentStream.Read(name, 0, 16);
                list.Add(hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, Utils.ByteToString(name)) : Utils.ByteToString(name));
			}
			return list;
		}

		public List<int> ItemIconList()
		{
			var count = Program.CurrentConfig.Offsets["Game_Item_Count"];
			var offset = Program.CurrentConfig.Offsets["Game_Item_Offset"];
			var list = new List<int>();
			for (var i = 0; i < count; i++)
			{
				CurrentStream.Seek(offset+i*GAME_ITEM_LENGTH+20, SeekOrigin.Begin);
				list.Add(CurrentStream.ReadByte());
			}
            if (Program.CurrentConfig.Starusing)
            {
                if (Program.StarData != null && Program.StarData.CurrentFile != null && Program.StarData.CurrentStream != null)
                {
                Program.StarData.ItemIconList(list);
            }
                }
			return list;
		}

		public List<bool> ItemIllustrationsShowList
		{
			get
			{
				var count = Program.CurrentConfig.Offsets["Game_Item_Count"];
				var offset = Program.CurrentConfig.Offsets["Game_Item_Offset"];
				var list = new List<bool>();
				for (var i = 0; i < count; i++)
				{
					CurrentStream.Seek(offset+i*GAME_ITEM_LENGTH+24, SeekOrigin.Begin);
					list.Add(CurrentStream.ReadByte() == 0x01 ? true : false);
				}
				return list;
			}
			set
			{
				var count = Program.CurrentConfig.Offsets["Game_Item_Count"];
				var offset = Program.CurrentConfig.Offsets["Game_Item_Offset"];
				count = count > value.Count ? value.Count : count;
				for (var i = 0; i < count; i++)
				{
					CurrentStream.Seek(offset+i*GAME_ITEM_LENGTH+24, SeekOrigin.Begin);
					CurrentStream.WriteByte((byte)(value[i] ? 0x01 : 0x00));
				}
			}
		}
        public void BomulGet(int bomul)
        {
            var item = new byte[1];
            int i = 0;
            for (; i < Program.CurrentConfig.Offsets["Game_Item_Count"]; i++)
            {
                    var offset = Program.CurrentConfig.Offsets["Game_Item_Offset"] + 24;
                    CurrentStream.Seek(offset + i * GAME_ITEM_LENGTH, SeekOrigin.Begin);
                    CurrentStream.Read(item, 0, 1);
                    if (item[0] == 1)
                    {
                        bomul++;
                    }
                    item[0] = 0;
            }
            if (Program.CurrentConfig.Starusing)
            {
                if (Program.StarData != null && Program.StarData.CurrentFile != null && Program.StarData.CurrentStream != null)
                {
                    Program.StarData.BomulGet(bomul, item, i);
                }
            }
            else
            {
                Program.ExeData.bomulsave(bomul);
            }
        }

		public byte[] ItemGet(int index)
		{
            var item = new byte[GAME_ITEM_LENGTH];
            if (index < 104)
            {
                var offset = Program.CurrentConfig.Offsets["Game_Item_Offset"];
                CurrentStream.Seek(offset + index * GAME_ITEM_LENGTH, SeekOrigin.Begin);
                CurrentStream.Read(item, 0, GAME_ITEM_LENGTH);
            }
            else
            {
                Program.StarData.ItemGet(index+26,item);
            }
			return item;
		}

		public void ItemSet(int index, byte[] value)
		{
            if (index < 104)
            {
                var offset = Program.CurrentConfig.Offsets["Game_Item_Offset"];
                CurrentStream.Seek(offset + index * GAME_ITEM_LENGTH, SeekOrigin.Begin);
                CurrentStream.Write(value, 0, GAME_ITEM_LENGTH);
            }
            else
            {
                Program.StarData.ItemSet(index+26, value);
            }

		}

		public List<string> StoreNameList(bool hasFormater)
		{
			List<string> list;
			if (Program.ImsgData == null || Program.ImsgData.CurrentStream == null)
			{
				list = new List<string>();
				var count = Program.CurrentConfig.Offsets["Imsg_Stage_Count"];
				for (var i = 0; i < count; i++)
				{
					list.Add(string.Format("R_{0}", i.ToString("D2")));
				}
			}
			else
			{
				list = Program.ImsgData.StageNameList(hasFormater);
			}
			return list;
		}

		public byte[] StoreGet(int index)
		{
			var offset = Program.CurrentConfig.Offsets["Game_Shop_Offset"];
			var store = new byte[GAME_STORE_LENGTH];
			CurrentStream.Seek(offset+index*GAME_STORE_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(store, 0, GAME_STORE_LENGTH);
			return store;
		}

		public void StoreSet(int index, byte[] value)
		{
			var offset = Program.CurrentConfig.Offsets["Game_Shop_Offset"];
			CurrentStream.Seek(offset+index*GAME_STORE_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, GAME_STORE_LENGTH);
		}

		public byte[] ForceGet(int index)
		{
			var offset = Program.CurrentConfig.Offsets["Game_Force_Offset"];
			var length = Program.CurrentConfig.Offsets["Game_Force_Length"];
			var force = new byte[length];
			CurrentStream.Seek(offset+index*length, SeekOrigin.Begin);
			CurrentStream.Read(force, 0, length);
			return force;
		}

		public void ForceSet(int index, byte[] value)
		{
			var offset = Program.CurrentConfig.Offsets["Game_Force_Offset"];
			var length = Program.CurrentConfig.Offsets["Game_Force_Length"];
			CurrentStream.Seek(offset+index*length, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, length);
		}

		public byte[] TerrainGet(int index)
		{
			var offset = Program.CurrentConfig.Offsets["Game_Terrain_Offset"];
			var terrain = new byte[GAME_TERRAIN_LENGTH];
			CurrentStream.Seek(offset+index*GAME_TERRAIN_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(terrain, 0, GAME_TERRAIN_LENGTH);
			return terrain;
		}

		public void TerrainSet(int index, byte[] value)
		{
			var offset = Program.CurrentConfig.Offsets["Game_Terrain_Offset"];
			CurrentStream.Seek(offset+index*GAME_TERRAIN_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, GAME_TERRAIN_LENGTH);
		}

		public List<string> MagicNameList(bool hasFormater)
		{
			var count = Program.CurrentConfig.Offsets["Game_Magic_Count"];
			var offset = Program.CurrentConfig.Offsets["Game_Magic_Offset"];
			var length = Program.CurrentConfig.Offsets["Game_Magic_Length"];
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
			var offset = Program.CurrentConfig.Offsets["Game_Magic_Offset"];
			var length = Program.CurrentConfig.Offsets["Game_Magic_Length"];
			var magic = new byte[length];
			CurrentStream.Seek(offset+index*length, SeekOrigin.Begin);
			CurrentStream.Read(magic, 0, length);
			return magic;
		}

		public void MagicSet(int index, byte[] value)
		{
			var offset = Program.CurrentConfig.Offsets["Game_Magic_Offset"];
			var length = Program.CurrentConfig.Offsets["Game_Magic_Length"];
			CurrentStream.Seek(offset+index*length, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, length);
		}
	}
}