using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public interface WrapperData<T>
    {
        void Write(int index);

        void Read(int index);

        T Clone();
    }
}
