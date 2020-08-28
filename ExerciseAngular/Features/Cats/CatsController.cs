




namespace ExerciseAngular.Features.Cats
{

    using Data;
    using Data.Models;
    using Infraestructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;


    public class CatsController : ApiController
    {
        private readonly ICatService _catService;

        public CatsController(ICatService catService)
        {
            this._catService = catService;
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Create(CreateCatsRequestModel model)
        {
            var userId = this.User.GetId();
            var id = this._catService.Create(model.ImageUrl, model.Description, userId);
            

            return Created(nameof(this.Create), id);
        }
    }
}
