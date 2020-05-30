using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ_Patterns.Observer
{
    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }
}
