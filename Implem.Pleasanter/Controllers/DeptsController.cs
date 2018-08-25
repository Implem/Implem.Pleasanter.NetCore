﻿using Implem.Pleasanter.Filters;
using Implem.Pleasanter.Libraries.Responses;
using Implem.Pleasanter.Libraries.Security;
using Implem.Pleasanter.Libraries.Server;
using Implem.Pleasanter.Libraries.Settings;
using Implem.Pleasanter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Implem.Pleasanter.Controllers
{
    [Authorize]
    [CheckContract]
    [RefleshSiteInfo]
    public class DeptsController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get, HttpVerbs.Post)]
        public ActionResult Index()
        {
            if (!Libraries.Requests.Request.IsAjaxRequest(Request))
            {
                var log = new SysLogModel();
                var html = DeptUtilities.Index(
                    ss: SiteSettingsUtilities.DeptsSiteSettings());
                ViewBag.HtmlBody = html;
                log.Finish(html.Length);
                return View();
            }
            else
            {
                var log = new SysLogModel();
                var json = DeptUtilities.IndexJson(
                    ss: SiteSettingsUtilities.DeptsSiteSettings());
                log.Finish(json.Length);
                return Content(json);
            }
        }

        [HttpGet]
        public ActionResult New(long id = 0)
        {
            var log = new SysLogModel();
            var html = DeptUtilities.EditorNew(
                SiteSettingsUtilities.DeptsSiteSettings());
            ViewBag.HtmlBody = html;
            log.Finish(html.Length);
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get, HttpVerbs.Post)]
        public ActionResult Edit(int id)
        {
            if (!Libraries.Requests.Request.IsAjaxRequest(Request))
            {
                var log = new SysLogModel();
                var html = DeptUtilities.Editor(
                    SiteSettingsUtilities.DeptsSiteSettings(),
                    id,
                    clearSessions: true);
                ViewBag.HtmlBody = html;
                log.Finish(html.Length);
                return View();
            }
            else
            {
                var log = new SysLogModel();
                var json = DeptUtilities.EditorJson(
                    ss: SiteSettingsUtilities.DeptsSiteSettings(),
                    deptId: id);
                log.Finish(json.Length);
                return Content(json);
            }
        }

        [HttpGet]
        public ActionResult Export(long id)
        {
            var log = new SysLogModel();
            var responseFile = new ItemModel(id).Export();
            if (responseFile != null)
            {
                log.Finish(responseFile.Length);
                return responseFile.ToFile();
            }
            else
            {
                log.Finish(0);
                return null;
            }
        }

        [HttpPost]
        public string GridRows()
        {
            var log = new SysLogModel();
            var json = DeptUtilities.GridRows();
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string Create()
        {
            var log = new SysLogModel();
            var json = DeptUtilities.Create(
                ss: SiteSettingsUtilities.DeptsSiteSettings());
            log.Finish(json.Length);
            return json;
        }

        [HttpPut]
        public string Update(int id)
        {
            var log = new SysLogModel();
            var json = DeptUtilities.Update(
                ss: SiteSettingsUtilities.DeptsSiteSettings(),
                deptId: id);
            log.Finish(json.Length);
            return json;
        }

        [HttpDelete]
        public string Delete(int id)
        {
            var log = new SysLogModel();
            var json = DeptUtilities.Delete(
                ss: SiteSettingsUtilities.DeptsSiteSettings(),
                deptId: id);
            log.Finish(json.Length);
            return json;
        }

        [HttpDelete]
        public string DeleteComment(int id)
        {
            var log = new SysLogModel();
            var json = DeptUtilities.Update(
                ss: SiteSettingsUtilities.DeptsSiteSettings(),
                deptId: id);
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string Histories(int id)
        {
            var log = new SysLogModel();
            var json = DeptUtilities.Histories(
                ss: SiteSettingsUtilities.DeptsSiteSettings(),
                deptId: id);
            log.Finish(json.Length);
            return json;
        }

        [HttpPost]
        public string History(int id)
        {
            var log = new SysLogModel();
            var json = DeptUtilities.History(
                ss: SiteSettingsUtilities.DeptsSiteSettings(),
                deptId: id);
            log.Finish(json.Length);
            return json;
        }
    }
}
