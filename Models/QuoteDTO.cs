using System.Text.Json.Serialization;


namespace TakeHomeAssessment.Models;

/// <summary>
/// Fields from the quotes API that are required for the task.
/// </summary>
public class QuoteDTO
{
    /// <summary>
    /// The quote content.
    /// </summary>
    [JsonPropertyName("q")]
    public string Content { get; set; }

    /// <summary>
    /// The quote author.
    /// </summary>
    [JsonPropertyName("a")]
    public string Author { get; set; }
}

[JsonSerializable(typeof(QuoteDTO))]
internal partial class QuotesContext : JsonSerializerContext
{

}