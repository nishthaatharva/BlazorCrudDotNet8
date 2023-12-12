using System.ComponentModel.DataAnnotations;

namespace BlazorCrudDotNet8.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
    }
}
