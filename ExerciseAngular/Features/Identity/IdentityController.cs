

namespace ExerciseAngular.Features.Identity
{
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using ExerciseAngular.Features.Identity.Models;


    public class IdentityController: ApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly AppSettings _appSettings;
        private readonly IIdentityService _identity;
        

        public IdentityController(UserManager<User> userManager, IIdentityService identity, IOptions<AppSettings> appSettings)
        {
            this._userManager = userManager;
            this._appSettings = appSettings.Value;
            this._identity = identity;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var user = new User()
            {
                Email = model.Email,
                UserName = model.Username
            };
            var result = await this._userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await this._userManager.FindByNameAsync(model.Username);
            if (user == null) return Unauthorized();

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid) return Unauthorized();

            var encryptedToken = this._identity.GenerateJwtToken(user.Id, user.UserName, this._appSettings.Secret);

            return new LoginResponseModel
            {
                Token = encryptedToken
            };

        }

    }
}
