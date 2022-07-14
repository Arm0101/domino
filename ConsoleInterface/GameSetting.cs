using Logic;
using Game;
namespace ConsoleInterface
{
    
    public class GameSettings
    {
        //Lista de implementaciones concretas para las abstracciones
        private static Type[] typesofPlayers = new Type[] { typeof(NormalPlayer), typeof(AlmostSmartPlayer), typeof(PlayMostValuable) };
        private static Type[] typesofOrders = new Type[] { typeof(NormalOrder), typeof(ReverseOrder) };
        private static Type[] typesofWin = new Type[] { typeof(NormalWin), typeof(WinByPasses) };
        private static Type[] typesofFinish = new Type[] { typeof(NormalFinish), typeof(FinalizedByPasses), typeof(FinilizedByNPlayers) };
        private static Type[] typesofDsitibute = new Type[] { typeof(RandomDistibute), typeof(ParImparDistribute) };
        private static Type[] typesofActions = new Type[] { typeof(NormalAction), typeof(RemovePlayer), typeof(AddTokenToPlayer) };
        private static Type[] typesofTables = new Type[] { typeof(NormalTable), typeof(AdditionTable) };
        private static Type[] typesofGenerators = new Type[] { typeof(NumericTokensGenerator), typeof(MixTokensGenerator) };
       
        //se pregunta al usuario y se establecen las implementaciones  que se usaran en una partida
        public static void SetOptions(out ITable table, out ICollection<IPlayer> players, out IDistribute distribute, out IOrder order, out List<Token> tokens, out IFinish finish, out IWin win,out  IEnumerable<IAction> actions)
        {
            //conjunto de fichas s
            Console.Clear();
            Console.WriteLine("Que fichas utilizara?");
            IGenerator generator = setGenerator();
            Console.Write("Numero de caras distintas que tendra una ficha: ");
            int n = int.Parse(Console.ReadLine());
            tokens = generator.generateTokens(n).ToList();


            //jugadores
            Console.Clear();
            Console.WriteLine("Establecer jugadores");
            players = setPlayers();

            //Forma en que se distribuyen las fichas
            Console.Clear();
            Console.WriteLine("Como se distribuiran las fichas?");
            distribute = setDistribute();

            //mesa 
            Console.Clear();
            Console.WriteLine("Como se validaran las jugadas?");
            table = setTable();

            //establecer orden
            Console.Clear();
            Console.WriteLine("Cual sera el orden del juego?");
            order = setOrder(players);

            //establecer acciones
            Console.Clear();
            Console.WriteLine("Que hacer cuando un jugador juegue?");
            actions = setActions();

            //establecer condicion de finalizado
            Console.Clear();
            Console.WriteLine("Cuando se finaliza el juego?");
            finish = setFinish();

            //establecer condicion de ganador
            Console.Clear();
            Console.WriteLine("Quien gana?");
            win = setWin();
           
        }
        private static IGenerator setGenerator() {
          
            List<IGenerator> aux = new List<IGenerator>();
            for (int i = 0; i < typesofGenerators.Length; i++)
            {
                IGenerator g = (IGenerator)Activator.CreateInstance(typesofGenerators[i]);
                Console.WriteLine("{0} : {1}", i, g.Description());
                aux.Add(g);
            }
            int index = int.Parse(Console.ReadLine());
            IGenerator generator = aux[index];
            return generator;
        }
        private static ICollection<IPlayer> setPlayers()
        {
            //players
            Console.Clear();

            Console.Write("Numero de jugadores: ");
            int n_players = int.Parse(Console.ReadLine());
            List<IPlayer> playerList = new List<IPlayer>();
            for (int i = 0; i < n_players; i++)
            {
                List<IPlayer> aux = new List<IPlayer>();
                Console.Write("ID: ");
                string id = Console.ReadLine();
                Console.WriteLine("Tipo de jugador: ");
                for (int j = 0; j < typesofPlayers.Length; j++)
                {
                    IPlayer player = (IPlayer)Activator.CreateInstance(typesofPlayers[j], id);
                    Console.WriteLine("{0} : {1}", j, player.Description());
                    aux.Add(player);

                }
                //add player to list
                Console.Write(": ");
                int index = int.Parse(Console.ReadLine());
                playerList.Add(aux[index]);


            }
            return playerList;
        }

