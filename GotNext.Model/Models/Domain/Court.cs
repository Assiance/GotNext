﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GotNext.Core.Mapping;
using GotNext.Model.Models.API;

namespace GotNext.Model.Models.Domain
{
    public class Court : IMapFrom<CourtAPi>, IMapTo<CourtAPi>
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