using System.Collections.Generic;
using System.Threading.Tasks;
using TertiaryMusicAwardsMobile.Models;

namespace TertiaryMusicAwardsMobile.Services
{
    public interface IWebServices
    {
        Task<List<AwardCategory>> GetAwardCategoriesAsync();
        Task<List<Nominee>> GetNominees();
        Task<bool> PerformVoting(Vote model);
        Task<List<Nominee>> GetCategoryNominees(int categoryId);
    }
}
