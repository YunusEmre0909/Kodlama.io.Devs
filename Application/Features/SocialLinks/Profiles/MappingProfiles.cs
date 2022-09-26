using Application.Features.SocialLinks.Commands.CreateSocialLink;
using Application.Features.SocialLinks.Commands.DeleteSocialLink;
using Application.Features.SocialLinks.Commands.UpdateSocialLink;
using Application.Features.SocialLinks.Dtos;
using Application.Features.SocialLinks.Models;
using Application.Features.SocialLinks.Queries.GetByIdSocialLink;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialLink, CreateSocialLinkCommand>().ReverseMap();
            CreateMap<SocialLink, CreatedSocialLinkDto>().ReverseMap();

            CreateMap<SocialLink, DeleteSocialLinkCommand>().ReverseMap();
            CreateMap<SocialLink,DeletedSocialLinkDto>().ReverseMap();

            CreateMap<SocialLink, UpdateSocialLinkCommand>().ReverseMap(); 
            CreateMap<SocialLink,UpdatedSocialLinkDto>().ReverseMap();

            CreateMap<SocialLink, GetByIdSocialLinkDto>().ReverseMap();

            CreateMap<SocialLink, SocialLinkListDto>().ReverseMap();
            CreateMap<IPaginate<SocialLink>, SocialLinkListModel>().ReverseMap();
        }
    }
}
