﻿using Implem.Pleasanter.Libraries.Requests;
using Implem.Pleasanter.Models;
using System.Web.Mvc;
namespace Implem.Pleasanter.Controllers
{
    public class OutgoingMailsController
    {
        public string Edit(IContext context, string reference, long id)
        {
            var log = new SysLogModel(context: context);
            var json = OutgoingMailUtilities.Editor(
                context: context,
                reference: reference,
                id: id);
            log.Finish(context: context, responseSize: json.Length);
            return json;
        }

        public string Reply(IContext context, string reference, long id)
        {
            var log = new SysLogModel(context: context);
            var json = OutgoingMailUtilities.Editor(
                context: context,
                reference: reference,
                id: id);
            log.Finish(context: context, responseSize: json.Length);
            return json;
        }

        public string GetDestinations(IContext context, string reference, long id)
        {
            var log = new SysLogModel(context: context);
            var json = new OutgoingMailModel(
                context: context, 
                reference: reference,
                referenceId: id)
                    .GetDestinations(context: context);
            log.Finish(context: context, responseSize: json.Length);
            return json;
        }

        public string Send(IContext context, string reference, long id)
        {
            var log = new SysLogModel(context: context);
            var json = OutgoingMailUtilities.Send(
                context: context,
                reference: reference,
                id: id);
            log.Finish(context: context, responseSize: json.Length);
            return json;
        }
    }
}
