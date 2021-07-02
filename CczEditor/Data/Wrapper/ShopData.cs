using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class ShopData
    {
        public ushort StorageUnitIndex;
        public ushort ShopUnitIndex;

        public List<byte> EquipItemList = new List<byte>();
        public List<byte> ConsumeItemList = new List<byte>();

        public string StageName;

        #region Write
        public void Write(int index, GameData gameData, ImsgData imsgData, ExeData exeData, Config config)
        {
            WriteGameData(index, gameData, config);
            WriteImsgData(index, imsgData, config);
            WriteExeData(index, exeData, config);
        }

        public void WriteExeData(int index, ExeData targetData, Config config)
        {
        }

        public void WriteGameData(int index, GameData targetData, Config config)
        {
            var store = targetData.StoreGet(index);
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

            if(targetData.IsExist)
                targetData.StoreSet(index, store);
        }

        public void WriteImsgData(int index, ImsgData targetData, Config config)
        {
            if (targetData.IsExist) {
                var stage = new byte[Program.IMSG_STAGE_NAME_LENGTH];
                Utils.ChangeByteValue(stage, Utils.GetBytes(StageName), 0, Program.IMSG_STAGE_NAME_LENGTH);
                targetData.StageSet(index, stage); 
            } 
        }
        #endregion

        #region Read
        public void Read(int index, GameData gameData, ImsgData imsgData, ExeData exeData, Config config)
        {
            ReadGameData(index, gameData, config);
            ReadImsgData(index, imsgData, config);
            ReadExeData(index, exeData, config);
        }

        public void ReadGameData(int index, GameData targetData, Config config)
        {
            if (targetData.IsExist)
            {
                EquipItemList.Clear();
                ConsumeItemList.Clear();

                var store = targetData.StoreGet(index);
                StorageUnitIndex = BitConverter.ToUInt16(store, 0);
                ShopUnitIndex = BitConverter.ToUInt16(store, 2);

                for (var i = 4; i < 20; i++)
                {
                    if (store[i] == 0xFF)
                    {
                        continue;
                    }
                    EquipItemList.Add((byte)store[i]);
                }

                for (var i = 20; i < 36; i++)
                {
                    if (store[i] == 0xFF)
                    {
                        continue;
                    }
                    ConsumeItemList.Add((byte)store[i]);
                }
            }
        }

        public void ReadImsgData(int index, ImsgData targetData, Config config)
        {
            if (targetData.IsExist)
            {
                var stage = targetData.StageGet(index);
                StageName = Utils.ByteToString(stage);
            }
        }

        public void ReadExeData(int index, ExeData targetData, Config config)
        {
            if(!targetData.IsLocked)
            {

            }
        }
        
        #endregion


    }
}
