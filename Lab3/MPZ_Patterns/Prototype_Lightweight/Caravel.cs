using System.Collections.Generic;
using System.Windows.Media;

namespace MPZ_Patterns.Prototype
{
    public class Caravel : Ship
    {
        public Caravel()
        {
            MaxCrew = 60;
            Attack = 285;
            Defence = 250;
            Health = 2750;
            Cost = 300;
            IconUri = "pack://application:,,,/MPZ_Patterns;component/Resources/Icons/caravel.png";
            UnitImage = UnitImagesFactory.CrateImage(typeof(Caravel), IconUri);
            Crew = new List<Pirate>();
        }

        public override Ship Clone()
        {
            return this.MemberwiseClone() as Caravel;
        }
    }

}
