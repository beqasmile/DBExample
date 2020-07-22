using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarUI
{
    public class CarObserver
    {
        private CarObserver _instance;


        private List<IObserverNotify> observerNotifies;

        private CarObserver()
        {
            this.observerNotifies = new List<IObserverNotify>();
        }

        public static CarObserver GetInstance()
        {
            if (_instance==null)
            {
                _instance = new CarObserver();
            }
            return _instance;
        }

        public void AddNotifier(IObserverNotify observerNotify)
        {
            if (!this.observerNotifies.Contains(observerNotify))
            {
                this.observerNotifies.Add(observerNotify);
            }
        }

        public void RemoveNotifier(IObserverNotify observerNotify)
        {
            if (this.observerNotifies.Contains(observerNotify))
            {
                this.observerNotifies.Remove(observerNotify);
            }
        }
    }
}
