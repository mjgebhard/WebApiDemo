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

        //IIS
        public static string baseAddress = "http://localhost";
        public static string action = "WebApiBasic/api/values";

        //IIS Express
        //public static string baseAddress = "https://localhost:44328/";
        //public static string action = "api/values";

        static void Main(string[] args)
        {

            //DateTime d = new DateTime();
            //Console.WriteLine(d);
            //return;

            //Configure HttpClient
            //https://localhost:44328
            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);

            //Make an HTTP GET request
            List<ResponseOrder> data = GetData().GetAwaiter().GetResult();

            //Display List<ResponseOrder> values
            foreach (ResponseOrder item in data)
            {
                Console.WriteLine(item.taskname);
            }
            Console.WriteLine();

            //Make an HTTP GET request by Id
            ResponseOrder data1 = GetData("2022-06-10-O424").GetAwaiter().GetResult();
            Console.WriteLine(data1.taskname);
            Console.WriteLine();

            //Make an HTTP POST request
            ResponseOrder data2 = PostData().GetAwaiter().GetResult();
            Console.WriteLine(data2.taskname);
            Console.WriteLine();

            //Make an HTTP PUT request
            ResponseOrder data3 = PutData().GetAwaiter().GetResult();
            Console.WriteLine(data3.taskname);
            Console.WriteLine();

            //Make an HTTP Delete request
            DeleteData("2022-06-10-O424").GetAwaiter().GetResult();

        }

        public static async Task<List<ResponseOrder>> GetData()
        {
            Console.WriteLine();
            Console.WriteLine("****  GET ****");
            Console.WriteLine();

            List<ResponseOrder> data = new List<ResponseOrder>();
            string rawJson = string.Empty;

            HttpResponseMessage response = await client.GetAsync($"{action}");

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

        public static async Task<ResponseOrder> GetData(string id)
        {
            Console.WriteLine();
            Console.WriteLine("****  GET by Id ****");
            Console.WriteLine();

            ResponseOrder data = new ResponseOrder();
            string rawJson = string.Empty;

            HttpResponseMessage response = await client.GetAsync($"{action}/{id}");

            if (response.IsSuccessStatusCode)
            {
                //Display the raw data
                rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine(rawJson);
                Console.WriteLine();

                //Deserialize into the List<ResponseOrder> type
                data = JsonConvert.DeserializeObject<ResponseOrder>(rawJson);
            }

            return data;
        }

        public static async Task<ResponseOrder> PostData()
        {
            Console.WriteLine();
            Console.WriteLine("****  Post ****");
            Console.WriteLine();

            ResponseOrder data = new ResponseOrder();
            string rawJson = string.Empty;

            ResponseOrder request = new ResponseOrder()
            {
                actorname = "Marking",
                stepname = "2022-06-10-O424",
                taskname = "EXECUTION_2",
                parameters = new List<Parameter>
                    {
                      new Parameter {  name = "parameter A", value = 73.1m },
                      new Parameter {  name = "parameter B", value = 12m },
                      new Parameter {  name = "parameter C", value = 173.1m },
                      new Parameter {  name = "parameter D", value = 112m },
                      new Parameter {  name = "parameter E", value = 273.1m },
                      new Parameter {  name = "parameter F", value = 312m },
                    }
            };

            string json = JsonConvert.SerializeObject(request);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync($"{action}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                //Display the raw data
                rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine(rawJson);
                Console.WriteLine();

                //Deserialize into the List<ResponseOrder> type
                data = JsonConvert.DeserializeObject<ResponseOrder>(rawJson);
            }

            return data;

        }

        public static async Task<ResponseOrder> PutData()
        {
            Console.WriteLine();
            Console.WriteLine("****  Put ****");
            Console.WriteLine();
            ResponseOrder data = new ResponseOrder();
            string rawJson = string.Empty;

            ResponseOrder request = new ResponseOrder()
            {
                actorname = "Marking",
                stepname = "2022-06-10-O424",
                taskname = "EXECUTION_2",
                parameters = new List<Parameter>
                    {
                      new Parameter {  name = "parameter A", value = 73.1m },
                      new Parameter {  name = "parameter B", value = 12m },
                      new Parameter {  name = "parameter C", value = 173.1m },
                      new Parameter {  name = "parameter D", value = 112m },
                      new Parameter {  name = "parameter E", value = 273.1m },
                      new Parameter {  name = "parameter F", value = 312m },
                    }
            };

            string id = request.stepname;

            string json = JsonConvert.SerializeObject(request);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"{action}/{id}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                //Display the raw data
                rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine(rawJson);
                Console.WriteLine();

                //Deserialize into the List<ResponseOrder> type
                data = JsonConvert.DeserializeObject<ResponseOrder>(rawJson);
            }

            return data;

        }

        
        public static async Task DeleteData(string id)
        {
            Console.WriteLine();
            Console.WriteLine("****  Delete ****");
            Console.WriteLine();
            string rawJson = string.Empty;

            HttpResponseMessage response = await client.DeleteAsync($"{action}/{id}");

            if (response.IsSuccessStatusCode)
            {
                //Display the raw data
                rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine(rawJson);
                Console.WriteLine();
            }

        }

    }
}
