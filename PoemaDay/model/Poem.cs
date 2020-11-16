using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;

namespace PoemaDay.model
{
    public class Poem
    {

       [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string title { get; set; }

        public string author { get; set; }

        [Ignore]
        public List<string> lines { get; set; }

        public String concatLines { get; set; }

        public string linecount { get; set; }
    }

    public class Line
    {
        public string PoemLine { get; set; }
    }

}
