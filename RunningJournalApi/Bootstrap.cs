using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace Ploeh.Samples.RunningJournalApi
{
    public class Bootstrap
    {
        public void Configure(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "{controller}/{id}",
                defaults: new
                {
                    controller = "Journal",
                    id = RouteParameter.Optional
                });

            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
        }
    }
}
