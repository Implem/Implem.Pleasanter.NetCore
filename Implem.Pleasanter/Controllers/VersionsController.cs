﻿using Implem.Pleasanter.Filters;
using Implem.Pleasanter.Libraries.Html;
using Implem.Pleasanter.Libraries.HtmlParts;
using Implem.Pleasanter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Implem.Pleasanter.Controllers
{
    [Authorize]
    [CheckContract]
    [RefleshSiteInfo]
    public class VersionsController : Controller
    {
        public ActionResult Index()
        {
            var log = new SysLogModel();
            var html = new HtmlBuilder().AssemblyVersions();
            ViewBag.HtmlBody = html;
            log.Finish(html.Length);
            return View();
        }
    }
}