using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetClient
{
    public class SharedPreferences
    {
        public static SharedPreferences preferences = new SharedPreferences();
        private String key;
        public  String Key
        {
            get { return key; }
            set { key = value; }
        }

        private SharedPreferences()
        {

        }
    }
}