        private static ITable setTable() {

            List<ITable> aux = new List<ITable>();
            for (int i = 0; i < typesofTables.Length; i++)
            {
                ITable t = (ITable)Activator.CreateInstance(typesofTables[i]);
                Console.WriteLine("{0} : {1}", i, t.Description());
                aux.Add(t);
            }
            int index = int.Parse(Console.ReadLine());
            ITable table = aux[index];
            return table;
        }

        private static IDistribute setDistribute() {
            Console.Write("Cantidad de fichas por jugador: ");
            int n = int.Parse(Console.ReadLine());
            List<IDistribute> aux = new List<IDistribute>();
            for (int i = 0; i < typesofDsitibute.Length; i++)
            {
                IDistribute d = (IDistribute)Activator.CreateInstance(typesofDsitibute[i], n);
                Console.WriteLine("{0} : {1}", i, d.Description());
                aux.Add(d);
            }
            int index = int.Parse(Console.ReadLine());
            IDistribute distribute = aux[index];
            return distribute;
        }

        private static IOrder setOrder(IEnumerable<IPlayer> player) { 
            List<IOrder> aux = new List<IOrder>();
            for (int i = 0; i < typesofOrders.Length; i++)
            {
                IOrder o = (IOrder)Activator.CreateInstance(typesofOrders[i],player);
                Console.WriteLine("{0} : {1}", i, o.Description());
                aux.Add(o);
            }
            int index = int.Parse(Console.ReadLine());
            IOrder order = aux[index];
            return order;
        }
        
        private static IFinish setFinish() {
            List<IFinish> aux = new List<IFinish>();
            for (int i = 0; i < typesofFinish.Length; i++)
            {
                IFinish f = (IFinish)Activator.CreateInstance(typesofFinish[i]);
                Console.WriteLine("{0} : {1}", i, f.Description());
                aux.Add(f);
            }
            int index = int.Parse(Console.ReadLine());
            IFinish finish = aux[index];
            return finish;
        }

        private static IWin setWin() {
            List<IWin> aux = new List<IWin>();
            for (int i = 0; i < typesofWin.Length; i++)
            {
                IWin w = (IWin)Activator.CreateInstance(typesofWin[i]);
                Console.WriteLine("{0} : {1}", i, w.Description());
                aux.Add(w);
            }
            int index = int.Parse(Console.ReadLine());
            IWin win = aux[index];
            return win;
        }
        
        private static IEnumerable<IAction> setActions()
        {
            List<IAction> aux = new List<IAction>();
            for (int i = 0; i < typesofActions.Length; i++)
            {
                IAction a = (IAction)Activator.CreateInstance(typesofActions[i]);
                Console.WriteLine("{0} : {1}", i, a.Description());
                aux.Add(a);
            }
            Console.WriteLine("Ej:0,1");
            string s = Console.ReadLine();
            string[] numbers = s.Split(",");
            List<IAction> actions = new List<IAction>();
            foreach (var i in numbers)
            {
                int index = int.Parse(i);
                actions.Add(aux[index]);
            }
            return actions;
        }
        
        //crear instancia de Manager
        public static Manager BuildGame(ITable table, ICollection<IPlayer> players, IDistribute distribute, IOrder order, List<Token> tokens, IFinish finish, IWin win, IEnumerable<IAction> actions, IMonitor monitor)
        {
           return new Manager(table, players, distribute, tokens, order, finish, win, actions, monitor);
        }

    }

}
