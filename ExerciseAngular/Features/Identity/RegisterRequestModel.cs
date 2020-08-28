using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExerciseAngular.Features.Identity
{
    public class RegisterRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required] 
        public string Email { get; set; }


    }
}
