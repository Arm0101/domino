﻿using Logic;
namespace Game
{
    public class ParImparDistribute:IDistribute
    {
        int n_players;
        public ParImparDistribute(int n)
        {
            n_players = n;
        }
        public void HandOutTokens(IPlayer[] players, List<Token> tokens)
        {
            List<Token> par = new List<Token>();
            List<Token> impar = new List<Token>();

            foreach (var t in tokens)
            {
                int val = t.Face1.GetValue() + t.Face2.GetValue();
                if (val % 2 == 0) par.Add(t);
                else
                    impar.Add(t);
            }
            
         
            int i = 0;
            bool par_turn = true;
            while (i < players.Length)
            {
                Random rand = new Random();
                for (int j = 0; j < n_players; j++)
                {
                    int index; 
                    if (par_turn)
                    {
                        index = rand.Next(0,par.Count);
                        players[i].addToken(par[index]);
                        par.RemoveAt(index);
                    }
                    else
                    {
                        index = rand.Next(0,impar.Count);
                        players[i].addToken(impar[index]);
                        impar.RemoveAt(index);

                    }
                }
                i++;
                par_turn = !par_turn;

            }
        }
    }
}

