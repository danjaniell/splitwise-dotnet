using System;
using System.Text.Json.Serialization;

namespace Api.Modules.Group.Core;

public class SimplifiedDebt
{
    [JsonPropertyName("from")]
    public decimal From { get; set; }

    [JsonPropertyName("to")]
    public decimal To { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("currency_code")]
    public string? CurrencyCode { get; set; }
}
