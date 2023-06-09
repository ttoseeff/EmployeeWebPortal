using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeWebPortal.Controllers
{
    public class BaseController : Controller
    {
        private ILog _ILog;
        public BaseController() 
        {
            _ILog = Log.GetInstance;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            if (!string.IsNullOrEmpty(filterContext.Exception?.InnerException?.InnerException?.ToString()))
                _ILog.LogException(filterContext.Exception.InnerException.InnerException.ToString());
            else if (!string.IsNullOrEmpty(filterContext.Exception?.InnerException?.ToString()))
                _ILog.LogException(filterContext.Exception.InnerException.ToString());
            else
                _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
    }
}