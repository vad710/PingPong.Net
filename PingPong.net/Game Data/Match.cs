using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingPong.Game_Data
{
    public class Match
    {
        public int Player1 { get; private set; }
        public int P1Score { get; set; }
        public int Player2 { get; private set; }
        public int P2Score { get; set; }

        public Match()
        {
        }

        public Match(int player1ID, int p1score, int player2ID, int p2score)
        {
            Player1 = player1ID;
            Player2 = player2ID;
            P1Score = p1score;
            P2Score = p2score;
        }

        public Player GetWinner()
        {
            return P1Score > P2Score ? PlayerDB.GetPlayerFromID(Player1) : PlayerDB.GetPlayerFromID(Player2);
        }
    }
}
