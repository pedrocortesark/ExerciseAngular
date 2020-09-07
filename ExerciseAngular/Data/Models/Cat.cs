namespace ExerciseAngular.Data.Models
{
    using ExerciseAngular.Data.Models.Base;
    using System.ComponentModel.DataAnnotations;
    using static Validation.Cat;

    public class Cat: DeleteableEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
