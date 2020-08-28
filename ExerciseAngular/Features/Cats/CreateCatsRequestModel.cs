

using ExerciseAngular.Data;

namespace ExerciseAngular.Features.Cats
{
    using System.ComponentModel.DataAnnotations;
    using static Validation.Cat;

    public class CreateCatsRequestModel
    {
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
