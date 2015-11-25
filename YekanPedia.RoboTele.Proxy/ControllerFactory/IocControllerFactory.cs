
namespace YekanPedia.RoboTele.Proxy.ControllerFactory
{

    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using DependencyResolver;
    using Controllers;

    /// <summary>
    /// کنترلر فکتوری تولید شده برای انجام عملیات تزریق وابستگی
    /// </summary>
    public class IocControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// ایجاد کنترلر ارسالی و در یافت یک نمونه از آن با تزریق های انجام شده
        /// </summary>
        /// <param name="requestContext">درخواست کاربر</param>
        /// <param name="controllerType">نوع کنترلر که سیستم مسیریابی آن را پر خواهد کرد</param>
        /// <returns>IController اینترفیس </returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                var url = requestContext.HttpContext.Request.RawUrl;
                requestContext.RouteData.Values["controller"] = "api";
                requestContext.RouteData.Values["action"] = "home";
                return IocInitializer.GetInstance(typeof(ApiController)) as Controller;
            }
            return IocInitializer.GetInstance(controllerType) as Controller;
        }
    }
}