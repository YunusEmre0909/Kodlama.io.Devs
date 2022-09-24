using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public  class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
    {
        public int Id { get; set; }
        public string  Name { get; set; }

        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper,TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRules.TechnologyIdShouldBeExist(request.Id);
                Technology? technology = await _technologyRepository.GetAsync(x=>x.Id==request.Id);

                _technologyBusinessRules.TechnologyShouldExistWhenrequest(technology);
                var mappedTechnology = _mapper.Map(request,technology);
                Technology updateTechnology = await _technologyRepository.UpdateAsync(mappedTechnology);
                UpdatedTechnologyDto updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updateTechnology);
                return updatedTechnologyDto;

            }
        }
    }
}
