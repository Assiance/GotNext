using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using GotNext.Core.Mapping;
using GotNext.Model.Models.API;
using GotNext.Model.Models.Domain;

namespace GotNext.Web.ViewModels
{
    public class CreateCourtRequest : IHaveCustomMappings
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsOutDoor { get; set; }
        public string PaymentType { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        [MaxLength(30)]
        public string City { get; set; }
        [Required]
        [MaxLength(30)]
        public string State { get; set; }
        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string StreetLine1 { get; set; }
        [MaxLength(50)]
        public string StreetLine2 { get; set; }
        [Required]
        [MaxLength(30)]
        public string Country { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            Mapper.CreateMap<CreateCourtRequest, Court>()
                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => new CourtAddress()
                {
                    City = src.City,
                    Country = src.Country,
                    State = src.State,
                    StreetLine1 = src.StreetLine1,
                    StreetLine2 = src.StreetLine2,
                    ZipCode = src.ZipCode
                }));
        }
    }
}