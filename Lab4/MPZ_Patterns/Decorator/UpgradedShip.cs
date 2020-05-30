using MPZ_Patterns.Prototype;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ_Patterns.Decorator
{
    public class UpgradedShip : Ship
    {
        protected Ship ship;

        public UpgradedShip(Ship ship)
        {
            this.ship = ship;
        }

        public override Ship Clone()
        {
            this.MaxCrew += 10;
            return this.DeepCopy() as Ship;
        }
    }
}
