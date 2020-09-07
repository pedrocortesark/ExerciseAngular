

namespace ExerciseAngular.Data.Models
{
    using ExerciseAngular.Data.Models.Base;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User: IdentityUser, IEntity
    {
        public IEnumerable<Cat> Cats { get; } = new HashSet<Cat>();

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifyOn { get; set; }

        
        public string CreatedBy { get; set; }

        public string ModifyBy { get; set; }
    }
}
