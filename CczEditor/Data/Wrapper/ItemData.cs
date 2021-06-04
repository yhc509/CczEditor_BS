using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class ItemData : WrapperData<ItemData>
    {

        public string Name;

        public ItemType Type;

                                            // 무기       보조      소모      폭탄조종      지뢰        폭탄
        public byte WeaponTypeIndex;        // 17         -         -         -             -           -
        public byte SpecialEffectIndex;     // 18         17        -         -             -           -
        public byte ItemEffectIndex;        // -          -         17        -             -           -
        public byte BombTypeIndex;          // -          -         -         -             16          -
        public byte AttackRange;            // -          -         -         -             -           16
        public byte BombEffectIndex;        // -          -         -         17            17          17

        public byte Cost;                   // 19         19        19        18            18          18
        public byte IconIndex;              // 20         20        20        19            19          19

        public byte InitValue;              // 21         -         21        -             -           -
        public byte SpecialEffectValue;     // 22         21        -         -             -           -
        public byte IncreaseValue;          // 23         -         -         -             -           -
        public ushort BombEffectValue;       // -          -         -         21            21          21

        public byte EquipForceIndex;        // -          23        -         -             -           -
        public byte ItemRange;              // -          -         23        -             -           -
        public byte EffectRange;            // -          -         -         -             23          23

        public byte Treasure;               // 24

        public string Imsg;

        public void Read(int index)
        {
            if (Program.GameData.IsExist)
            {
                byte[] result = new byte[0x19];

                var item = Program.GameData.ItemGet(index);
                Name = Utils.ByteToString(item, 0, 16);

                Type = Program.GameData.GetItemType(item[17]);

                WeaponTypeIndex = byte.MaxValue;
                SpecialEffectIndex = byte.MaxValue;
                ItemEffectIndex = byte.MaxValue;
                BombTypeIndex = byte.MaxValue;
                AttackRange = byte.MaxValue;
                BombEffectIndex = byte.MaxValue;

                Cost = byte.MaxValue;
                IconIndex = byte.MaxValue;

                InitValue = byte.MaxValue;
                SpecialEffectValue = byte.MaxValue;
                IncreaseValue = byte.MaxValue;
                BombEffectValue = ushort.MaxValue;

                EquipForceIndex = byte.MaxValue;
                ItemRange = byte.MaxValue;
                EffectRange = byte.MaxValue;

                Treasure = item[24];

                switch (Type)
                {
                    case ItemType.Weapons:
                    case ItemType.Armor:
                        WeaponTypeIndex = item[17];
                        SpecialEffectIndex = item[18];
                        Cost = item[19];
                        IconIndex = item[20];
                        InitValue = item[21];
                        SpecialEffectValue = item[22];
                        IncreaseValue = item[23];
                        break;
                    case ItemType.Auxiliary:
                        SpecialEffectIndex = item[17];
                        Cost = item[19];
                        IconIndex = item[20];
                        SpecialEffectValue = item[21];
                        EquipForceIndex = item[23];
                        break;
                    case ItemType.Consumables:
                        ItemEffectIndex = item[17];
                        Cost = item[19];
                        IconIndex = item[20];
                        InitValue = item[21];
                        ItemRange = item[23];
                        break;
                    case ItemType.bombs:
                        BombEffectIndex = item[17];
                        Cost = item[18];
                        IconIndex = item[19];
                        BombEffectValue = item[21];
                        break;
                    case ItemType.bombs2:
                        BombTypeIndex = item[16];
                        BombEffectIndex = item[17];
                        Cost = item[18];
                        IconIndex = item[19];
                        BombEffectValue = item[21];
                        EffectRange = item[23];
                        break;
                    case ItemType.bombs3:
                        AttackRange = item[16];
                        BombEffectIndex = item[17];
                        Cost = item[18];
                        IconIndex = item[19];
                        BombEffectValue = item[21];
                        EffectRange = item[23];
                        break;
                    case ItemType.Unknow:
                    default:
                        Cost = item[19];
                        IconIndex = item[20];
                        break;
                }
            }

            if (Program.ImsgData.IsExist)
            {
                Imsg = Utils.ByteToString(Program.ImsgData.ItemGet(index), 0, Program.IMSG_DATA_BLOCK_LENGTH);
            }
        }

        public void Write(int index)
        {
            byte[] result = new byte[0x19];

            switch (Type)
            {
                case ItemType.Weapons:
                case ItemType.Armor:
                    Utils.ChangeByteValue(result, Utils.GetBytes(Name), 0, 16);
                    result[17] = WeaponTypeIndex;
                    result[18] = SpecialEffectIndex;
                    result[19] = Cost;
                    result[20] = IconIndex;
                    result[21] = InitValue;
                    result[22] = SpecialEffectValue;
                    result[23] = IncreaseValue;
                    break;
                case ItemType.Auxiliary:
                    Utils.ChangeByteValue(result, Utils.GetBytes(Name), 0, 16);
                    result[17] = SpecialEffectIndex;
                    result[18] = 0xFF;
                    result[19] = Cost;
                    result[20] = IconIndex;
                    result[21] = SpecialEffectValue;
                    result[22] = 0x0;
                    result[23] = EquipForceIndex;
                    break;
                case ItemType.Consumables:
                    Utils.ChangeByteValue(result, Utils.GetBytes(Name), 0, 16);
                    result[17] = ItemEffectIndex;
                    result[18] = 0xFF;
                    result[19] = Cost;
                    result[20] = IconIndex;
                    result[21] = InitValue;
                    result[22] = 0x0;
                    if (Program.CurrentConfig.CodeOptionContainer.ItemCustomRange)
                        result[23] = ItemRange;
                    else
                        result[23] = 0x0;
                    break;
                case ItemType.bombs:
                    Utils.ChangeByteValue(result, Utils.GetBytes(Name), 0, 15);
                    result[16] = 0x00;
                    result[17] = BombEffectIndex;
                    result[18] = Cost;
                    result[19] = IconIndex;
                    result[20] = 0xFF;
                    Utils.ChangeByteValue(result, BitConverter.GetBytes(BombEffectValue), 21);
                    result[23] = 0x00;
                    break;
                case ItemType.bombs2:
                    Utils.ChangeByteValue(result, Utils.GetBytes(Name), 0, 15);
                    result[16] = BombTypeIndex;
                    result[17] = BombEffectIndex;
                    result[18] = Cost;
                    result[19] = IconIndex;
                    result[20] = 0xFF;
                    Utils.ChangeByteValue(result, BitConverter.GetBytes(BombEffectValue), 21);
                    result[23] = EffectRange;
                    break;
                case ItemType.bombs3:
                    Utils.ChangeByteValue(result, Utils.GetBytes(Name), 0, 15);
                    result[16] = AttackRange;
                    result[17] = BombEffectIndex;
                    result[18] = Cost;
                    result[19] = IconIndex;
                    result[20] = 0xFF;
                    Utils.ChangeByteValue(result, BitConverter.GetBytes(BombEffectValue), 21);
                    result[23] = EffectRange;
                    break;
                case ItemType.Unknow:
                default:
                    Utils.ChangeByteValue(result, Utils.GetBytes(Name), 0, 15);
                    result[16] = 0xFF;
                    result[17] = BombEffectIndex;
                    result[18] = Cost;
                    result[19] = Cost;
                    result[20] = IconIndex;
                    Utils.ChangeByteValue(result, BitConverter.GetBytes(BombEffectValue), 21);
                    result[23] = EffectRange;
                    break;
            }
            result[24] = Treasure;

            if (Program.GameData.IsExist)
            {
                Program.GameData.ItemSet(index, result);
            }

            if (!ExeData.IsLocked)
            {
            }

            if (Program.ImsgData.IsExist)
            {
                if (Imsg != null)
                {
                    var msg = new byte[Program.IMSG_DATA_BLOCK_LENGTH];
                    Utils.ChangeByteValue(msg, Utils.GetBytes(Imsg), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                    Program.ImsgData.ItemSet(index, msg);
                }
                
            }
        }

        public ItemData Clone()
        {
            var result = this.Clone<ItemData>();
            return result;
        }

    }
}
