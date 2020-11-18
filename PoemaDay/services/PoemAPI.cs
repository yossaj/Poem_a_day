using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PoemaDay.model;

namespace PoemaDay.services
{
    public class PoemAPI
    {



        public static async Task<Poem> GetPoemAsync()
        {
            List<Poem> poems = new List<Poem>();
            using (HttpClient httpClient = new HttpClient())
            {
                Random rnd = new Random();
                int linecount = rnd.Next(2, 6);
                var response = await httpClient.GetAsync($"https://poetrydb.org/linecount/{linecount}");
                var json = await response.Content.ReadAsStringAsync();
                var poemList = JsonConvert.DeserializeObject<List<Poem>>(json);

                int leng = poemList.Count();

                int poemNum = rnd.Next(0, leng);

                return poemList[poemNum];

            }

        }

    }
}
