using RestSharp;

var handler = new HttpClientHandler()
{
    UseProxy = false
};

Console.Write("Введите имя файла: ");
string file = Console.ReadLine();
var options = new RestClientOptions("https://www.virustotal.com/api/v3/files");
var client = new RestClient(new HttpClient(handler), options);
var request = new RestRequest("");
request.AlwaysMultipartFormData = true;
request.AddHeader("accept", "application/json");
request.AddHeader("x-apikey", "2d8df21cbfa87ac1c013f755f08c19dfe1016d6494398d59fb30d5f096f7a893");
request.AddHeader("content-type", "multipart/form-data");
request.FormBoundary = "---011000010111000001101001";
request.AddFile("file", @"C:\mylog.log");

var response = await client.PostAsync(request);

Console.WriteLine("{0}", response.Content);
