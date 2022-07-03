using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TokensGenerator
    {
        public static List<Token> generateTokens(int n)
        {
           List<Token> tokens = new List<Token>();

            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                {
                    List<int> v = new List<int>();
                    v.Add(i);
                    v.Add(j);
                    Token token = new Token();
                    token.setValues(v);
                    tokens.Add(token);


                }
            }


            return tokens;

        }

    }

}

