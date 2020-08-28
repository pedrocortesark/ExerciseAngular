


using ExerciseAngular.Data;

namespace ExerciseAngular.Controllers
{
    using System.Threading.Tasks;
    using Models.Cats;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Infraestructure;
    using ExerciseAngular.Data.Models;
    


    public class CatsController : ApiController
    {
        private readonly CatstagramDbContext _context;

        public CatsController(CatstagramDbContext context)
        {
            this._context = context;
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Create(CreateCatsRequestModel model)
        {
            var userId = this.User.GetId();
            var cat = new Cat
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId,
            };

            this._context.Add(cat);

            await this._context.SaveChangesAsync();

            return Created(nameof(this.Create), cat.Id);
        }
    }
}
