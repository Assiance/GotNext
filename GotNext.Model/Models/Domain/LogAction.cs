using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotNext.Model.Models.Domain
{
    public class LogAction
    {
        public int Id { get; set; }
        public DateTime PerformedAt { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public User PerformedBy { get; set; }
        public string Description { get; set; }

        public LogAction(User performedBy, string action, string controller, string description)
        {
            PerformedBy = performedBy;
            Action = action;
            Controller = controller;
            Description = description;
            PerformedAt = DateTime.Now;
        }
    }
}
