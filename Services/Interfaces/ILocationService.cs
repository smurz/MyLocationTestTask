﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLocation.Services.Interfaces
{
    public interface ILocationService
    {
        Task<string?> GetCurrentLocationAsync();
    }
}
