using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TertiaryMusicAwardsMobile.Models
{
    public class Nominee
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        public string StageName { get; set; }
        public string School { get; set; }
        public string ImageUrl { get { return $"http://localhost:7954/NomineesMVC/GetImage/{Id}"; } }
        public virtual ICollection<AwardCategory> CategoriesBelongTo { get; set; }
    }
}
