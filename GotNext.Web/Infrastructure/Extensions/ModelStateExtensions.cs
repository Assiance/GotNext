using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using GotNext.Model.Models;

namespace GotNext.Web.Infrastructure.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddErrors(this ModelStateDictionary modelState, BaseModel model)
        {
            foreach (var errorMessage in model.ErrorMessages)
            {
                modelState.AddModelError(String.Empty, errorMessage);
            }
        }
    }
}