using System;
using Newtonsoft.Json;

namespace ParcelClient.Models
{
    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int  Expires { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}
