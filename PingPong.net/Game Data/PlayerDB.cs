using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingPong.Game_Data
{
    public static class PlayerDB
    {
        private static List<Player> _players;

        public static List<Player> Players
        {
            get
            {
                if (_players == null)
                {
                    _players = LoadPlayerData();
                }

                return _players;
            }
        }

        private static List<Player> LoadPlayerData()
        {
            return GameDataHelper.LoadGameData<List<Player>>("PlayerDB.sav") ?? new List<Player>();
        }

        public static void SavePlayerData()
        {
            GameDataHelper.SaveGameData<List<Player>>("PlayerDB.sav",Players);
        }

        public static void AddPlayerToDB(Player newPlayer)
        {
            _players.Add(newPlayer);
        }

        public static Player GetPlayerFromID(int playerID)
        {
            return Players.SingleOrDefault(player => player.ID == playerID);
        }

        internal static int GetNextAvailableID()
        {
            return Players.Count();
        }
    }
}
