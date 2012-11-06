using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingPong.Game_Data
{
    public class Player
    {

    #region Player Information

        public int Wins { get; set; }
        
        public int Loses { get; set; }

        public int Rating { get; set; }

        public string PlayerName { get; set; }

        public int ID { get; set; }
        
    #endregion

    #region Constructors

        public Player()
        {
        }

        public Player(string playerName)
        {
            PlayerName = playerName;
            ID = PlayerDB.GetNextAvailableID();
            Rating = 100; //This ELO calculation will assume that each player starts with a rating of 100;
        }

    #endregion


        public string GetWinLoseRecord()
        {
            return string.Format("{0} - {1}", Wins, Loses);
        }

    }
}
