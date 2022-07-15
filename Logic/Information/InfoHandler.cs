
namespace Logic
{

    //Patron Observer
    public class InfoHandler : IObservable<Info>
    {
        private List<IObserver<Info>> observers; //lista de observers que recibiran notificaciones
        private Info game_info; //estado actual del juego

        public InfoHandler()
        {
            observers = new List<IObserver<Info>>();
            game_info = new Info();
        }
        public IDisposable Subscribe(IObserver<Info> observer)
        {
            //agregar nuevo observer
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            //permitira al observer dejar de recibir notificaciones
            return new Unsubscriber<Info>(observers, observer);
        }

        //informar a los observers de los cambios
        public void Update(ITable table, History history, IEnumerable<IPlayer> players, IEnumerable<IPlayer> winners, bool finalized)
        {

            game_info.UpdateInfo(table, history, players, winners, finalized);
            foreach (var observer in observers)
                observer.OnNext(game_info);

        }
        //enviar una notificacion a los observers
        public void Notify(string notifi)
        {
            if (String.IsNullOrEmpty(notifi)) return;
            game_info.addNotification(notifi);
            foreach (var observer in observers)
                observer.OnNext(game_info);
        }

    }
    internal class Unsubscriber<info> : IDisposable
    {
        private List<IObserver<info>> observers;
        private IObserver<info> observer;

        internal Unsubscriber(List<IObserver<info>> _observers, IObserver<info> _observer)
        {
            observer = _observer;
            observers = _observers;
        }
        //observer dejara de recibir informacion
        public void Dispose()
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }
    }
}
