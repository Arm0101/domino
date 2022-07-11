
namespace Logic
{
    public class InfoHandler : IObservable<Info>
    {
        private List<IObserver<Info>> observers;
        private Info game_info;
       
        public InfoHandler() { 
            observers = new List<IObserver<Info>>();
            game_info = new Info();
        }
        public IDisposable Subscribe(IObserver<Info> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }  

            return new Unsubscriber<Info>(observers,observer);
        }

        public void Update(ITable table, History history, List<IPlayer> players , List<IPlayer> winners, bool finalized) { 
           
            game_info.UpdateInfo(table, history, players, winners, finalized);
            foreach(var observer in observers)
                observer.OnNext(game_info);

        }

        public void Notify(string notifi) {
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

        internal Unsubscriber(List<IObserver<info>> _observers, IObserver<info> _observer) { 
            observer = _observer;
            observers = _observers;
        }
        public void Dispose()
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }
    }
}
