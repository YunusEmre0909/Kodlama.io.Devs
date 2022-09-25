using Application.Features.SocialLinks.Commands.CreateSocialLink;
using Application.Features.SocialLinks.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialLinksController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialLinkCommand createSocialLinkCommand)
        {
            CreatedSocialLinkDto result = await Mediator.Send(createSocialLinkCommand);
            return Created("",result);
        }
    }
}
