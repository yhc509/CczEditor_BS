using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class TerrainData
    {

        public byte[] Values;

        public void Read(int index, GameData gameData, ImsgData imsgData, ExeData exeData, Config config)
        {
            ReadGameData(index, gameData, config);
        }

        public void ReadExeData(int index, ExeData targetData, Config config)
        {
        }

        public void ReadGameData(int index, GameData targetData, Config config)
        {
            Values = targetData.TerrainGet(index);
        }

        public void ReadImsgData(int index, ImsgData targetData, Config config)
        {
        }

        public void Write(int index, GameData gameData, ImsgData imsgData, ExeData exeData, Config config)
        {
            WriteGameData(index, gameData, config);
        }

        public void WriteExeData(int index, ExeData targetData, Config config)
        {
        }

        public void WriteGameData(int index, GameData targetData, Config config)
        {
            targetData.TerrainSet(index, Values);
        }

        public void WriteImsgData(int index, ImsgData targetData, Config config)
        {
        }
    }
}
