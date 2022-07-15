using Logic;
namespace ConsoleInterface
{
    internal class InfoMonitor : IMonitor
    {
        //se guarda una instancia de Unsubscriber
        private IDisposable cancellation;
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
        public virtual void Unsubscribe()
        {
            //dejar de recibir informacion
            cancellation.Dispose();

        }
        public void Subscribe(InfoHandler provider)
        {
            //empezar a recibir informacion sobre el estado del juego
            cancellation = provider.Subscribe(this);
        }

        public void OnError(Exception error)
        {

        }

        //representar estado del juego
        public virtual void OnNext(Info value)
        {
            if (value.Change) // se comprueba si el estado del juego cambio
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
                else
                {
                    Console.WriteLine("{0} se paso", value.LastPlayerId);
                }

                Console.WriteLine();
                Print.printPlayersTokens(value.PlayersInfo);
                Console.WriteLine();

                if (value.Finalized) // si el juego finalizo se muestran los ganadores
                {
                    foreach (var p in value.Winners)
                    {
                        Console.WriteLine("El jugador {0} ha ganado ", p.getID());
                    }

                }


            }
            //se muestran las notificacion
            Console.WriteLine(value.Notification);
            Console.ReadKey();
        }
    }
}
