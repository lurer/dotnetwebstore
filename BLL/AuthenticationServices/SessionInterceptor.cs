using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace BLL.AuthenticationServices
{
    public class SessionInterceptor : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if(filterContext.HttpContext.Session["SessionID"] == null)
            {

                SessionIDManager mgr = new SessionIDManager();
                string sessionID = mgr.CreateSessionID(HttpContext.Current);
                filterContext.HttpContext.Session.Timeout = 30;
                filterContext.HttpContext.Session["SessionID"] = sessionID;
            }
        }


    }
}
