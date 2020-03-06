using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelloCS
{
    public class Program{
        public static async Task Main(string[] args){
            var x = "dfsdfsdfs";
            var link = args.Length > 0 ? args[0] : throw new ArgumentNullException();
            //var x = link ?? throw new ArgumentException("What's wrong with u? URL can't be null.");
            if (link == null) {
                throw new ArgumentException("What's wrong with u? URL can't be null.");
            }
            var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.GetAsync(link);
                httpClient.Dispose();

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);
                    var emails = regex.Matches(content);
                    foreach (var item in emails)
                    {
                        Console.WriteLine("Email: {0}", item);
                    }
                }
            }
            catch (Exception) {
                Console.WriteLine("Error while downloading the page");
            }
            Console.ReadKey();
        }
    }
}
