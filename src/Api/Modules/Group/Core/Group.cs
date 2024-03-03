using System.Text.Json.Serialization;

namespace Api.Modules.Group.Core
{
    public class GroupResponse
    {
        public Group? Group { get; set; }
    }

    public class GroupsResponse
    {
        [JsonPropertyName("groups")]
        public IEnumerable<Group>? Groups { get; set; }
    }

    public class Group
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("group_type")]
        public string? GroupType { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("simplify_by_default")]
        public bool SimplifyByDefault { get; set; }

        [JsonPropertyName("members")]
        public List<Member> Members { get; set; } = [];

        [JsonPropertyName("original_debts")]
        public List<OriginalDebt> OriginalDebts { get; set; } = [];

        [JsonPropertyName("simplified_debts")]
        public List<SimplifiedDebt> SimplifiedDebts { get; set; } = [];

        [JsonPropertyName("invite_link")]
        public string? InviteLink { get; set; }
    }
}
