using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GotNext.Core.Mapping;

namespace GotNext.Model.Models.Domain.Authentication
{
    public class Registration
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
