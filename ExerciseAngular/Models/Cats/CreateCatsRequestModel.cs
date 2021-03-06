﻿

using ExerciseAngular.Data;

namespace ExerciseAngular.Models.Cats
{
    using System.ComponentModel.DataAnnotations;
    using static Validation.Cat;

    public class CreateCatsRequestModel
    {
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
