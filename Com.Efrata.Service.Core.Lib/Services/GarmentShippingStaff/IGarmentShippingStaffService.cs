﻿using Com.Efrata.Service.Core.Lib.Interfaces;
using Com.Efrata.Service.Core.Lib.Models;
using System;
using System.Linq.Expressions;

namespace Com.Efrata.Service.Core.Lib.Services.GarmentShippingStaff
{
    public interface IGarmentShippingStaffService : IBaseService<GarmentShippingStaffModel>
    {
        bool CheckExisting(Expression<Func<GarmentShippingStaffModel, bool>> filter);
    }
}
