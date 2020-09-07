using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using ExerciseAngular.Infraestructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace ExerciseAngular.Infraestructure.Service
{
    public class CurrentUserService : ICurrentUserService
    {



        private readonly ClaimsPrincipal user;


        public CurrentUserService(IHttpContextAccessor httpContextAccesor)
        {
            this.user = httpContextAccesor.HttpContext?.User;
        }


        public string GetUserName()
        {
            return this.user
                ?.Identity
                ?.Name;
        }


        public string GetId()
        {
            return this.user
                .GetId();
        }
    }
}
