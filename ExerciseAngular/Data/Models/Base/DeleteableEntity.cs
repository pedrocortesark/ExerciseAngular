using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseAngular.Data.Models.Base
{
    public abstract class DeleteableEntity : Entity, IDeleteableEntity
    {
        public DateTime? DeletedOn { get ; set ; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get ; set ; }
    }
}
