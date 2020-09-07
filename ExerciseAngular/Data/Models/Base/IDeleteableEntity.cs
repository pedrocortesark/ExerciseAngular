using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseAngular.Data.Models.Base
{
    public interface IDeleteableEntity : IEntity
    {
        DateTime? DeletedOn { get; set; }

        bool IsDeleted { get; set; }

        string DeletedBy { get; set; }


    }
}
