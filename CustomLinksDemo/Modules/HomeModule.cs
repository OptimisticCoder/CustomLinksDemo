namespace CustomLinksDemo.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Nancy;

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
            {
                var links = Models.Link.Load("~/App_Data/sample-data.xml");
                return View["home", links];
            };
        }
    }
}