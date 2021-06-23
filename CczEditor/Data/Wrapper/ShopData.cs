using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class ShopData : WrapperData<ItemData>
    {
        public ushort StorageUnitIndex;
        public ushort ShopUnitIndex;

        public List<byte> EquipItemList = new List<byte>();
        public List<byte> ConsumeItemList = new List<byte>();

        public string StageName;

        #region Write
        public void Write(int index)
        {
            // TODO 폐기 예정
            WriteGameData(index, Program.GameData);
            WriteImsgData(index, Program.ImsgData);
            WriteExeData(index, Program.ExeData);
        }

        public void WriteExeData(int index, ExeData targetData)
        {
        }

        public void WriteGameData(int index, GameData targetData)
        {
            var store = Program.GameData.StoreGet(index);
            Utils.ChangeByteValue(store, BitConverter.GetBytes(StorageUnitIndex), 0);
            Utils.ChangeByteValue(store, BitConverter.GetBytes(ShopUnitIndex), 2);

            var i = 4;
            for (var j = 0; j < EquipItemList.Count; j++)
            {
                store[i++] = EquipItemList[j];
            }
            for (; i < 20; i++)
            {
                store[i] = 0xFF;
            }
            for (var j = 0; j < ConsumeItemList.Count; j++)
            {
                store[i++] = ConsumeItemList[j];
            }
            for (; i < 36; i++)
            {
                store[i] = 0xFF;
            }
            Program.GameData.StoreSet(index, store);
        }

        public void WriteImsgData(int index, ImsgData targetData)
        {
            var stage = Program.ImsgData.StageGet(index);
            Utils.ChangeByteValue(stage, Utils.GetBytes(StageName), 0, Program.IMSG_STAGE_NAME_LENGTH);
            Program.ImsgData.StageSet(index, stage);
        }
        #endregion

        #region Read
        public void Read(int index)
        {
            ReadGameData(index);
            ReadImsgData(index);
            ReadExeData(index);
        }

        public void ReadGameData(int index)
        {
            EquipItemList.Clear();
            ConsumeItemList.Clear();

            var store = Program.GameData.StoreGet(index);
            StorageUnitIndex = BitConverter.ToUInt16(store, 0);
            ShopUnitIndex = BitConverter.ToUInt16(store, 2);
            
            for (var i = 4; i < 20; i++)
            {
                if (store[i] == 0xFF)
                {
                    continue;
                }
                EquipItemList.Add((byte) store[i]);
            }

            for (var i = 20; i < 36; i++)
            {
                if (store[i] == 0xFF)
                {
                    continue;
                }
                ConsumeItemList.Add((byte) store[i]);
            }
        }

        public void ReadImsgData(int index)
        {
            var stage = Program.ImsgData.StageGet(index);
            StageName = Utils.ByteToString(stage);
        }

        public void ReadExeData(int index)
        {
        }
        #endregion


    }
}
