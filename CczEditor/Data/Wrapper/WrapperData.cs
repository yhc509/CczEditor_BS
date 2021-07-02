using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public interface WrapperData<T>
    {
        void Write(int index);
        void WriteGameData(int index, GameData targetData);
        void WriteImsgData(int index, ImsgData targetData);
        void WriteExeData(int index, ExeData targetData);

        void Read(int index);
        void ReadGameData(int index, GameData targetData);
        void ReadImsgData(int index, ImsgData targetData);
        void ReadExeData(int index, ExeData targetData);

    }
}
