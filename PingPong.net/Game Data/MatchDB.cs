using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingPong.Game_Data
{
    public static class MatchDB
    {
        private static List<Match> _matches;

        public static List<Match> Matches
        {
            get
            {
                if (_matches == null)
                {
                    _matches = LoadMatchData();
                }

                return _matches;
            }
        }


        private static List<Match> LoadMatchData()
        {
            return GameDataHelper.LoadGameData<List<Match>>("MatchDB.sav") ?? new List<Match>();            
        }

        public static void SaveMatchData()
        {
            GameDataHelper.SaveGameData<List<Match>>("MatchDB.sav", Matches);
        }

        private static void AddMatchRecord(Match matchToAdd)
        {
            _matches.Add(matchToAdd);
        }
    }
}
