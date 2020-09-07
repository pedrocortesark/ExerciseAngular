

namespace ExerciseAngular.Features.Cats
{
    using ExerciseAngular.Features.Cats.Models;
    using ExerciseAngular.Infraestructure.Service;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using static Infraestructure.WebConstants;

    [Authorize]
    public class CatsController : ApiController
    {
        private readonly ICatService _cats;

        private readonly ICurrentUserService _currentUser;

        public CatsController(ICatService cats, ICurrentUserService currentUser)
        {
            this._cats = cats;
            this._currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IEnumerable<CatListingServiceModel>> Mine()
        {
            var userId = this._currentUser.GetId();

            return await this._cats.ByUser(userId);

        }


        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CatDetailsServiceModel>> Details(int id)
        {
            return await this._cats.Details(id);
        }
        
        [HttpPost]
        public async Task<ActionResult> Create(CreateCatsRequestModel model)
        {
            var userId = this._currentUser.GetId();

            var id = await this._cats.Create(model.ImageUrl, model.Description, userId);
            
            return Created(nameof(this.Create), id);
        }

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this._currentUser.GetId();

            var deleted = await this._cats.Delete(id, userId);

            if (!deleted) return BadRequest();

            return Ok();

        }

        [HttpPut]
        public async Task<ActionResult> Edit(UpdateCatRequestModel model)
        {
            var userId = this._currentUser.GetId();

            var updated = await this._cats.Update(model.Id, model.Description, userId);

            if (!updated) return BadRequest();

            return Ok();
        }
    }
}
