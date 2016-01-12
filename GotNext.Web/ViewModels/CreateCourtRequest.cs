using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using GotNext.Core.Mapping;
using GotNext.Model.Models.Domain;

namespace GotNext.Web.ViewModels
{
    public class CreateCourtRequest : IMapFrom<Court>, IMapTo<Court>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public bool IsOutDoor { get; set; }
        public string PaymentType { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; } 
    }
}