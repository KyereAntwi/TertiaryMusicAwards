using Newtonsoft.Json;
using System.Collections.Generic;

namespace TertiaryMusicAwardsMobile.Models
{
    public class AwardCategory
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Nominee> CategoryNominees { get; set; }
    }
}
