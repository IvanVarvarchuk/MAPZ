using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ_Patterns.Singleton
{
    public class MainMap
    {
        private static readonly Lazy<MainMap> lazy =
       new Lazy<MainMap>(() => new MainMap());

        public string Source { get; private set; }

        public List<object> globalObjects;

        private MainMap()
        {
            globalObjects = new List<object>();
        }

        public static MainMap GetInstance()
        {
            return lazy.Value;
        }
    }
}
