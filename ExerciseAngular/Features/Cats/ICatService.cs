
using System.Collections.Generic;

namespace ExerciseAngular.Features.Cats
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public interface ICatService
    {
        public Task<int> Create(string imageUrl, string description, string userId);
        public Task<IEnumerable<CatListingResponseModel>> ByUser(string userId);
    }
}
