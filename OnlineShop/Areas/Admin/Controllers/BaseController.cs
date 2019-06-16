﻿using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Threading;
using System.Globalization;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        //initilizing culture on controller initialization
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session[CommonConstants.CurrentCulture] != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session[CommonConstants.CurrentCulture].ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session[CommonConstants.CurrentCulture].ToString());
            }
            else
            {
                Session[CommonConstants.CurrentCulture] = "vi";
                Thread.CurrentThread.CurrentCulture = new CultureInfo("vi");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi");
            }
        }

        // changing culture
        public ActionResult ChangeCulture(string ddlCulture, string returnUrl)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlCulture);

            Session[CommonConstants.CurrentCulture] = ddlCulture;
            return Redirect(returnUrl);
        }
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