using System.Text.Json.Serialization;
using Api.Modules.Group.Core;

namespace Api.Modules.Friends.Core;

public class FriendsResponse
{
    [JsonPropertyName("friends")]
    public IEnumerable<Friend>? Friend { get; set; }
}

public class Friend
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("registration_status")]
    public string? RegistrationStatus { get; set; }

    [JsonPropertyName("groups")]
    public IEnumerable<Group.Core.Group>? Groups { get; set; }

    [JsonPropertyName("balance")]
    public IEnumerable<Balance>? Balance { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
