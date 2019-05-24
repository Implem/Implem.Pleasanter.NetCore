﻿using Implem.Pleasanter.Libraries.Requests;
using Implem.Pleasanter.Libraries.Responses;
using Implem.Pleasanter.Models;
using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Implem.Pleasanter.Controllers.Api
{
    public class GroupsController
    {
        public ContentResult Get(Context context)
        {
            var log = new SysLogModel(context: context);
            var result = context.Authenticated
                ? new GroupModel().GetByApi(context: context)
                : ApiResults.Unauthorized(context: context);
            log.Finish(context: context, responseSize: result.Content.Length);
            return result;
        }
    }
}