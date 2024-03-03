using System.Text.Json.Serialization;

namespace Api.Modules.Group.Core;

public class Balance
{
    [JsonPropertyName("currency_code")]
    public string? CurrencyCode { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }
}
