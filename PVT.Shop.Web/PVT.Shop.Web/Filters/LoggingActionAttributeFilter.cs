namespace PVT.Shop.Web.Filters
{
    using System;
    using System.Diagnostics;
    using System.Web;
    using System.Web.Mvc;
    using Infrastructure.Logger;

    public class LoggingActionAttributeFilter : FilterAttribute, IActionFilter
    {
        private static string _partOfPath = DateTime.Now.ToShortDateString().Replace(".", "_") + "-log.txt";

        private readonly string _path = HttpContext.Current.Server.MapPath($"~/App_Data/{_partOfPath}");

        private Logger _logger = (Logger)DependencyResolver.Current.GetService(typeof(Logger));

        private Stopwatch _stopwatch;

        public LoggingActionAttributeFilter()
        {
            this._logger.IsEnabled = true;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this._stopwatch.Stop();

            this._logger.Save(
                this._path,
                new LogEvent()
                {
                    Id = 0,
                    EventDateTime = DateTime.Now,
                    LogLevel = LogLevel.Info,
                    Message = $"Controller: {filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}, " +
                                $"Action: {filterContext.ActionDescriptor.ActionName} " +
                                $"finished in {this._stopwatch.ElapsedMilliseconds}ms"
                });
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this._stopwatch = Stopwatch.StartNew();

            this._logger.Save(
                this._path,
                new LogEvent()
                {
                    Id = 0,
                    EventDateTime = DateTime.Now,
                    LogLevel = LogLevel.Info,
                    Message = $"Controller: {filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}, " +
                                  $"Action: {filterContext.ActionDescriptor.ActionName} " +
                                  $"starting..."
                });
        }
    }
}