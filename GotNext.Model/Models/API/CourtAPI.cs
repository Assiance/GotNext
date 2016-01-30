using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotNext.Model.Models.API
{
    public class CourtApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CourtAddressApi Address { get; set; }
        public SportTypeApi SportType { get; set; }
        public decimal Price { get; set; }
        public bool IsOutDoor { get; set; }
        public string PaymentType { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
