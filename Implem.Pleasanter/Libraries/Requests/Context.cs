﻿using Implem.DefinitionAccessor;
using Implem.Libraries.Classes;
using Implem.Libraries.DataSources.SqlServer;
using Implem.Libraries.Utilities;
using Implem.Pleasanter.Libraries.DataSources;
using Implem.Pleasanter.Libraries.DataTypes;
using Implem.Pleasanter.Libraries.Responses;
using Implem.Pleasanter.Libraries.Security;
using Implem.Pleasanter.Libraries.Server;
using Implem.Pleasanter.Libraries.Settings;
using Implem.Pleasanter.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Implem.Pleasanter.Libraries.Requests
{
    public abstract class IContext
    {
        public abstract bool Authenticated { get; set; }
        public abstract bool SwitchUser { get; set; }
        public abstract string SessionGuid { get; set; }
        public abstract Dictionary<string, string> SessionData { get; set; }
        public abstract bool Publish { get; set; }
        public abstract QueryStrings QueryStrings { get; set; }
        public abstract Forms Forms { get; set; }
        public abstract string FormStringRaw { get; set; }
        public abstract string FormString { get; set; }
        public abstract List<PostedFile> PostedFiles { get; set; }
        public abstract bool HasRoute { get; set; }
        public abstract string HttpMethod { get; set; }
        public abstract bool Ajax { get; set; }
        public abstract bool Mobile { get; set; }
        public abstract Dictionary<string, string> RouteData { get; set; }
        public abstract string ApplicationPath { get; set; }
        public abstract string AbsoluteUri { get; set; }
        public abstract string AbsolutePath { get; set; }
        public abstract string Url { get; set; }
        public abstract string UrlReferrer { get; set; }
        public abstract string Query { get; set; }
        public abstract string Controller { get; set; }
        public abstract string Action { get; set; }
        public abstract string Page { get; set; }
        public abstract string Server { get; set; }
        public abstract int TenantId { get; set; }
        public abstract long SiteId { get; set; }
        public abstract long Id { get; set; }
        public abstract string Guid { get; set; }
        public abstract TenantModel.LogoTypes LogoType { get; set; }
        public abstract string TenantTitle { get; set; }
        public abstract string SiteTitle { get; set; }
        public abstract string RecordTitle { get; set; }
        public abstract string HtmlTitleTop { get; set; }
        public abstract string HtmlTitleSite { get; set; }
        public abstract string HtmlTitleRecord { get; set; }
        public abstract int DeptId { get; set; }
        public abstract int UserId { get; set; }
        public abstract string LoginId { get; set; }
        public abstract Dept Dept { get; set; }
        public abstract User User { get; set; }
        public abstract string UserHostName { get; set; }
        public abstract string UserHostAddress { get; set; }
        public abstract string UserAgent { get; set; }
        public abstract string Language { get; set; }
        public abstract bool Developer { get; set; }
        public abstract TimeZoneInfo TimeZoneInfo { get; set; }
        public abstract UserSettings UserSettings { get; set; }
        public abstract bool HasPrivilege { get; set; }
        public abstract ContractSettings ContractSettings { get; set; }
        public abstract string ApiRequestBody { get; set; }
        public abstract string RequestDataString { get; }

        public abstract string AuthenticationType { get; }
        public abstract bool? IsAuthenticated { get; }

        public abstract void Set(bool request = true, bool sessionStatus = true, bool setData = true, bool user = true, bool item = true, string apiRequestBody = null);

        public abstract RdsUser RdsUser();
        public abstract CultureInfo CultureInfo();
        public abstract Message Message();
        public abstract double SessionAge();
        public abstract double SessionRequestInterval();
        public abstract Dictionary<string, string> GetRouteData();

        public abstract void SetTenantCaches();

        static Func<bool, IContext> _factory;
        protected static void SetFactory(Func<bool, IContext> factory)
        {
            _factory = factory;
        }

        public static IContext CreateContext(bool item)
        {
            return _factory(item);
        }

        public abstract IContext CreateContext();
        public abstract IContext CreateContext(int tenantId);
        public abstract IContext CreateContext(int tenantId, int userId, int deptId);
        public abstract IContext CreateContext(int tenantId, string language);
        public abstract IContext CreateContext(int tenantId, int userId, string language);
        public abstract IContext CreateContext(bool request, bool sessionStatus, bool sessionData, bool user);

        public abstract string VirtualPathToAbsolute(string virtualPath);

        public abstract void FormsAuthenticationSignIn(string userName, bool createPersistentCookie);
        public abstract void FormsAuthenticationSignOut();

        public abstract void SessionAbandon();

        public abstract void FederatedAuthenticationSessionAuthenticationModuleDeleteSessionTokenCookie();

        public abstract bool AuthenticationsWindows();
    }
}