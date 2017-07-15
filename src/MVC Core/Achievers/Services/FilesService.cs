﻿using Achievers.Data;
using Achievers.Data.Models;
using Achievers.Services.Interfaces;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Achievers.Services
{
    public class FilesService : BaseService, IFilesService
    {
        public FilesService(AchieversDbContext data)
            : base(data)
        {
        }

        public async Task<File> FindAsync(int id)
        {
            return await this.Data
                .Files
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(File file)
        {
            this.Data.Add(file);
            await this.Data.SaveChangesAsync();

            return file.Id;
        }
    }
}
