using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseAngular.Infraestructure.Service
{
    public interface ICurrentUserService
    {
        string GetUserName();

        string GetId();

    }
}
