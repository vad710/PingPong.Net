using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Storage;
using System.Xml.Serialization;
using System.IO;

namespace PingPong.Game_Data
{
    public static class GameDataHelper
    {
        private static StorageDevice _sd;
        public static StorageDevice Device
        {
            get
            {
                if (_sd == null)
                {
                    var result = StorageDevice.BeginShowSelector(null, null);
                    result.AsyncWaitHandle.WaitOne();
                    _sd = StorageDevice.EndShowSelector(result);
                    result.AsyncWaitHandle.Close();
                }
                return _sd;
            }
        }

        private static StorageContainer _sc;
        public static StorageContainer Container
        {
            get
            {
                if (_sc == null || _sc.IsDisposed)
                {
                    var result = Device.BeginOpenContainer("PingPongDB", null, null);
                    result.AsyncWaitHandle.WaitOne();
                    _sc = Device.EndOpenContainer(result);
                    result.AsyncWaitHandle.Close();
                }
                return _sc;
            }
        }

        public static void SaveGameData<T>(string filename, T saveData)
        {
            if (Container.FileExists(filename))
                Container.DeleteFile(filename);

            var stream = Container.CreateFile(filename);

            var serializer = new XmlSerializer(typeof(T));

            serializer.Serialize(stream, saveData);

            stream.Close();
            Container.Dispose();
        }

        public static T LoadGameData<T>(string filename)
        {
            if (!Container.FileExists(filename))
            {
                Container.Dispose();
                return default(T);
            }

            var stream = Container.OpenFile(filename, FileMode.Open);
            var serializer = new XmlSerializer(typeof(T));

            var gameData = (T)serializer.Deserialize(stream);

            stream.Close();
            Container.Dispose();

            return gameData;
        }
    }
}
