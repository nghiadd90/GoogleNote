using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace GoogleNote.Core.Models
{
    public class LoginResult
    {
        [JsonPropertyName("user")]
        public UserResult User { get; set; }

        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        // [JsonPropertyName("refreshToken")]
        // public string RefreshToken { get; set; }
        public LoginResult(User user, string token)
        {
            User = new UserResult(user.Id, user.Email);
            AccessToken = token;
        }

    }

    public class UserResult
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        public UserResult(int id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}
