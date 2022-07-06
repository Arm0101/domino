using System;
using Logic;
using Game;
namespace ConsoleInterface {

 
    public class Program
    {

       
        static int count = 0;
        static void Main(string[] args) {
            List<IToken> tokens = TokensGenerator.generateTokens(9).ToList();
            Table table = new Table();
            Referee referee = new Referee();
            Player[] players = new Player[4];
            players[0] = new Player("01");
            players[1] = new Player("02");
            players[2] = new Player("03");
            players[3] = new Player("04");
            referee.handOutTokens(tokens, players);
            Manager manager = new Manager();
            manager.play(table, players, referee);

         /*   tokens.ForEach(x =>
            {
                List<IFace> faces = x.GetFaces().ToList();
                Console.WriteLine("[{0}:{1}]", faces[0].GetValue(), faces[1].GetValue());
            });
            NormalFace numero = new NormalFace(2);*/
   
          

            

        }
        
    }
  
    
}