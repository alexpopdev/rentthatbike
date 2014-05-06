using System;
using System.Linq;
using System.Web.Mvc;
using RentThatBike.Web.Models;
using RentThatBike.Web.ServiceModel.Types;
using ServiceStack;
using ServiceStack.CacheAccess;
using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.Mvc;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;

namespace RentThatBike.Web.Controllers
{
    public class LoginController : ServiceStackController<AuthUserSession>
    {
        public AuthService AuthService { get; set; }
        //
        // GET: /login/
        public ActionResult Index(string redirect)
        {
            return View(new LoginData{Redirect = redirect});
        }

        [HttpPost]
        public ActionResult LogIn(LoginData loginData)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", loginData);
            }

            AuthService.RequestContext = System.Web.HttpContext.Current.ToRequestContext();
            try
            {
                AuthResponse authResponse = AuthService.Authenticate(new Auth
                {
                    UserName = loginData.EmailAddress,
                    Password = loginData.Password,
                    RememberMe = loginData.RememberMe,
                    Continue = loginData.Redirect
                });

                return Redirect(loginData.Redirect);
            }
            catch (HttpError ex)
            {
                if (ex.Status == 401)
                {
                    ModelState.AddModelError("", ex.ErrorCode);
                    return View("Index", loginData);
                }
                throw;
            }
        }
    }
}