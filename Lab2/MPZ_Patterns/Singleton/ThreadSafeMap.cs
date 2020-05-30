using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MPZ_Patterns.Singleton
{
    public class ThreadSafeMap
    {
        private static volatile ThreadSafeMap _instance = null;
        private static object Locker = new object();

        public List<object> globalObjects;

        private ThreadSafeMap()
        {
             globalObjects = new List<object>();
        }

        public static ThreadSafeMap Instance
        {
            get
            {
                Thread.Sleep(500);

                if (_instance == null)
                {
                    lock (Locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new ThreadSafeMap();
                        }
                    }
                }

                return _instance;
            }
        }



    }
}
