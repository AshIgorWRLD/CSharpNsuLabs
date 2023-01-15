using System.Net;
using System.Text.Json;
using PrincessChoicer.common.exception;
using PrincessChoicer.common.utils;

namespace PrincessChoicer.common.model.impl;

public class ContentGeneratorImpl : IContentGenerator
{
    private const string NamesFilePath = "../../../../PrincessChoicer/resources/generated-names.txt";
    private const string ApiKeyFileName = "../../../../PrincessChoicer/resources/x-api-key.txt";
    private readonly HttpClient _httpClient;
    private const string NameRequestString = "https://randommer.io/api/Name?quantity=100&nameType=fullname";
    public ContentGeneratorImpl()
    {
        _httpClient = HttpClientInit();
    }
    
    public List<HusbandChallenger> GenerateChallengerList()
    {
        var ratings = GenerateRatings();
        var challengers = new List<HusbandChallenger>();
        var names = GenerateNames();
        {
            for (var i = 0; i < 100; i++)
            {
                challengers.Add(new HusbandChallenger(names[i], ratings[i]));
            }
        }

        return challengers;
    }
    
    private List<string> GenerateNames()
    {
        var names = new List<string>();
        var fullNamesResponse = _httpClient.GetAsync(NameRequestString).Result;

        if (fullNamesResponse.IsSuccessStatusCode)
        {
            var namesFromResponse = GetNamesFromResponse(fullNamesResponse);
            foreach (var nameFromResponse in namesFromResponse)
            {
                names.Add(nameFromResponse);
            }
        }
        else
        {
            Console.WriteLine($"There is problem while getting fullNames from Net: {fullNamesResponse.StatusCode}");
            throw new NamesGettingException(ErrorType.RandomFullNameNetError());
        }

        return names;
    }

    private static List<string> GetNamesFromResponse(HttpResponseMessage namesResponse)
    {
        ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 |
                                                SecurityProtocolType.Tls11 |
                                                SecurityProtocolType.Tls;
        var responseContent = namesResponse.Content.ReadAsStringAsync().Result;
        var names = JsonSerializer.Deserialize<List<string>>(responseContent);

        if (names == null)
        {
            throw new NamesGettingException(ErrorType.RandomFullNameNetError());
        }

        return names;
    }

    private static List<int> GenerateRatings()
    {
        var ratings = new List<int>();
        for(var i = 0; i < 100; i++){
            ratings.Add(i + 1);
        }
        Shuffler.Shuffle(ref ratings);
        return ratings;
    }

    private static HttpClient HttpClientInit()
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("X-Api-Key", File.ReadLines(ApiKeyFileName).First());

        return httpClient;
    }
}