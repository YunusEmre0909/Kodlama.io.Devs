using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Dtos
{
    public class GetByIdSocialLinkDto
    {
        public int Id  { get; set; }
        public string GithubLink { get; set; }
    }
}
