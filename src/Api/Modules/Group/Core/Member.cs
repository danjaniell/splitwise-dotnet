using System.Text.Json.Serialization;
using Api.Modules.Users.Core;

namespace Api.Modules.Group.Core
{
    public class Member : User
    {
        [JsonPropertyName("balance")]
        public List<Balance> Balance { get; set; } = [];
    }
}
