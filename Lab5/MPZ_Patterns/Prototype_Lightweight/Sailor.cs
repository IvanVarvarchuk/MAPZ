using System.Collections.Generic;
using System.Windows.Media;

namespace MPZ_Patterns.Prototype
{
    public class Sailor : Pirate
    {

        public Sailor()
        {
            Attack = 15;
            Defence = 20;
            Health = 45;
            Cost = 15;
            IconUri = "pack://application:,,,/MPZ_Patterns;component/Resources/Icons/sailor.png";
            UnitImage = UnitImagesFactory.CrateImage(typeof(Sailor), IconUri);
        }     
        
        
        public override Pirate Clone()
        {
            return this.MemberwiseClone() as Sailor;
        }

        public override List<Pirate> Clone(int times)
        {
            var result = new List<Pirate>();
            for (int i = 0; i < times; i++)
            {
                result.Add(this.MemberwiseClone() as Sailor);
            }
            return result;
        }
    }
}
