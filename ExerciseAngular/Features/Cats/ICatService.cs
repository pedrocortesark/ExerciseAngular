
using System.Collections.Generic;

namespace ExerciseAngular.Features.Cats
{
    using ExerciseAngular.Features.Cats.Models;
    using System.Threading.Tasks;

    public interface ICatService
    {
        public Task<int> Create(string imageUrl, string description, string userId);
        public Task<IEnumerable<CatListingServiceModel>> ByUser(string userId);

        public Task<CatDetailsServiceModel> Details(int id);

        public Task<bool> Update(int id, string description, string userId);

        public Task<bool> Delete(int id, string userId);
    }
}
