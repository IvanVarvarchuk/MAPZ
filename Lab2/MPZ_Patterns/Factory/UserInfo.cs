using MPZ_Patterns.Observer;
using MPZ_Patterns.Memento;
using MPZ_Patterns.Prototype;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using MPZ_Patterns.Command;

namespace MPZ_Patterns.Factory
{
    public class UserInfo : INotifyPropertyChanged, IObserver
    {
        private SavingServer _server;

        public UserInfo(IDifficultyFactory difficulty)
        {
            Ships = new List<Ship>();
            Ships.Add(difficulty.GetShip());
            
            Resourses = difficulty.GetResourses();
        }

        public List<Ship> Ships { get; protected set; }
       
        public ResourseSet Resourses { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void Update(object obj)
        {
            ISeaWeather newSeaWeather = (ISeaWeather)obj;
            newSeaWeather.ChangeShipState(Ships);
        }

        public PlayerMemento SaveState()
        {
            return new PlayerMemento(Ships, Resourses);
        }
        public void RestoreState(PlayerMemento memento)
        {
            Ships.AddRange(memento.State.ships);
            Resourses = memento.State.resourses;
        }


        public void RegisterServerCommand(ICommand command)
        {
            _server.RegisterCommand(command);
        }
        public object RunServerCommand()
        {
            return _server.RunCommand();
        }

    }

    
}
