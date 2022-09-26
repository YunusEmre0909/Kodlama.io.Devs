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

namespace Application.Features.SocialLinks.Commands.DeleteSocialLink
{
    public class DeleteSocialLinkCommand : IRequest<DeletedSocialLinkDto>
    {
        public int Id { get; set; }

        public class DeleteSocialLinkCommandHandler : IRequestHandler<DeleteSocialLinkCommand, DeletedSocialLinkDto>
        {
            private readonly ISocialLinkRepository _socialLinkRepository;
            private readonly IMapper _mapper;
            private readonly SocialLinkBusinessRules _socialLinkBusinessRules;

            public DeleteSocialLinkCommandHandler(ISocialLinkRepository socialLinkRepository, IMapper mapper, SocialLinkBusinessRules socialLinkBusinessRules)
            {
                _socialLinkRepository = socialLinkRepository;
                _mapper = mapper;
                _socialLinkBusinessRules = socialLinkBusinessRules;
            }

            public async Task<DeletedSocialLinkDto> Handle(DeleteSocialLinkCommand request, CancellationToken cancellationToken)
            {
                SocialLink? socialLink = await _socialLinkRepository.GetAsync(x=>x.Id==request.Id);

                SocialLink deletedSocialLink = await _socialLinkRepository.DeleteAsync(socialLink);
                DeletedSocialLinkDto deletedSocialLinkDto=_mapper.Map<DeletedSocialLinkDto>(deletedSocialLink);
                return deletedSocialLinkDto;
            }
        }
    }
}
