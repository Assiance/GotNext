using System.ComponentModel.DataAnnotations;

namespace GotNext.Model.Models.Domain.Account
{
    public class RegisterExternalModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}