namespace ExerciseAngular.Features.Cats
{
    using ExerciseAngular.Features.Cats.Models;
    using ExerciseAngular.Infraestructure.Extensions;
    using Infraestructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using static Infraestructure.WebConstants;

    [Authorize]
    public class CatsController : ApiController
    {
        private readonly ICatService _catService;

        public CatsController(ICatService catService)
        {
            this._catService = catService;
        }

        [HttpGet]
        public async Task<IEnumerable<CatListingServiceModel>> Mine()
        {
            var userId = this.User.GetId();

            return await this._catService.ByUser(userId);

        }


        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CatDetailsServiceModel>> Details(int id)
        {
            return await this._catService.Details(id);
        }
        
        [HttpPost]
        public async Task<ActionResult> Create(CreateCatsRequestModel model)
        {
            var userId = this.User.GetId();

            var id = await this._catService.Create(model.ImageUrl, model.Description, userId);
            
            return Created(nameof(this.Create), id);
        }

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.User.GetId();

            var deleted = await this._catService.Delete(id, userId);

            if (!deleted) return BadRequest();

            return Ok();

        }

        [HttpPut]
        public async Task<ActionResult> Edit(UpdateCatRequestModel model)
        {
            var userId = this.User.GetId();

            var updated = await this._catService.Update(model.Id, model.Description, userId);

            if (!updated) return BadRequest();

            return Ok();
        }
    }
}
