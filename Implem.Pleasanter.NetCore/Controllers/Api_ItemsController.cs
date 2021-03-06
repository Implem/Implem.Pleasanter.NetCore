﻿using Implem.Pleasanter.NetCore.Libraries.Requests;
using Implem.Pleasanter.NetCore.Libraries.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Implem.Pleasanter.NetCore.Controllers
{
    [AllowAnonymous]
    public class Api_ItemsController : Controller
    {
        [HttpPost]
        public ContentResult Get(long id)
        {
            var context = new ContextImplement();
            var controller = new Pleasanter.Controllers.Api_ItemsController();
            var result = controller.Get(context: context, id: id);
            return result.ToHttpResponse(request: Request);
        }

        [HttpPost]
        public ContentResult Create(long id)
        {
            var context = new ContextImplement();
            var controller = new Pleasanter.Controllers.Api_ItemsController();
            var result = controller.Create(context: context, id: id);
            return result.ToHttpResponse(request: Request);
        }

        [HttpPost]
        public ContentResult Update(long id)
        {
            var context = new ContextImplement();
            var controller = new Pleasanter.Controllers.Api_ItemsController();
            var result = controller.Update(context: context, id: id);
            return result.ToHttpResponse(request: Request);
        }

        [HttpPost]
        public ContentResult Delete(long id)
        {
            var context = new ContextImplement();
            var controller = new Pleasanter.Controllers.Api_ItemsController();
            var result = controller.Delete(context: context, id: id);
            return result.ToHttpResponse(request: Request);
        }
    }
}