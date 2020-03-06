using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelloCS
{
    public class Program{
        public static async Task Main(string[] args){
            var link = args[0];
            var httpClient = new HttpClient();
            var response =  await httpClient.GetAsync(link);
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]", RegexOptions.IgnoreCase);
                var emails = regex.Matches(content);
                foreach (var item in emails){
                    Console.WriteLine("Email: {0}", item);
                }
            }
            
            Console.ReadKey();
        }
    }
}
