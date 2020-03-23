
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sms.API.Handlers;
using Sms.API.Helpers;
using Sms.API.Models;
using Sms.Domain.Services;
using System;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Sms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IExceptionsService _exceptionsService;

        public VerificationController(IMediator mediator, IExceptionsService exceptionsService)
        {
            _mediator = mediator;
            _exceptionsService = exceptionsService;
        }

        public string _token => this.Request.Headers["token"];


        [HttpPost]
        public async Task<ActionResult<ResponseSMSModel>> PostAsync(RequestSMSModel newRequest)
        {
            try
            {
                var mapped = Mappers.MapRequest(_token, newRequest);
                var result = await _mediator.Send<ResponseSMSModel>(mapped);
                return Ok(result);
            }
            catch (Exception e)
            {
                await _exceptionsService.Publish(e, "VerificationController", "PostAsync");
                return new ResponseSMSModel { IdOperation = -1, StatusDescription = "Bad Request, check your 'RequestSMSModel'" };
            }
        }
    }
}
