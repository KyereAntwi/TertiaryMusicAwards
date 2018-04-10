using Newtonsoft.Json;

namespace TertiaryMusicAwardsMobile.Models
{
    public class Vote
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        public string PhoneIPAdress { get; set; }
        public int NomineeId { get; set; }
        public int CategoryId { get; set; }
    }
}
