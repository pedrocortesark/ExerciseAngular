using ExerciseAngular.Data;
using ExerciseAngular.Data.Models;
using ExerciseAngular.Features.Cats.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseAngular.Features.Cats
{
    public class CatService : ICatService
    {
        private readonly CatstagramDbContext _context;

        public CatService(CatstagramDbContext context)
        {
            this._context = context;
        }

        public async Task<int> Create(string imageUrl, string description, string userId)
        {
            var cat = new Cat
            {
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId,
            };

            this._context.Add(cat);
            await this._context.SaveChangesAsync();

            return cat.Id;
        }

        public async Task<IEnumerable<CatListingServiceModel>> ByUser(string userId)
           
            =>  await this._context.Cats
                .Where(c => c.UserId == userId)
                .OrderByDescending(c=>c.CreatedOn)
                .Select(c => new CatListingServiceModel
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();

        public async Task<CatDetailsServiceModel> Details(int id)
            => await this._context.Cats
                .Where(c => c.Id == id)
                .Select(c => new CatDetailsServiceModel
                {
                    Id = c.Id,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    UserName = c.User.UserName

                })
                .FirstOrDefaultAsync();

        public async Task<bool> Update(int id, string description, string userId)
        {
            var cat = await this.ByIdAndByUser(id, userId);

            if (cat == null) return false;

            cat.Description = description;
            await this._context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id, string userId)
        {
            var cat = await this.ByIdAndByUser(id, userId);

            if (cat == null) return false;

            this._context.Cats.Remove(cat);
            await this._context.SaveChangesAsync();

            return true;
        }

        private async Task<Cat> ByIdAndByUser(int id, string userId)
        {
            return await this._context.Cats
                .Where(c => c.UserId == userId && c.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
