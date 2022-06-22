using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TokensGenerator
    {
        public static List<Token<int>> generateTokens()
        {
           List<Token<int>> tokens = new List<Token<int>>();

            for (int i = 1; i <= 2; i++)
            {
                for (int j = i; j <= 2; j++)
                {
                    List<int> v = new List<int>();
                    v.Add(i);
                    v.Add(j);
                    Token<int> token = new Token<int>();
                    token.setValues(v);
                    tokens.Add(token);


                }
            }


            return tokens;

        }

    }

}

