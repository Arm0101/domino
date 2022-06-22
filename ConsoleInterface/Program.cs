using System;
using Logic;
namespace ConsoleInterface {

    public class Program
    {

       
        static int count = 0;
        static void Main(string[] args) {
            List<Token<int>> tokens = TokensGenerator.generateTokens();
            tokens.ForEach(x => Print.printToken(x,false,true));
            Print.endl();
            tokens.ForEach(x => Print.printToken(x,true ));
            Print.endl();
            // Referee referee = new Referee();
            //referee.handOutTokens(tokens, 4);
            // Console.SetCursorPosition(0, 50);
           
          


        }
        
    }
  
    
}