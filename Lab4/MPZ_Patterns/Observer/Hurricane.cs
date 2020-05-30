using MPZ_Patterns.Prototype;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ_Patterns.Observer
{
    public class Hurricane : ISeaWeather
    {
        public string Type => "Hurricane";

        public int DamageBoost => 9;

        public void ChangeShipState(List<Ship> Ships)
        {
            foreach (var ship in Ships)
            {
                var piratesCanDie = new Random().Next(0, DamageBoost);
                for (int i = 0; i < piratesCanDie; i++)
                {
                    if (i < ship.Crew.Count)
                        ship.Crew.RemoveAt(i);
                }
                
                ship.Health -= (int)(10 * DamageBoost);
            }
        }
    }
}
