using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data
{
    public static class DataUtils
    {

        public static List<string> ItemNameList(bool hasFormatter)
        {
            var list = Program.GameData.ItemNameList(hasFormatter);
            list.AddRange(Program.StarData.ItemNameList(hasFormatter));
            return list;
        }

        public static List<string> GetItemNames(ItemType type, bool hasFormatter)
        {
            var list = Program.GameData.GetItemNames(type, hasFormatter);
            list.AddRange(Program.StarData.GetItemNames(type, hasFormatter));
            return list;

        }
        
        public static int GetTreasureItemCount()
        {
            return Program.GameData.GetTreasureCount() + Program.StarData.GetTreasureCount();
        }
    }
}
