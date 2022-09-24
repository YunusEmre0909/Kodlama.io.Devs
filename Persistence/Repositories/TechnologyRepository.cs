﻿using Application.Services;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TechnologyRepository : EfRepositoryBase<Technology,BaseDbContext>,ITechnologyRepository
    {
        public TechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
