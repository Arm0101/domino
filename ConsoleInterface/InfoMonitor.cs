using Logic;
namespace ConsoleInterface
{
    internal class InfoMonitor : IMonitor
    {
        private IDisposable cancellation;   
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
        public virtual void Unsubscribe()
        {
            cancellation.Dispose();

        }
        public void Subscribe(InfoHandler provider)
        {
            cancellation = provider.Subscribe(this);
        }

        public void OnError(Exception error)
        {
            
        }

        public virtual void OnNext(Info value)
        {
            Console.Clear();
            Print.printTable(value.Table);
            Console.WriteLine();

            if (value.LastToken != null)
            {
                Console.Write("{0} jugo: ", value.LastPlayerId);
                Print.printToken(value.LastToken);
                Console.WriteLine();
            }
            else {
                Console.WriteLine("{0} se paso", value.LastPlayerId);
            }

            Console.WriteLine();
            Print.printPlayersTokens(value.PlayersInfo);
            Console.WriteLine();

            if (value.Finalized) {
                foreach (var p in value.Winners)
                {
                    Console.WriteLine("El jugador {0} ha ganado ", p.getID());
                }
            
            }

            Console.ReadKey();
        }
    }
}
