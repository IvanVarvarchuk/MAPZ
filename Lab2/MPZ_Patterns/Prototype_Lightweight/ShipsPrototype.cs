using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Media;

namespace MPZ_Patterns.Prototype
{
    [Serializable]
    public abstract class Ship 
    {
        public abstract Ship Clone();

        public object DeepCopy()
        {
            object figure = null;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));

                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);

                figure = binFormatter.Deserialize(tempStream);
            }
            return figure;
        }
        
        public List<Pirate> Crew { get; set; }
        
        public int MaxCrew { get; set; }
        
        public int Attack { get; set; }

        public int Defence { get; set; }

        public int Health { get; set; }

        public int Cost { get; set; }
        
        public ImageBrush UnitImage { get; set; }

        public string IconUri { get; set; }

    }

}
