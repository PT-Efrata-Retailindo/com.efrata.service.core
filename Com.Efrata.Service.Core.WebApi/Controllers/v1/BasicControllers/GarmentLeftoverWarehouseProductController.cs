﻿using AutoMapper;
using Com.Efrata.Service.Core.Lib.Helpers.IdentityService;
using Com.Efrata.Service.Core.Lib.Helpers.ValidateService;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services.GarmentLeftoverWarehouseProduct;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.WebApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/garment-leftover-warehouse-products")]
    [Authorize]
    public class GarmentLeftoverWarehouseProductController : BaseController<GarmentLeftoverWarehouseProductModel, GarmentLeftoverWarehouseProductViewModel, IGarmentLeftoverWarehouseProductService>
    {
        public GarmentLeftoverWarehouseProductController(IIdentityService identityService, IValidateService validateService, IGarmentLeftoverWarehouseProductService service, IMapper mapper) : base(identityService, validateService, service, mapper, "1.0.0")
        {
        }
    }
}
