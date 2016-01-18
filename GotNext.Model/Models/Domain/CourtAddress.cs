using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotNext.Model.Models.Domain
{
    class CourtAddress
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string Country { get; set; }


        public CourtAddress(string city, string state, string zipCode, string streetLine1, string streetLine2, string country)
        {
            City = city;
            State = state;
            ZipCode = zipCode;
            StreetLine1 = streetLine1;
            StreetLine2 = streetLine2;
            Country = country;
        }
        
    }
}
