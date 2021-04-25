using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data.Wrapper
{
    public class ItemData : WrapperData<ItemData>
    {

        public string Name;
                                            // 무기       보조      소모      폭탄조종      지뢰        폭탄
        public byte ItemTypeIndex;          // 17         -         -         -             -           -
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
        public short BombEffectValue;       // -          -         -         21            21          21

        public byte EquipForceIndex;        // -          23        -         -             -           -
        public byte ItemRange;              // -          -         23        -             -           -
        public byte EffectRange;            // -          -         -         -             23          23

        public ItemData Clone()
        {
            return null;
        }

        public void Read(int index)
        {

        }

        public void Write(int index)
        {

        }
    }
}
