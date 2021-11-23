﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pttapi.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Models.OilDetail> OilDetailTBl { get; set; }
        public DbSet<Models.OilPrice> OilPriceTBl { get; set; }
    }
}
