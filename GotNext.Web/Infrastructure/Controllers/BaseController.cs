using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using GotNext.Web.Infrastructure.ActionResults;
using Microsoft.Web.Mvc;

namespace GotNext.Web.Infrastructure.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ActionResult RedirectToAction<TController>(Expression<Action<TController>> action)
            where TController : Controller
        {
            return ControllerExtensions.RedirectToAction(this, action);
        }

        [Obsolete("Do not use the standard Json helpers to return Json Data to the client. Use StandardJsonResult.")]
        protected JsonResult Json<T>(T data)
        {
            throw new InvalidOperationException("Do not use the standard Json helpers to return Json Data to the client. Use StandardJsonResult.");
        }

        protected StandardJsonResult JsonValidationError()
        {
            var result = new StandardJsonResult();

            foreach (var validationError in ModelState.Values.SelectMany(v => v.Errors))
            {
                result.AddError(validationError.ErrorMessage);
            }
            return result;
        }

        protected StandardJsonResult JsonError(string errorMessage)
        {
            var result = new StandardJsonResult();

            result.AddError(errorMessage);

            return result;
        }

        protected StandardJsonResult<T> JsonSuccess<T>(T data)
        {
            return new StandardJsonResult<T> { Data = data };
        }
    }
}