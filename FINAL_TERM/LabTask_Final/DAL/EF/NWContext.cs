﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class NWContext : DbContext
    {
        public DbSet<News> News { get; set; }
    }
}
