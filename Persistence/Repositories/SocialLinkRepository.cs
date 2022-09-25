using Application.Services;
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
    public class SocialLinkRepository : EfRepositoryBase<SocialLink, BaseDbContext>, ISocialLinkRepository
    {
        public SocialLinkRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
