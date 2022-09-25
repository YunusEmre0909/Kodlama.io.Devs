using Application.Features.SocialLinks.Commands.CreateSocialLink;
using Application.Features.SocialLinks.Dtos;
using AutoMapper;
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
        }
    }
}
