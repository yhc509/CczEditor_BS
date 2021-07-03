using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CczEditor.Data
{
    public static class DataUtils
    {

        public static List<string> ItemNameList(GameData gameData, StarData starData, bool hasFormatter)
        {
            var list = gameData.ItemNameList(hasFormatter);
            list.AddRange(starData.ItemNameList(hasFormatter));
            return list;
        }

        public static List<string> GetItemNames(GameData gameData, StarData starData, ItemType type, bool hasFormatter)
        {
            var list = gameData.GetItemNames(type, hasFormatter);
            list.AddRange(starData.GetItemNames(type, hasFormatter));
            return list;

        }
        
        public static int GetTreasureItemCount(GameData gameData, StarData starData)
        {
            return gameData.GetTreasureCount() + starData.GetTreasureCount();
        }
    }
}
