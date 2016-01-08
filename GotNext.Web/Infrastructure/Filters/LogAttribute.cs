using System.Collections.Generic;
using System.Web.Mvc;
using GotNext.Domain;
using GotNext.Domain.Managers.Interfaces;
using GotNext.Domain.Services.Interfaces;
using GotNext.Model.Models.Domain;
using GotNext.Web.Infrastructure.Services.Interfaces;

namespace GotNext.Web.Infrastructure.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        private IDictionary<string, object> _parameters;

        public ILogManager LogManager { get; set; }
        public ICurrentUserService CurrentUserService { get; set; }
        public IMemberManager MemberManager { get; set; }
        public string Description { get; set; }

        public LogAttribute(string description)
        {
            Description = description;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _parameters = filterContext.ActionParameters;

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var description = Description;

            foreach (var keyValuePair in _parameters)
            {
                description = description.Replace("{" + keyValuePair.Key + "}", keyValuePair.Value.ToString());
            }

            var logAction = new LogAction(CurrentUserService.GetCurrentUser(), filterContext.ActionDescriptor.ActionName, 
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, description);

            LogManager.LogControllerAction(logAction);
        }
    }
}