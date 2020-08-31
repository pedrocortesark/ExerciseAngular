﻿
using System.ComponentModel.DataAnnotations;

namespace ExerciseAngular.Features.Cats.Models
{
    using static Data.Validation.Cat;

    public class UpdateCatRequestModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
