using System.Text.Json.Serialization;

namespace Api.Modules.Users.Core;

public class Notifications
{
    [JsonPropertyName("added_as_friend")]
    public bool AddedAsFriend { get; set; }

    [JsonPropertyName("added_to_group")]
    public bool AddedToGroup { get; set; }

    [JsonPropertyName("expense_added")]
    public bool ExpenseAdded { get; set; }

    [JsonPropertyName("expense_updated")]
    public bool ExpenseUpdated { get; set; }

    public bool Bills { get; set; }

    public bool Payments { get; set; }

    [JsonPropertyName("monthly_summary")]
    public bool MonthlySummary { get; set; }

    public bool Announcements { get; set; }
}
