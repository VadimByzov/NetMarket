using System;
using System.Net.Http;

try
{
    var url = "https://localhost:7116/helloworld";
    var client = new HttpClient();

    for (int i = 0; i < 10000; i++)
    {
        var response = await client.GetAsync(url);
        var contentString = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"{i}: {contentString}");
    }

    Console.ReadKey();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

