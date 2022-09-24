using Application.Services;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }
        public async Task TechnologyNameCanNotBeRepeated(string name)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(x=>x.Name==name);
            if (result.Items.Any()) throw new BusinessException("Technology name exist.");
        }
        public void TechnologyShouldExistWhenrequest(Technology technology)
        {
            if (technology == null) throw new BusinessException("Requested Technology does not exist.");
        }
        public async Task TechnologyIdShouldBeExist(int id)
        {
            var result = await _technologyRepository.GetListAsync(x=>x.Id==id);
            if (!result.Items.Any()) throw new BusinessException("Technology not found");
        }

    }
}
