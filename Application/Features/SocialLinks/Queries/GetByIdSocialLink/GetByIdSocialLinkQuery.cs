using Application.Features.SocialLinks.Dtos;
using Application.Features.SocialLinks.Rules;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Queries.GetByIdSocialLink
{
    public  class GetByIdSocialLinkQuery : IRequest<GetByIdSocialLinkDto>
    {
        public int Id { get; set; }

        public class GetByIdSocialLinkQueryHandler : IRequestHandler<GetByIdSocialLinkQuery, GetByIdSocialLinkDto>
        {
            private readonly ISocialLinkRepository _socialLinkRepository;
            private readonly IMapper _mapper;
            private readonly SocialLinkBusinessRules _socialLinkBusinessRules;

            public GetByIdSocialLinkQueryHandler(ISocialLinkRepository socialLinkRepository, IMapper mapper, SocialLinkBusinessRules socialLinkBusinessRules)
            {
                _socialLinkRepository = socialLinkRepository;
                _mapper = mapper;
                _socialLinkBusinessRules = socialLinkBusinessRules;
            }

            public async Task<GetByIdSocialLinkDto> Handle(GetByIdSocialLinkQuery request, CancellationToken cancellationToken)
            {
                SocialLink? socialLink = await _socialLinkRepository.GetAsync(x=>x.Id==request.Id);
                _socialLinkBusinessRules.SocialLinkShouldExistWhenRequested(socialLink);
                GetByIdSocialLinkDto getByIdSocialLinkDto=_mapper.Map<GetByIdSocialLinkDto>(socialLink); 
                return getByIdSocialLinkDto;
            }
        }
    }
}
