using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using RentThatBike.Web.Models;
using ServiceStack.Mvc;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.Text;
using WebGrease.Css.Extensions;

namespace RentThatBike.Web.Controllers
{
    [Authenticate]
    public class HomeController : ServiceStackController<AuthUserSession>
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var scriptsFolderPath = Server.MapPath("~/scripts/app/views");
            var scriptsDirectoryInfo = new DirectoryInfo(scriptsFolderPath);

            FileInfo[] scriptFileInfos = scriptsDirectoryInfo.GetFiles();
            var scriptsStringBuilder = new StringBuilder();
            scriptFileInfos.ForEach(scriptFileInfo =>
            {
                scriptsStringBuilder.AppendFormat(@"<script type=""text/ng-template"" id=""scripts/app/views/{0}"">",
                    scriptFileInfo.Name);
                scriptsStringBuilder.AppendLine();
                scriptsStringBuilder.Append(System.IO.File.ReadAllText(scriptFileInfo.FullName));
                scriptsStringBuilder.AppendLine();
                scriptsStringBuilder.Append("</script>");
                scriptsStringBuilder.AppendLine();
            });

            ViewBag.AppPartials = scriptsStringBuilder.ToString();

            ViewBag.AuthUserSession = UserSession;

            ViewBag.ServerSideDataAsJson = new ServerSideData
            {
                UserDisplayName = UserSession.DisplayName,
                UserEmail = UserSession.Email
            }.ToJson(); 

            return View();
        }
	}
}