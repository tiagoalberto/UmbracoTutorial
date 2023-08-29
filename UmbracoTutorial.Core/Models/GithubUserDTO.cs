using System.Text.Json.Serialization;

namespace UmbracoTutorial.Core.Models;

public class GithubUserDTO
{
    [JsonPropertyName("githubUserName")]
    public string UserName { get; set; }
    [JsonPropertyName("githubPreferredLanguage")]
    public string PreferredProgrammingLanguage { get; set; }
}