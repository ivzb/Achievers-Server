﻿using Achievers.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Achievers.Services.Interfaces
{
    public interface IFilesService
    {
        Task<int> CreateAsync(File file);
    }
}
