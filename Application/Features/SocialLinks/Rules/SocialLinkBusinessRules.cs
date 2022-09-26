using Application.Services;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Rules
{
    public class SocialLinkBusinessRules
    {
        private readonly ISocialLinkRepository _socialLinkRepository;

        public SocialLinkBusinessRules(ISocialLinkRepository socialLinkRepository)
        {
            _socialLinkRepository = socialLinkRepository;
        }

        public async Task GithubLinkCanNotBeRepeated(string link)
        {
            IPaginate<SocialLink> result = await _socialLinkRepository.GetListAsync(x=>x.GithubLink==link);
            if (result.Items.Any()) throw new BusinessException("Github Link Already Exists.");
        }
        public async Task SocialLinkIdShouldBeExist(int id)
        {
            var result = await _socialLinkRepository.GetListAsync(x=>x.Id==id);
            if (!result.Items.Any()) throw new BusinessException("Social Link Not Found");
        }
        public void SocialLinkShouldExistWhenRequested(SocialLink socialLink)
        {
            if (socialLink == null) throw new BusinessException("Requested SocialLink Does Not Exist");
        }
    }
}
