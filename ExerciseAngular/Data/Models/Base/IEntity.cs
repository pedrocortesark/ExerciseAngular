using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseAngular.Data.Models.Base
{
    public interface IEntity
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifyOn { get; set; }

        [Required]
        string CreatedBy { get; set; }

        string ModifyBy { get; set; }
    }
}
