#region using List

using System.Collections.Generic;
using System.IO;

#endregion

namespace CczEditor.Data
{
    public class StarData : FileData
    {
        public const int STAR_ITEM_LENGTH = Program.GAME_ITEM_LENGTH;
        private Dictionary<int, string> _weapons;
        private Dictionary<int, string> _armor;
        private Dictionary<int, string> _auxiliary;
        private Dictionary<int, string> _consumables;
        private Dictionary<int, string> _bombs;
        private Dictionary<int, string> _bombs2;
        private Dictionary<int, string> _bombs3;

        private StarData _starData;
        private ImsgData _imsgData;
        private ExeData _exeData;
        private Config _config;

        public StarData(string fileName) : base(fileName)
        {
        }


        public void Initialize(StarData starData, ImsgData imsgData, ExeData exeData, Config config)
        {
            _starData = starData;
            _imsgData = imsgData;
            _exeData = exeData;
            _config = config;

            _weapons = ConfigUtils.GetWeaponsTypes(exeData, config);
            _armor = ConfigUtils.GetArmorTypes(exeData, config);
            _auxiliary = ConfigUtils.GetAuxiliaryEffects(exeData, config);
            _consumables = ConfigUtils.GetConsumablesEffects(exeData, config);
            _bombs = ConfigUtils.GetBombsEffects(exeData, config);
            _bombs2 = ConfigUtils.GetBombsEffects2(exeData, config);
            _bombs3 = ConfigUtils.GetBombsEffects3(exeData, config);
        }

        public List<string> GetItemNames(ItemType type, bool hasFormater)
        {
            var count = _config.Data.StarItemCount;
            var offset = _config.Data.StarItemOffset;
            var list = new List<string>(); 
            var data = new byte[STAR_ITEM_LENGTH * count];
            CurrentStream.Seek(offset, SeekOrigin.Begin);
            CurrentStream.Read(data, 0, STAR_ITEM_LENGTH * count);
            for (var i = _config.Data.ItemCount + 1; i < count; i++)
            {
                var t = data[17 + STAR_ITEM_LENGTH * (i - (_config.Data.ItemCount + 1))];
                var s = hasFormater ? 
                    string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, Utils.ByteToString(data, STAR_ITEM_LENGTH * (i - (_config.Data.ItemCount + 1)), 16))
                    : Utils.ByteToString(data, STAR_ITEM_LENGTH * (i - (_config.Data.ItemCount + 1)), 16);
                
                if (type == ItemType.Weapons && _weapons.ContainsKey(t)) list.Add(s);
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
            var count = _config.Data.StarItemCount;
            var offset = _config.Data.StarItemOffset;
            var list = new List<string>();
            var name = new byte[16];
            for (var i = _config.Data.ItemCount; i < count; i++)
            {
                CurrentStream.Seek(offset + (i- _config.Data.ItemCount) * STAR_ITEM_LENGTH, SeekOrigin.Begin);
                CurrentStream.Read(name, 0, 16);
                list.Add(hasFormatter ? string.Format(Program.FORMATSTRING_KEYVALUEPAIR_HEX2, i, Utils.ByteToString(name)) : Utils.ByteToString(name));
            }
            return list;
        }

        public List<int> ItemIconList(List<int> list)
        {
            var count = _config.Data.StarItemCount;
            var offset = _config.Data.StarItemOffset;
            for (var i = 0x82; i < count; i++)
            {
                CurrentStream.Seek(offset + (i-0x82) * STAR_ITEM_LENGTH + 20, SeekOrigin.Begin);
                list.Add(CurrentStream.ReadByte());
            }
            return list;
        }

        public List<bool> GetItemIllustrationsShowList()
        {
            var count = _config.Data.StarItemCount;
            var offset = _config.Data.StarItemOffset;
            var list = new List<bool>();
            for (var i = 0x82; i < count; i++)
            {
                CurrentStream.Seek(offset + (i-0x82) * STAR_ITEM_LENGTH + 24, SeekOrigin.Begin);
                list.Add(CurrentStream.ReadByte() == 0x01 ? true : false);
            }
            return list;
        }

        public void SetItemIllustrationsShowList(List<bool> value)
        {
            var count = _config.Data.StarItemCount;
            var offset = _config.Data.StarItemOffset;
            count = count > value.Count ? value.Count : count;
            for (var i = 0x82; i < count; i++)
            {
                CurrentStream.Seek(offset + (i - 0x82) * STAR_ITEM_LENGTH + 24, SeekOrigin.Begin);
                CurrentStream.WriteByte((byte)(value[i] ? 0x01 : 0x00));
            }
        }

        public int GetTreasureCount()
        {
            var item = new byte[1];
            int count = 0;
            int i = 0;
            for (; i < _config.Data.StarItemCount; i++)
            {
                var offset = 24;
                CurrentStream.Seek(offset + (i - _config.Data.ItemCount) * STAR_ITEM_LENGTH, SeekOrigin.Begin);
                CurrentStream.Read(item, 0, 1);
                if (item[0] == 1)
                {
                    count++;
                }
                item[0] = 0;
            }
            return count;
        }
        
        public byte[] ItemGet(int index,byte[] item)
        {
            var offset = _config.Data.StarItemOffset;
            CurrentStream.Seek(offset + (index-0x82) * STAR_ITEM_LENGTH, SeekOrigin.Begin);
            CurrentStream.Read(item, 0, STAR_ITEM_LENGTH);
            return item;
        }

        public void ItemSet(int index, byte[] value)
        {
            var offset = _config.Data.StarItemOffset;
            CurrentStream.Seek(offset + (index-0x82) * STAR_ITEM_LENGTH, SeekOrigin.Begin);
            CurrentStream.Write(value, 0, STAR_ITEM_LENGTH);
        }
    }
}