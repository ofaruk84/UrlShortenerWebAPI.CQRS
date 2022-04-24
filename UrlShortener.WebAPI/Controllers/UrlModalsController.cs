using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UrlShortener.Application.Commands;
using UrlShortener.Application.Queries;
using UrlShortener.Domain.Dtos;

namespace UrlShortener.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlModalsController : ControllerBase
    {
        
        private readonly IMediator _mediator;

        public UrlModalsController( IMediator mediator)
        {
            
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(UrlRequestModal urlRequestModal)
        {
            var result = await _mediator.Send(new AddUrlModalCommand(urlRequestModal));


            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("addcustom")]
        public async Task<IActionResult> AddCustom(UrlRequestModal urlRequestModal)
        {
            var result = await _mediator.Send(new AddCustomUrlModalCommand(urlRequestModal));

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("redirect")]
        public async Task<IActionResult> RedirectToActualUrl(string shortUrl, [FromQuery] string redirect = "true")
        {
            var shortUrlResult = await _mediator.Send(new GetByShortUrlQuery(shortUrl));

            if (!shortUrlResult.Success) return BadRequest(shortUrlResult);

            if (redirect.Equals("true")) return Redirect(shortUrlResult.Data.UrlModal.LongUrl);

            return Ok(shortUrlResult);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllQuery());

            if (!result.Success) return BadRequest(result);

            return Ok(result);

        }




    }
}
