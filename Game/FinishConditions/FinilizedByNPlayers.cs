﻿using Logic;

namespace Game
{
    public class FinilizedByNPlayers : IFinish
    {
        public bool Finish(ITable table, IEnumerable<IPlayer> p, History history) {
            IPlayer[] players = p.ToArray();
            
            if (players.ToList().Count == 1) return true ;
            

            foreach (var item in players)
            {
                if (item.getTokens().ToList().Count == 0) return true;
            }

            return false;
        }
    }
}