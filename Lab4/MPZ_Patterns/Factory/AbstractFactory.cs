using MPZ_Patterns.Prototype;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ_Patterns.Factory
{
    public enum Difficulty {Simple, Medium, Hard }

    public interface IDifficultyFactory
    {
        Ship GetShip(); 
        List<Pirate> GetCrew();
        ResourseSet GetResourses();
    }

    public class EasyStart : IDifficultyFactory
    {
        public List<Pirate> GetCrew()
        {
            var corsair = new Corsair();
            var seaDog = new SeaDog();
            var crew = new List<Pirate>();
            crew.AddRange(corsair.Clone(15));
            crew.AddRange(seaDog.Clone(5));
            return crew;
        }

        public ResourseSet GetResourses()
        {
            return new ResourseSet(500,500,200,300);
        }

        public Ship GetShip()
        {
            var ship = new Frigate();
            ship.Crew = GetCrew();
            return ship;
        }
    }

    public class MediumStart : IDifficultyFactory
    {
        public Ship GetShip()
        {
            var ship = new Caravel();
            ship.Crew = GetCrew();
            return ship;
        }

        public List<Pirate> GetCrew()
        {
            var corsair = new Corsair();
            var sailor = new Sailor();
            var crew = new List<Pirate>();
            crew.AddRange(sailor.Clone(20));
            crew.AddRange(corsair.Clone(5));
            return crew;
        }

        public ResourseSet GetResourses()
        {
            return new ResourseSet(200,200,100,150);
        }
    }

    public class HardStart : IDifficultyFactory
    {
        public Ship GetShip()
        {
            var ship = new Brigantine();
            ship.Crew = GetCrew();
            return ship;
        }

        public List<Pirate> GetCrew()
        {
            var sailor = new Sailor();
            var crew = new List<Pirate>();
            crew.AddRange(sailor.Clone(10));
            return crew;
        }

        public ResourseSet GetResourses()
        {
            return new ResourseSet(100,100,20,30);
        }
    }

    

}
