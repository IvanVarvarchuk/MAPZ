using MPZ_Patterns.Factory;
using MPZ_Patterns.Prototype;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ_Patterns.Memento
{
    public class PlayerMemento
    {
        public (List<Ship> ships, ResourseSet resourses) State { get; private set; }

        public PlayerMemento(List<Ship> ships, ResourseSet resourses)
        {
            State = (ships, resourses);
        }

        public PlayerMemento()
        {
        }
    }
    
}
