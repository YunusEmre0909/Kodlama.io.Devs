
using Application.Features.SocialLinks.Dtos;
using Application.Features.SocialLinks.Models;
using Application.Services;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Queries.GetListSocialLink
{
    public class GetListSocialLinkQuery : IRequest<SocialLinkListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListSocialLinkQueryHandler : IRequestHandler<GetListSocialLinkQuery, SocialLinkListModel>
        {

            private readonly ISocialLinkRepository _socialLinkRepository;
            private readonly IMapper _mapper;

            public GetListSocialLinkQueryHandler(ISocialLinkRepository socialLinkRepository, IMapper mapper)
            {
                _socialLinkRepository = socialLinkRepository;
                _mapper = mapper;
            }

            public async Task<SocialLinkListModel> Handle(GetListSocialLinkQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialLink> socialLinks = await _socialLinkRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
                SocialLinkListModel mappedSocialLinkListModel = _mapper.Map<SocialLinkListModel>(socialLinks);
                return mappedSocialLinkListModel;
            }
        }
    }
}
