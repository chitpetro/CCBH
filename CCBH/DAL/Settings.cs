using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class Settings
    {
        private static Settings defaultInstance = new Settings();
        public static Settings Default
        {
            get { return defaultInstance; }
        }

        public string ConnectionString
        {
            get
            {
                return Properties.Settings.Default.CCBHConnectionString;
            }
            set
            {
                Properties.Settings.Default["CCBHConnectionString"] = value; 
            }
        }
    }
}
