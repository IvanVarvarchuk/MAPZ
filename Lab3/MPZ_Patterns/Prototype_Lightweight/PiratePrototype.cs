using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows.Media;

namespace MPZ_Patterns.Prototype
{
    [Serializable]
    public abstract class Pirate
    {
        public abstract Pirate Clone();
        
        public abstract List<Pirate> Clone(int times);
        
        public int Attack { get; set; }
        
        public int Defence { get; set; }
        
        public int Health { get; set; }
        
        public int Cost { get; set; }
        
        public ImageBrush UnitImage { get; set; }
        
        public string IconUri { get; set; }      
        
    }
}
