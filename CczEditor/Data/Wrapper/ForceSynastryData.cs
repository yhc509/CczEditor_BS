using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class ForceSynastryData
    {
        public byte[] Values;

        public void Read(int index, GameData gameData, ImsgData imsgData, ExeData exeData, Config config)
        {
            ReadExeData(index, exeData, config);
        }

        public void ReadExeData(int index, ExeData targetData, Config config)
        {
            if (!targetData.IsLocked)
            {
                var forceCategoryCount = config.ForceCategoryNames.Count;
                var offset = config.Exe.Force.SynastryOffset + (index * forceCategoryCount);
                Values = targetData.Read(offset, forceCategoryCount);
            }
        }

        public void ReadGameData(int index, GameData targetData, Config config)
        {
        }

        public void ReadImsgData(int index, ImsgData targetData, Config config)
        {
        }

        public void Write(int index, GameData gameData, ImsgData imsgData, ExeData exeData, Config config)
        {
            WriteExeData(index, exeData, config);

        }
        public void WriteExeData(int index, ExeData targetData, Config config)
        {
            if (!targetData.IsLocked)
            {
                var forceCategoryCount = config.ForceCategoryNames.Count;
                var offset = config.Exe.Force.SynastryOffset + (index * forceCategoryCount);
                targetData.Write(Values, offset);
            }
        }

        public void WriteGameData(int index, GameData targetData, Config config)
        {

        }

        public void WriteImsgData(int index, ImsgData targetData, Config config)
        {
        }
    }
}
