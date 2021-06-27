using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleHttpStressTester
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var target = new Target("localhost", "healthcheck", 5000, Protocol.Http);
            Console.WriteLine(target);

            Console.Write("Request count: ");
            var count = int.Parse(Console.ReadLine());


            var timer = new Stopwatch();
            var client = new HttpClient();

            for (var i = 0; i < count; i++)
            {
                timer.Start();
                var response = await client.GetAsync(target.Url);
                timer.Stop();

                Console.WriteLine($"[{HttpMethod.Get}] {response.StatusCode} {timer.ElapsedTicks} ticks");

                timer.Reset();
            }
        }
    }
}
