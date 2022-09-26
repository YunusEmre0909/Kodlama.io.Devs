using Application.Features.SocialLinks.Commands.CreateSocialLink;
using Application.Features.SocialLinks.Commands.DeleteSocialLink;
using Application.Features.SocialLinks.Commands.UpdateSocialLink;
using Application.Features.SocialLinks.Dtos;
using Application.Features.SocialLinks.Models;
using Application.Features.SocialLinks.Queries.GetByIdSocialLink;
using Application.Features.SocialLinks.Queries.GetListSocialLink;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialLinksController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSocialLinkQuery getListSocialLinkQuery=new GetListSocialLinkQuery { PageRequest = pageRequest };
            SocialLinkListModel result = await Mediator.Send(getListSocialLinkQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSocialLinkQuery getByIdSocialLinkQuery)
        {
            GetByIdSocialLinkDto getSocialLinkDto =await  Mediator.Send(getByIdSocialLinkQuery);
            return Ok(getSocialLinkDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialLinkCommand createSocialLinkCommand)
        {
            CreatedSocialLinkDto result = await Mediator.Send(createSocialLinkCommand);
            return Created("",result);
        }
        [HttpPost("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSocialLinkCommand deleteSocialLinkCommand)
        {
            DeletedSocialLinkDto result = await Mediator.Send(deleteSocialLinkCommand);
            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateSocialLinkCommand updateSocialLinkCommand)
        {
            UpdatedSocialLinkDto result = await Mediator.Send(updateSocialLinkCommand);
            return Ok(result);
        }

    }
}
