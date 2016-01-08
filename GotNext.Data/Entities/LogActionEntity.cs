using System;
using System.Data.Entity.ModelConfiguration;
using GotNext.Data.Entities.User;

namespace GotNext.Data.Entities
{
    public class LogActionEntity
    {
        public int Id { get; set; }
        public DateTime PerformedAt { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public ApplicationUserEntity PerformedBy { get; set; }
        public string Description { get; set; }

        public LogActionEntity(ApplicationUserEntity performedBy, string action, string controller, string description)
        {
            PerformedBy = performedBy;
            Action = action;
            Controller = controller;
            Description = description;
            PerformedAt = DateTime.Now;
        } 
    }

    public class LogActionMap : EntityTypeConfiguration<LogActionEntity>
    {
        public LogActionMap()
        {
            ToTable("LogActions");
            HasKey(t => t.Id);
            Property(t => t.PerformedAt).IsRequired();
            Property(t => t.Controller).IsRequired();
            Property(t => t.Action).IsRequired();
            HasRequired(t => t.PerformedBy);
            Property(t => t.Description);
        }
    }
}