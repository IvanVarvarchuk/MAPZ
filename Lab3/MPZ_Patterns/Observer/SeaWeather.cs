using MPZ_Patterns.Prototype;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ_Patterns.Observer
{
    public class SeaWeather : IObservable
    {
        
        private ISeaWeather _currentWeather;
        private List<IObserver> _observers;

        public SeaWeather()
        {
            _observers = new List<IObserver>();
        }

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            foreach (IObserver o in _observers)
            {
                o.Update(_currentWeather);
            }
        }

        public void SetCurrentWeather(ISeaWeather weather)
        {
            _currentWeather = weather;
            NotifyObservers();
        }
        public string GetCurrentWeatherName()
        {
            return _currentWeather.Type;
        }

    }
}
