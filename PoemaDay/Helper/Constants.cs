using System;
using System.IO;

namespace PoemaDay.Helper
{
    public class Constants
    {
        public static string DBLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "poem_db.sqlite");
    }
}
