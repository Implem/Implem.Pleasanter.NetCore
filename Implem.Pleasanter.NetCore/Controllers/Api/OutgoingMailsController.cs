﻿using Implem.Pleasanter.NetCore.Filters;
using Implem.Pleasanter.NetCore.Libraries.Requests;
using Implem.Pleasanter.NetCore.Libraries.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
namespace Implem.Pleasanter.NetCore.Controllers.Api
{
    [CheckApiContextAttributes]
    [AllowAnonymous]
    [ApiController]
    [Route("api")]
    public class OutgoingMailsController : ControllerBase
    {
        [HttpPost("{reference}/{id}/{controller}/Send")]
        public ContentResult Send(string reference, long id)
        {
            var body = default(string);
            using (var reader = new StreamReader(Request.Body)) body = reader.ReadToEnd();
            var context = new ContextImplement(
                sessionStatus: User?.Identity?.IsAuthenticated == true,
                sessionData: User?.Identity?.IsAuthenticated == true,
                apiRequestBody: body,
                contentType: Request.ContentType);
            var controller = new Pleasanter.Controllers.Api.OutgoingMailsController();
            var result = controller.Send(context: context, reference: reference, id: id);
            return result.ToHttpResponse(request: Request);
        }
    }
}