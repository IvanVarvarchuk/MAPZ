using System.Collections.Generic;
using System.Windows.Media;

namespace MPZ_Patterns.Prototype
{
    public class SeaDog : Pirate
    {
        public SeaDog()
        {
            Attack = 55;
            Defence = 45;
            Health = 100;
            Cost = 60;
            IconUri = "pack://application:,,,/MPZ_Patterns;component/Resources/Icons/seadog.gif";
            UnitImage = UnitImagesFactory.CrateImage(typeof(SeaDog), IconUri);
        }

        public override Pirate Clone()
        {
            return this.MemberwiseClone() as SeaDog;
        }

        public override List<Pirate> Clone(int times)
        {
            var result = new List<Pirate>();
            for (int i = 0; i < times; i++)
            {
                result.Add(this.MemberwiseClone() as SeaDog);
            }
            return result;
        }
    }
}
