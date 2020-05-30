using System.Collections.Generic;
using System.Windows.Media;

namespace MPZ_Patterns.Prototype
{
    public class Brigantine : Ship
    {
        public Brigantine()
        {
            MaxCrew = 40;
            Attack = 185;
            Defence = 150;
            Health = 1450;
            Cost = 150;
            IconUri = "pack://application:,,,/MPZ_Patterns;component/Resources/Icons/brigantine.png";
            UnitImage = UnitImagesFactory.CrateImage(typeof(Brigantine), IconUri);
            Crew = new List<Pirate>();
        }

        
        public override Ship Clone()
        {
            return this.MemberwiseClone() as Brigantine;
        }
    }

}
