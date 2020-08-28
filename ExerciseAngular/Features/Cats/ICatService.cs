
using System.Threading.Tasks;

namespace ExerciseAngular.Features.Cats
{
    public interface ICatService
    {
        Task<int> Create(string imageUrl, string description, string userId);

    }
}
