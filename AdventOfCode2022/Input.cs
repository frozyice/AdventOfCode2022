namespace AdventOfCode2022;

public class Input
{
    public async Task<string[]> ReadLines(int day)
    {
        return (await ReadText(day)).Split("\n");
    }

    public async Task<string> ReadText(int day)
    {
        var session = "";

        using (var httpClient = new HttpClient())
        {
            var year = 2022;

            var url = $"https://adventofcode.com/{year}/day/{day}/input";

            httpClient.DefaultRequestHeaders.Add("Cookie", $"session={session}");

            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"request failed: {response.ReasonPhrase}");
            }

            return (await response.Content.ReadAsStringAsync()).TrimEnd();
        }
    }
}