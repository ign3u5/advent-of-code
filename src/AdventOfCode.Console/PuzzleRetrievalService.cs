public class PuzzleRetrievalService : IPuzzleRetrievalService
{
    private readonly HttpClient _httpClient;
    private readonly AssetsOptions _assetOptions;

    public PuzzleRetrievalService(HttpClient httpClient, AssetsOptions assetsOptions)
    {
        _httpClient = httpClient;
        _assetOptions = assetsOptions;
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }

    public async Task<string[]> GetInputLines(int year, int day)
    {
        var path = GetPath(year, day);
        var response = await _httpClient.GetAsync(path);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return content.Split('\n');
    }

    private string GetPath(int year, int day) => _assetOptions.PuzzlePathPattern?
        .Replace("{year}", year.ToString())
        .Replace("{day}", $"{day:0}") ?? throw new InvalidOperationException("PuzzlePathPattern is null");
}

public interface IPuzzleRetrievalService : IDisposable
{
    Task<string[]> GetInputLines(int year, int day);
}