using System.ComponentModel.DataAnnotations;

namespace GotNext.Model.Models.Domain.Account
{
    public class AddExternalLoginModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }
}