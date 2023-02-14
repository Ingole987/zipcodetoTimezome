using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using (var client = new HttpClient())
        {
            // specify the URI of the request
            string uri = "https://jsonplaceholder.typicode.com/posts";

            // get the request body from the POST request made in Postman
            string requestBody = await Console.In.ReadToEndAsync();

            // deserialize the request body as a dynamic object
            dynamic post = JsonSerializer.Deserialize<dynamic>(requestBody);

            // serialize the dynamic object as JSON and create a StringContent object
            string json = JsonSerializer.Serialize(post);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // send the POST request with the request body
            HttpResponseMessage response = await client.PostAsync(uri, content);

            // read the response content as a string
            string responseContent = await response.Content.ReadAsStringAsync();

            // output the response content to the console
            Console.WriteLine(responseContent);
        }
    }
}
