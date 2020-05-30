using MPZ_Patterns.Prototype;
using System.Collections.Generic;

namespace MPZ_Patterns.Observer
{
    public interface ISeaWeather
    {
        string Type { get; }
        int DamageBoost { get; }
        void ChangeShipState(List<Ship> Ships);
    }
}
