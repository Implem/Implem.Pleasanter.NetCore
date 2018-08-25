﻿using Implem.DefinitionAccessor;
using Implem.Pleasanter.Filters;
using Implem.Pleasanter.Libraries.Requests;
using Implem.Pleasanter.Models;
using Implem.Pleasanter.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Implem.Pleasanter.Controllers
{
    [Authorize]
    [CheckContract]
    [RefleshSiteInfo]
    public class BackgroundTasksController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public string Do()
        {
            if (Parameters.BackgroundTask.Enabled)
            {
                if (QueryStrings.Bool("NoLog"))
                {
                    return BackgroundTasks.Do();
                }
                else
                {
                    var log = new SysLogModel();
                    var html = BackgroundTasks.Do();
                    log.Finish(html.Length);
                    return html;
                }
            }
            else
            {
                return null;
            }
        }
    }
}