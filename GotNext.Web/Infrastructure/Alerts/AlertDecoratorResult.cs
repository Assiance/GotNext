using System.Web.Mvc;

namespace GotNext.Web.Infrastructure.Alerts
{
    public class AlertDecoratorResult : ActionResult
    {
        public ActionResult InneResult { get; set; }
        public string AlertClass { get; set; }
        public string Message { get; set; }

        public AlertDecoratorResult(ActionResult inneResult, string alertClass, string message)
        {
            InneResult = inneResult;
            AlertClass = alertClass;
            Message = message;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var alerts = context.Controller.TempData.GetAlerts();
            alerts.Add(new Alert(AlertClass, Message));
            InneResult.ExecuteResult(context);
        }
    }
}