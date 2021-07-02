using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class ItemData
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

        public void Read(int index, GameData gameData, ImsgData imsgData, ExeData exeData, Config config)
        {
            ReadGameData(index, gameData, config);
            ReadImsgData(index, imsgData, config);
            ReadExeData(index, exeData, config);
        }

        public void ReadGameData(int index, GameData targetData, Config config)
        {
            byte[] result = new byte[0x19];
            byte[] item;

            if (targetData.IsExist)
            {
                item = targetData.ItemGet(index);
                Name = Utils.ByteToString(item, 0, 16);

                Type = targetData.GetItemType(item[17]);


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
                    case ItemType.BombTools:
                        BombEffectIndex = item[17];
                        Cost = item[18];
                        IconIndex = item[19];
                        BombEffectValue = item[21];
                        break;
                    case ItemType.Bombs:
                        BombTypeIndex = item[16];
                        BombEffectIndex = item[17];
                        Cost = item[18];
                        IconIndex = item[19];
                        BombEffectValue = item[21];
                        EffectRange = item[23];
                        break;
                    case ItemType.BombMines:
                        AttackRange = item[16];
                        BombEffectIndex = item[17];
                        Cost = item[18];
                        IconIndex = item[19];
                        BombEffectValue = item[21];
                        EffectRange = item[23];
                        break;
                    case ItemType.None:
                    default:
                        Cost = item[19];
                        IconIndex = item[20];
                        break;
                }
            }
        }

        public void ReadImsgData(int index, ImsgData targetData, Config config)
        {
            if (targetData.IsExist)
            {
                Imsg = Utils.ByteToString(targetData.ItemGet(index), 0, Program.IMSG_DATA_BLOCK_LENGTH);
            }
        }

        public void ReadExeData(int index, ExeData targetData, Config config)
        {
        }

        public void Write(int index, GameData gameData, ImsgData imsgData, ExeData exeData, Config config)
        {
            WriteGameData(index, gameData, config);
            WriteImsgData(index, imsgData, config);
            WriteExeData(index, exeData, config);
        }

        public void WriteGameData(int index, GameData targetData, Config config)
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
                    if (config.CodeOptionContainer.ItemCustomRange)
                        result[23] = ItemRange;
                    else
                        result[23] = 0x0;
                    break;
                case ItemType.BombTools:
                    Utils.ChangeByteValue(result, Utils.GetBytes(Name), 0, 15);
                    result[16] = 0x00;
                    result[17] = BombEffectIndex;
                    result[18] = Cost;
                    result[19] = IconIndex;
                    result[20] = 0xFF;
                    Utils.ChangeByteValue(result, BitConverter.GetBytes(BombEffectValue), 21);
                    result[23] = 0x00;
                    break;
                case ItemType.Bombs:
                    Utils.ChangeByteValue(result, Utils.GetBytes(Name), 0, 15);
                    result[16] = BombTypeIndex;
                    result[17] = BombEffectIndex;
                    result[18] = Cost;
                    result[19] = IconIndex;
                    result[20] = 0xFF;
                    Utils.ChangeByteValue(result, BitConverter.GetBytes(BombEffectValue), 21);
                    result[23] = EffectRange;
                    break;
                case ItemType.BombMines:
                    Utils.ChangeByteValue(result, Utils.GetBytes(Name), 0, 15);
                    result[16] = AttackRange;
                    result[17] = BombEffectIndex;
                    result[18] = Cost;
                    result[19] = IconIndex;
                    result[20] = 0xFF;
                    Utils.ChangeByteValue(result, BitConverter.GetBytes(BombEffectValue), 21);
                    result[23] = EffectRange;
                    break;
                case ItemType.None:
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

            if (targetData.IsExist)
            {
                targetData.ItemSet(index, result);
            }
        }

        public void WriteImsgData(int index, ImsgData targetData, Config config)
        {
            if (targetData.IsExist)
            {
                if (Imsg != null)
                {
                    var msg = new byte[Program.IMSG_DATA_BLOCK_LENGTH];
                    Utils.ChangeByteValue(msg, Utils.GetBytes(Imsg), 0, Program.IMSG_DATA_BLOCK_LENGTH);
                    targetData.ItemSet(index, msg);
                }

            }
        }

        public void WriteExeData(int index, ExeData targetData, Config config)
        {
            if (!targetData.IsLocked)
            {
                int treasureCount = DataUtils.GetTreasureItemCount();
                if (!targetData.IsLocked)
                    targetData.WriteByte(treasureCount, 0, config.Exe.TreasureCountOffset);
            }
        }
    }
}
