using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PoemaDay.model
{
    public class Poem
    {

        public string title { get; set; }

        public string author { get; set; }

        [JsonProperty("lines")]
        public List<string> lines { get; set; }

        public string linecount { get; set; }
    }

    public class Line
    {
        public string PoemLine { get; set; }
    }


}
