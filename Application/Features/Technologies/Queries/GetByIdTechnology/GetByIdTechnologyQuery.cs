using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Rules;
using Application.Services;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQuery : IRequest<GetByIdTechnologyDto>
    {
        public int Id { get; set; }


        public class GetByIdTechnoogyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, GetByIdTechnologyDto>
        {
            private readonly ITechnologyRepository _technoloyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public GetByIdTechnoogyQueryHandler(ITechnologyRepository technoloyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technoloyRepository = technoloyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<GetByIdTechnologyDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
            {

                Technology? technology = await _technoloyRepository.GetAsync(x=>x.Id==request.Id,
                                                                                    include: x=>x.Include(t=>t.ProgrammingLanguage));
                _technologyBusinessRules.TechnologyShouldExistWhenrequest(technology);

                GetByIdTechnologyDto getByIdTechnologyDto =_mapper.Map<GetByIdTechnologyDto>(technology);
                return getByIdTechnologyDto;
            }
        }
    }
}
