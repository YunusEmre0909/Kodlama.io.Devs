using Application.Features.SocialLinks.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Models
{
    public class SocialLinkListModel
    {
        public IList<SocialLinkListDto> Items { get; set; }
    }
}
