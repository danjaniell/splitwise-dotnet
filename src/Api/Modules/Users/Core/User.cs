using System.Text.Json.Serialization;

namespace Api.Modules.Users.Core;

public class UserResponse
{
    public User? User { get; set; }
}

public class User
{
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    public string? Email { get; set; }

    [JsonPropertyName("default_currency")]
    public string? DefaultCurrency { get; set; }

    public string? Locale { get; set; }

    public Picture? Picture { get; set; }

    [JsonPropertyName("custom_picture")]
    public bool CustomPicture { get; set; }

    [JsonPropertyName("registration_status")]
    public string? RegistrationStatus { get; set; }

    [JsonPropertyName("force_refresh_at")]
    public DateTime? ForceRefreshAt { get; set; }

    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("date_format")]
    public string? DateFormat { get; set; }

    [JsonPropertyName("default_group_id")]
    public int DefaultGroupId { get; set; }

    [JsonPropertyName("notifications_read")]
    public DateTime? NotificationsRead { get; set; }

    [JsonPropertyName("notifications_count")]
    public int NotificationsCount { get; set; }

    public Notifications? Notifications { get; set; }
}
