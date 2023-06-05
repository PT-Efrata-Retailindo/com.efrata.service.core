using Microsoft.AspNetCore.Mvc;
using Com.Efrata.Service.Core.Lib;
using Com.Efrata.Service.Core.Lib.Services;
using Com.Efrata.Service.Core.WebApi.Helpers;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Lib.Models.Account_and_Roles;

namespace Com.Efrata.Service.Core.WebApi.Controllers.v1.UploadControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/master/upload-menus")]
    public class MenusUploadController : BasicUploadController<MenuService, Menus, MenuViewModel, MenuService.MenuMap, CoreDbContext>
    {
        private static readonly string ApiVersion = "1.0";
        public MenusUploadController(MenuService service) : base(service, ApiVersion)
        {
        }
    }
}
