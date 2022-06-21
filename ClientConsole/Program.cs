using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Program
    {
        public static HttpClient client;
        static void Main(string[] args)
        {
            //Configure HttpClient
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44328");

            //Make the HTTP request
            List<ResponseOrder> data = GetData().GetAwaiter().GetResult();

            //Display List<ResponseOrder> values
            foreach (ResponseOrder item in data)
            {
                Console.WriteLine(item.taskname);
            }

        }

        public static async Task<List<ResponseOrder>> GetData()
        {
            HttpResponseMessage response = await client.GetAsync("api/values");
            List<ResponseOrder> data = new List<ResponseOrder>();
            string rawJson = string.Empty;

            if (response.IsSuccessStatusCode)
            {
                //Display the raw data
                rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine(rawJson);
                Console.WriteLine();

                //Deserialize into the List<ResponseOrder> type
                data = JsonConvert.DeserializeObject<List<ResponseOrder>>(rawJson);
            }

            return data;
        }



    }
}
