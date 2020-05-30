using MPZ_Patterns.Prototype;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ_Patterns.Observer
{
    public class NormalWeather : ISeaWeather
    {
        public string Type => "Sunny Weather";
        public int DamageBoost => 0;
       
        public void ChangeShipState(List<Ship> Ships)
        {
            foreach (Ship ship in Ships)
            {
                var piratesCanDie = new Random().Next(0, DamageBoost);
                ship.Health -= (int)(10 * DamageBoost);
            }   
        }
    }
}
