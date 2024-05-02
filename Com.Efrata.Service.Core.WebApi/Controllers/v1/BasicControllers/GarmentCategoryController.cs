using Com.Efrata.Service.Core.Lib;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/garment-categories")]
    public class GarmentCategoryController : BasicController<GarmentCategoryService, GarmentCategory, GarmentCategoryViewModel, CoreDbContext>
    {
        private new static readonly string ApiVersion = "1.0";
        GarmentCategoryService service;
        public GarmentCategoryController(GarmentCategoryService service) : base(service, ApiVersion)
        {
            this.service = service;
        }

        [HttpGet("byId")]
        public IActionResult GetByIds([Bind(Prefix = "garmentCategoryList[]")]List<int> garmentCategoryList)
        {
            try
            {

                service.Username = User.Claims.Single(p => p.Type.Equals("username")).Value;

                List<GarmentCategory> Data = service.GetByIds(garmentCategoryList);

                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.OK_STATUS_CODE, General.OK_MESSAGE)
                    .Ok(Data);

                return Ok(Result);
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpGet("byName")]
        public IActionResult GetByName(string name)
        {
            try
            {

                service.Username = User.Claims.Single(p => p.Type.Equals("username")).Value;

                GarmentCategory Data = service.GetByName(name);

                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.OK_STATUS_CODE, General.OK_MESSAGE)
                    .Ok(Data);

                return Ok(Result);
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpGet("byCode")]
        //public IActionResult GetByCodes(string code)
        public IActionResult GetByCodes([Bind(Prefix = "garmentCategoryList[]")]List<string> garmentCategoryList)
        {
            try
            {

                service.Username = User.Claims.Single(p => p.Type.Equals("username")).Value;

                List<GarmentCategory> Data = service.GetByCode(garmentCategoryList);

                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.OK_STATUS_CODE, General.OK_MESSAGE)
                    .Ok(Data);

                return Ok(Result);
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpGet("join-by-product")]
        public IActionResult JoinByProduct(int Page = 1, int Size = 25, string Order = "{}", [Bind(Prefix = "Select[]")] List<string> Select = null, string Keyword = "", string Filter = "{}")
        {
            try
            {
                Tuple<List<GarmentProductViewModel>, int, Dictionary<string, string>> Data = Service.JoinProductCode(Page, Size, Order, Keyword, Filter);

                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.OK_STATUS_CODE, General.OK_MESSAGE)
                    .Ok<GarmentProductViewModel>(Data.Item1, Page, Size, Data.Item2, Data.Item1.Count, Data.Item3, new List<string>());

                return Ok(Result);
            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new ResultFormatter(ApiVersion, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }
    }
}