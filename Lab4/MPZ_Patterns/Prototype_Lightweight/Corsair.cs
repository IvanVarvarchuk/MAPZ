using System.Collections.Generic;
using System.Windows.Media;

namespace MPZ_Patterns.Prototype
{
    public class Corsair: Pirate
    {
        public Corsair()
        {
            Attack = 35;
            Defence = 30;
            Health = 75;
            Cost = 30;
            IconUri = "pack://application:,,,/MPZ_Patterns;component/Resources/Icons/corsair.png";
            UnitImage = UnitImagesFactory.CrateImage(typeof(Corsair), IconUri);
        }

        public override Pirate Clone()
        {
            return this.MemberwiseClone() as Corsair;
        }

        public override List<Pirate> Clone(int times)
        {
            var result = new List<Pirate>();
            for (int i = 0; i < times; i++)
            {
                result.Add(this.MemberwiseClone() as Corsair);
            }
            return result;
        }
    }
}
