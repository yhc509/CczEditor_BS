#region using List

using System.Collections.Generic;
using System.IO;

#endregion

namespace CczEditor.Data
{
    public class StarData : FileData
    {
        public const int STAR_ITEM_LENGTH = Program.GAME_ITEM_LENGTH;
        private readonly Dictionary<int, string> _weapons = ConfigUtils.GetWeaponsTypes(null);
        private readonly Dictionary<int, string> _armor = ConfigUtils.GetArmorTypes(null);
        private readonly Dictionary<int, string> _auxiliary = ConfigUtils.GetAuxiliaryEffects(null);
        private readonly Dictionary<int, string> _consumables = ConfigUtils.GetConsumablesEffects(null);
        private readonly Dictionary<int, string> _bombs = ConfigUtils.GetBombsEffects(null);
        private readonly Dictionary<int, string> _bombs2 = ConfigUtils.GetBombsEffects2(null);
        private readonly Dictionary<int, string> _bombs3 = ConfigUtils.GetBombsEffects3(null);


        public StarData(string fileName) : base(fileName)
        {
        }
        public List<string> GetItemNames(ItemType type, bool hasFormater)
        {
            var count = Program.CurrentConfig.Data.StarItemCount;
            var offset = Program.CurrentConfig.Data.StarItemOffset;
            var list = new List<string>(); 
            var data = new byte[STAR_ITEM_LENGTH * count];
            CurrentStream.Seek(offset, SeekOrigin.Begin);
            CurrentStream.Read(data, 0, STAR_ITEM_LENGTH * count);
            for (var i = Program.CurrentConfig.Data.ItemCount + 1; i < count; i++)
            {
                var t = data[17 + STAR_ITEM_LENGTH * (i - (Program.CurrentConfig.Data.ItemCount + 1))];
                var s = hasFormater ? 
                    string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, Utils.ByteToString(data, STAR_ITEM_LENGTH * (i - (Program.CurrentConfig.Data.ItemCount + 1)), 16))
                    : Utils.ByteToString(data, STAR_ITEM_LENGTH * (i - (Program.CurrentConfig.Data.ItemCount + 1)), 16);
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
            return list;
        }

        public List<string> ItemNameList(bool hasFormater)//List<string> list
        {
            var count = Program.CurrentConfig.Data.StarItemCount;
            var offset = Program.CurrentConfig.Data.StarItemOffset;
            var list = new List<string>();
            var name = new byte[16];
            for (var i = Program.CurrentConfig.Data.ItemCount; i < count; i++)
            {
                CurrentStream.Seek(offset + (i-Program.CurrentConfig.Data.ItemCount) * STAR_ITEM_LENGTH, SeekOrigin.Begin);
                CurrentStream.Read(name, 0, 16);
                list.Add(hasFormater ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, Utils.ByteToString(name)) : Utils.ByteToString(name));
            }
            return list;
        }

        public List<int> ItemIconList(List<int> list)
        {
            var count = Program.CurrentConfig.Data.StarItemCount;
            var offset = Program.CurrentConfig.Data.StarItemOffset;
            for (var i = 0x82; i < count; i++)
            {
                CurrentStream.Seek(offset + (i-0x82) * STAR_ITEM_LENGTH + 20, SeekOrigin.Begin);
                list.Add(CurrentStream.ReadByte());
            }
            return list;
        }

        public List<bool> ItemIllustrationsShowList
        {
            get
            {
                var count = Program.CurrentConfig.Data.StarItemCount;
                var offset = Program.CurrentConfig.Data.StarItemOffset;
                var list = new List<bool>();
                for (var i = 0x82; i < count; i++)
                {
                    CurrentStream.Seek(offset + (i-0x82) * STAR_ITEM_LENGTH + 24, SeekOrigin.Begin);
                    list.Add(CurrentStream.ReadByte() == 0x01 ? true : false);
                }
                return list;
            }
            set
            {
                var count = Program.CurrentConfig.Data.StarItemCount;
                var offset = Program.CurrentConfig.Data.StarItemOffset;
                count = count > value.Count ? value.Count : count;
                for (var i = 0x82; i < count; i++)
                {
                    CurrentStream.Seek(offset + (i-0x82) * STAR_ITEM_LENGTH + 24, SeekOrigin.Begin);
                    CurrentStream.WriteByte((byte)(value[i] ? 0x01 : 0x00));
                }
            }
        }
        public void WriteTreasureCount(int bomul,byte[] item,int i)
        {
            for (; i < Program.CurrentConfig.Data.StarItemCount; i++)
            {
                var offset = 24;
                CurrentStream.Seek(offset + (i-Program.CurrentConfig.Data.ItemCount) * STAR_ITEM_LENGTH, SeekOrigin.Begin);
                CurrentStream.Read(item, 0, 1);
                if (item[0] == 1)
                {
                    bomul++;
                }
                item[0] = 0;
            }
            if(!ExeData.IsLocked)
                ExeData.WriteByte(bomul, 0, Program.CurrentConfig.Exe.TreasureCountOffset);
        }
        public byte[] ItemGet(int index,byte[] item)
        {
            var offset = Program.CurrentConfig.Data.StarItemOffset;
            CurrentStream.Seek(offset + (index-0x82) * STAR_ITEM_LENGTH, SeekOrigin.Begin);
            CurrentStream.Read(item, 0, STAR_ITEM_LENGTH);
            return item;
        }

        public void ItemSet(int index, byte[] value)
        {
            var offset = Program.CurrentConfig.Data.StarItemOffset;
            CurrentStream.Seek(offset + (index-0x82) * STAR_ITEM_LENGTH, SeekOrigin.Begin);
            CurrentStream.Write(value, 0, STAR_ITEM_LENGTH);
        }
    }
}