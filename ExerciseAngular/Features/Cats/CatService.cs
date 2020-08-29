using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseAngular.Data;
using ExerciseAngular.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<CatListingResponseModel>> ByUser(string userId)
           
            =>  await this._context.Cats
                .Where(c => c.UserId == userId)
                .Select(c => new CatListingResponseModel
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();
    }
}
