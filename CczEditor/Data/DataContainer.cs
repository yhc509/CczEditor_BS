using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CczEditor.Data
{
    public static class DataContainer
    {
        // key == path
        private static Dictionary<string, GameData> _gameDataContainer = new Dictionary<string, GameData>();
        private static Dictionary<string, StarData> _starDataContainer = new Dictionary<string, StarData>();
        private static Dictionary<string, ImsgData> _imsgDataContainer = new Dictionary<string, ImsgData>();
        private static Dictionary<string, ExeData> _exeDataContainer = new Dictionary<string, ExeData>();
        private static Dictionary<string, SaveNewData> _saveDataContainer = new Dictionary<string, SaveNewData>();


        #region Load
        public static GameData LoadGameData(string path)
        {
            if (_gameDataContainer.ContainsKey(path))
            {
                return _gameDataContainer[path];
            }

            var data = new GameData(Path.Combine(path, Program.FILENAME_DATA));
            _gameDataContainer.Add(path, data);
            return data;
        }

        public static StarData LoadStarData(string path)
        {
            if (_starDataContainer.ContainsKey(path))
            {
                return _starDataContainer[path];
            }

            var data = new StarData(Path.Combine(path, Program.FILENAME_STAR));
            _starDataContainer.Add(path, data);
            return data;
        }

        public static ImsgData LoadImsgData(string path)
        {
            if (_imsgDataContainer.ContainsKey(path))
            {
                return _imsgDataContainer[path];
            }

            var data = new ImsgData(Path.Combine(path, Program.FILENAME_IMSG));
            _imsgDataContainer.Add(path, data);
            return data;
        }

        public static ExeData LoadExeData(string path)
        {
            if (_exeDataContainer.ContainsKey(path))
            {
                return _exeDataContainer[path];
            }

            var data = new ExeData();
            _exeDataContainer.Add(path, data);
            return data;
        }
        #endregion

        #region Unload
        public static void UnloadGameData(string key)
        {
            var data = GetGameData(key);
            if (data == null) return;
            _gameDataContainer.Remove(key);
            data.Close();
        }

        public static void UnloadStarData(string key)
        {
            var data = GetStarData(key);
            if (data == null) return;
            _starDataContainer.Remove(key);
            data.Close();
        }

        public static void UnloadImsgData(string key)
        {
            var data = GetImsgData(key);
            if (data == null) return;
            _imsgDataContainer.Remove(key);
            data.Close();
        }

        public static void UnloadExeData(string key)
        {
            var data = GetExeData(key);
            if (data == null) return;
            _exeDataContainer.Remove(key);
            data.Close();
        }

        #endregion

        #region Getter
        public static GameData GetGameData(string key)
        {
            GameData result = null;
            _gameDataContainer.TryGetValue(key, out result);
            return result;
        }

        public static StarData GetStarData(string key)
        {
            StarData result = null;
            _starDataContainer.TryGetValue(key, out result);
            return result;
        }

        public static ImsgData GetImsgData(string key)
        {
            ImsgData result = null;
            _imsgDataContainer.TryGetValue(key, out result);
            return result;
        }

        public static ExeData GetExeData(string key)
        {
            ExeData result = null;
            _exeDataContainer.TryGetValue(key, out result);
            return result;
        }
        #endregion


    }
}
