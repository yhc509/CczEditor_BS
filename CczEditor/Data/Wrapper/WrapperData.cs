using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public interface WrapperData<T>
    {
        void WriteGameData(int index, GameData targetData);
        void WriteImsgData(int index, ImsgData targetData);
        void WriteExeData(int index, ExeData targetData);

        void Read(int index);
        
    }
}
