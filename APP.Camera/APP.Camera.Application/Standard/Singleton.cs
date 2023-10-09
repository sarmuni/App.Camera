using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using APP.Camera.Application.SMFLocation;


namespace APP.Camera.Application
{
    public class Singleton
    {
        private static Singleton instance = null;
        public IList<Location> Location { get; set; }
        public UserProfile userProfile { get; set; }


        private Singleton()
        {


        }

        private static object syncLock = new object();
        public static Singleton Instance
        {
            get
            {
                lock (syncLock)
                {
                    if (Singleton.instance == null)
                        Singleton.instance = new Singleton();
                    return Singleton.instance;
                }
            }
        }


    }
}
