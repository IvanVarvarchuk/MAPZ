using MPZ_Patterns.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace MPZ_Patterns.Command
{
    public class DeserializeUser : ICommand
    {
        private Type _targetType;

        public DeserializeUser(Type deserializeType)
        {
            _targetType = deserializeType;
        }

        public object Execute()
        {
            XmlSerializer formatter = new XmlSerializer(_targetType);
            object result;

            using (FileStream fileStream = new FileStream("player.xml", FileMode.OpenOrCreate))
            {
                result = formatter.Deserialize(fileStream);
            }

            return result;
        }
    }
}
