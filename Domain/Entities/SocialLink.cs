using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SocialLink : Entity
    {
        public string  GithubLink { get; set; }

        public SocialLink()
        {
        }

        public SocialLink(int id,string githubLink)
        {
            Id= id;
            GithubLink = githubLink;
        }
    }
}
