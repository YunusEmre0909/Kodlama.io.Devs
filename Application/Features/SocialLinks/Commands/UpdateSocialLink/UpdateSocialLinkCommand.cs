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

namespace Application.Features.SocialLinks.Commands.UpdateSocialLink
{
    public class UpdateSocialLinkCommand : IRequest<UpdatedSocialLinkDto>
    {
        public int Id { get; set; }
        public string GithubLink { get; set; }


        public class UpdateSocialLinkCommandHandler : IRequestHandler<UpdateSocialLinkCommand, UpdatedSocialLinkDto>
        {

            private readonly ISocialLinkRepository _socialLinkRepository;
            private readonly IMapper _mapper;
            private readonly SocialLinkBusinessRules _socialLinkBusinessRules;

            public UpdateSocialLinkCommandHandler(ISocialLinkRepository socialLinkRepository, IMapper mapper, SocialLinkBusinessRules socialLinkBusinessRules)
            {
                _socialLinkRepository = socialLinkRepository;
                _mapper = mapper;
                _socialLinkBusinessRules = socialLinkBusinessRules;
            }

            public async Task<UpdatedSocialLinkDto> Handle(UpdateSocialLinkCommand request, CancellationToken cancellationToken)
            {
                await _socialLinkBusinessRules.SocialLinkIdShouldBeExist(request.Id);
                SocialLink? socialLink = await _socialLinkRepository.GetAsync(x=>x.Id==request.Id);
                _socialLinkBusinessRules.SocialLinkShouldExistWhenRequested(socialLink);

                var mappedSocialLink=_mapper.Map(request, socialLink);
                SocialLink updateSocialLink = await _socialLinkRepository.UpdateAsync(mappedSocialLink);
                UpdatedSocialLinkDto updatedSocialLinkDto = _mapper.Map<UpdatedSocialLinkDto>(updateSocialLink);
                return updatedSocialLinkDto;

            }
        }
    }
}
