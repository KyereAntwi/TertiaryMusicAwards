using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TertiaryMusicAwardsMobile.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(TertiaryMusicAwardsMobile.Services.WebServicesAsync))]
namespace TertiaryMusicAwardsMobile.Services
{
    public class WebServicesAsync : IWebServices
    {
        private string WebServiceUrl = null;
        public async Task<List<AwardCategory>> GetAwardCategoriesAsync()
        {
            WebServiceUrl = "http://localhost:7954/api/Category/";
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl);
            var categories = JsonConvert.DeserializeObject<List<AwardCategory>>(json);
            return categories;
        }

        public async Task<List<Nominee>> GetCategoryNominees(int categoryId)
        {
            WebServiceUrl = $"http://localhost:7954/api/CategoryNominee/{categoryId}";
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl);
            var nominees = JsonConvert.DeserializeObject<List<Nominee>>(json);
            return nominees;
        }

        public async Task<List<Nominee>> GetNominees()
        {
            WebServiceUrl = "http://localhost:7954/api/Nominees/";
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(WebServiceUrl);
            var nominees = JsonConvert.DeserializeObject<List<Nominee>>(json);
            return nominees;
        }

        public async Task<bool> PerformVoting(Vote model)
        {
            WebServiceUrl = "http://localhost:7954/api/VoteAPI";
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);
            return result.IsSuccessStatusCode;
        }
    }
}
