﻿using AutoMapper;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.ViewModels;

namespace Com.Efrata.Service.Core.Lib.AutoMapperProfiles
{
    public class GarmentLeftoverWarehouseProductProfile : Profile
    {
        public GarmentLeftoverWarehouseProductProfile()
        {
            CreateMap<GarmentLeftoverWarehouseProductModel, GarmentLeftoverWarehouseProductViewModel>()
                .ReverseMap();
        }
    }
}
