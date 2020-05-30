using System.Collections.Generic;
using System.Windows.Media;

namespace MPZ_Patterns.Prototype
{
    public class Frigate : Ship
    {
        public Frigate()
        {
            MaxCrew = 80;
            Attack = 550;
            Defence = 450;
            Health = 4000;
            Cost = 650;
            IconUri = "pack://application:,,,/MPZ_Patterns;component/Resources/Icons/frigate.png";
            UnitImage = UnitImagesFactory.CrateImage(typeof(Frigate), IconUri);
            Crew = new List<Pirate>();
        }

        public override Ship Clone()
        {
            return this.MemberwiseClone() as Frigate;
        }
    }

}
