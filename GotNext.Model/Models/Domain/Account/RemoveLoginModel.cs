using System.ComponentModel.DataAnnotations;

namespace GotNext.Model.Models.Domain.Account
{
    public class RemoveLoginModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }
}