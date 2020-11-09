using System;
using System.Collections.Generic;

namespace PoemaDay.model
{
    public class Poem
    {

        public int id { get; set; }

        public string title { get; set; }

        public string author { get; set; }

        public List<string> lines { get; set; }

        public string linecount { get; set; }
    }
}
