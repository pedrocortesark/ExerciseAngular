
using System.Collections.Generic;

namespace ExerciseAngular.Features.Cats
{
    using ExerciseAngular.Features.Cats.Models;
    using System.Threading.Tasks;

    public interface ICatService
    {
        Task<int> Create(string imageUrl, string description, string userId);
        Task<IEnumerable<CatListingServiceModel>> ByUser(string userId);

        Task<CatDetailsServiceModel> Details(int id);

        Task<bool> Update(int id, string description, string userId);

        Task<bool> Delete(int id, string userId);
    }
}
