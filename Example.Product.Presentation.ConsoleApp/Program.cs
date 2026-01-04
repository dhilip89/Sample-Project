using RestSharp;

namespace Example.Product.Presentation.ConsoleApp
{
    internal class Program
    {
        static RestClient Api = ConfigureRestClient();

        static async Task Main(string[] args)
        {
            await Task.Delay(3000);

            var request1 = new RestRequest("/api/items").AddBody(
                new
                {
                    Name = "Test",
                    Description = "Hello World",
                    Price = 102.34d
                }
            );

            var response1 = await Api.ExecutePostAsync(request1);


            var request2 = new RestRequest("/api/items");

            var response2 = await Api.GetAsync(request2);

            Console.WriteLine(response2.Content);

            Console.ReadLine();
        }

        static RestClient ConfigureRestClient()
        {
            var options = new RestClientOptions("http://localhost:5211");
            var client = new RestClient(options);

            return client;
        }
    }
}
