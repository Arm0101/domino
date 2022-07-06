using System;
using System.Collections.Generic;
using Game;
namespace Logic
{
    public class TokensGenerator
    {
        public static IEnumerable<IToken> generateTokens(int n)
        {
           List<IToken> tokens = new List<IToken>();

            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                {
                    IFace[] faces = new IFace[2];
                    faces[0] = new NormalFace(i);
                    faces[1] = new NormalFace(j);
                 
                    tokens.Add(new NormalToken(faces));


                }
            }


            return tokens;

        }

    }

}

