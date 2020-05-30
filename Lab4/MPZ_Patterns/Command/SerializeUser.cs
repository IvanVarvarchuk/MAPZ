using MPZ_Patterns.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace MPZ_Patterns.Command
{
    public class SerializeUser : ICommand
    {
        private UserInfo toSerialise;

        public SerializeUser(UserInfo toSerialise)
        {
            this.toSerialise = toSerialise;
        }

        public object Execute()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(UserInfo));
            using (FileStream fs = new FileStream("player.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, toSerialise);
            }

            return true;
        }
    }
}
