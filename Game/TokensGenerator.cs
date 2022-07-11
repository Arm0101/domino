using System;
using System.Collections.Generic;
using Game;
namespace Logic
{
    public class NumericTokensGenerator
    {
        public static IEnumerable<Token> generateTokens(int n)
        {
           List<Token> tokens = new List<Token>();

            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                {

                    IFace face1 = new NormalFace(i);
                    IFace face2 = new NormalFace(j);
                   
                    tokens.Add(new Token(face1, face2));
                    
                    


                }
            }


            return tokens;

        }

    }



    public class MixTokensGenerator
    {
        
        public static IEnumerable<Token> generateTokens(int n)

        {
            char[] chars = new char[26];      
            for (char i = 'a'; i <= 'z'; i++)
            {
                chars[(int)i - 97] = i;
            }
            List<Token> tokens = new List<Token>();

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {

                    IFace face1 = new NormalFace(i);
                    IFace face2 = new CharFace(chars[j]);

                    tokens.Add(new Token(face1, face2));




                }
            }


            return tokens;

        }
    }

    }

