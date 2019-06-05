﻿using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
      protected override void OnActionExecuting(ActionExecutingContext filterContex)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if(session==null)
            {
                filterContex.Result = new RedirectToRouteResult(new 
                    RouteValueDictionary(new { controller="Login",action="Index",Area="Admin"}));
            }
            base.OnActionExecuting(filterContex);
          
        }
        protected void SetAlert(string message,string type)
        {
            TempData["AlertMessage"] = message;
            if(type== "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "aleart-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}