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

namespace Application.Features.SocialLinks.Commands.CreateSocialLink
{
    public class CreateSocialLinkCommand : IRequest<CreatedSocialLinkDto>
    {
        public string GithubLink { get; set; }


        public class CreateSociallinkCommandHandler : IRequestHandler<CreateSocialLinkCommand, CreatedSocialLinkDto>
        {
            private readonly ISocialLinkRepository _socialLinkRepository;
            private readonly IMapper _mapper;
            private readonly SocialLinkBusinessRules _socialLinkBusinessRules;

            public CreateSociallinkCommandHandler(ISocialLinkRepository socialLinkRepository, IMapper mapper, SocialLinkBusinessRules socialLinkBusinessRules)
            {
                _socialLinkRepository = socialLinkRepository;
                _mapper = mapper;
                _socialLinkBusinessRules = socialLinkBusinessRules;
            }

            public async Task<CreatedSocialLinkDto> Handle(CreateSocialLinkCommand request, CancellationToken cancellationToken)
            {
                await _socialLinkBusinessRules.GithubLinkCanNotBeRepeated(request.GithubLink);
                SocialLink mappedSocialLink = _mapper.Map<SocialLink>(request);
                SocialLink createdSocialLink=await _socialLinkRepository.AddAsync(mappedSocialLink);
                CreatedSocialLinkDto createdSocialLinkDto = _mapper.Map<CreatedSocialLinkDto>(createdSocialLink);
                return createdSocialLinkDto;
            }
        }
    }
}
