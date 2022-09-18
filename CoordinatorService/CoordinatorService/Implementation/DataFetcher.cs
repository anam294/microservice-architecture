using System.Text.Json;
using CoordinatorService.Abstraction;
using CoordinatorService.Dto;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace CoordinatorService.Implementation;

public class DataFetcher : IDataFetcher
{
    private const string AuthSecret = "";
    private const string BasePath = "";
    private readonly FirebaseClient _firebaseClient;

    public DataFetcher()
    {
        IFirebaseConfig firebaseConfig = new FirebaseConfig()
        {
            AuthSecret = AuthSecret,
            BasePath = BasePath
        };
        
        _firebaseClient = new FirebaseClient(firebaseConfig);
    }

    public ResponseDto? FetchData(string id)
    {
        var data = _firebaseClient.Get("Test/"+id);
        return JsonSerializer.Deserialize<ResponseDto>(data.Body);
    }
}
