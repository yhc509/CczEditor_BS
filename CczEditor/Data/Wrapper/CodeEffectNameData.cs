using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class CodeEffectNameData
    {
        public class IsLongNameException : Exception
        {

        }

        public string Name;
        
        public void Read(int index, ExeData targetData, Config config)
        {
            Name = ConfigUtils.GetAuxiliaryEffect(targetData, config, index);
            
        }

        public void Write(int index, ExeData targetData, Config config)
        {
            var target = config.ItemEffects.Find(x => x.Index == index);
            if (target == null) return;

            int length = Encoding.Default.GetByteCount(Name);
            if (length > target.Length)
            {
                throw new IsLongNameException();
            }

            targetData.WriteText(Name, target.Offset, target.Length);
        }
        
    }
}
