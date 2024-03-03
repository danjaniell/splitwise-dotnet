using System.Text.Json.Serialization;

namespace Api.Modules.Users.Core.DTO
{
    public class UserUpdate
    {
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        [JsonPropertyName("default_currency")]
        public string? DefaultCurrency { get; set; }
        public string? Locale { get; set; }
    }
}
