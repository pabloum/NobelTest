namespace App.Domain;

public class CodingResources
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public IEnumerable<string> Types { get; set; } = Enumerable.Empty<string>();
    public IEnumerable<string> Topics { get; set; } = Enumerable.Empty<string>();
    public IEnumerable<string> Levels { get; set; } = Enumerable.Empty<string>();
}