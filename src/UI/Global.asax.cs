using System.Web.Mvc;
using System.Web.Routing;
using KyivBeerNCode;
using KyivBeerNCode.Domain.Meetings;

namespace UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {       
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "MeetingActions",
                "Meetings/Actions/{id}/{action}",
                new { controller = "Meetings", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Meetings", action = "Index", id = UrlParameter.Optional } 
            );            

        }

        protected void Application_Start()
        {

            // Let's add bunch of meetings
            var env = ExecutionEnvironment.Default();
            var registrator = env.Resolve<MeetingRegistrator>();

            var dddQuest = registrator.Register("DDD Quest");
            dddQuest.RegisterAttendie("Ivan Korneliuk");
            dddQuest.RegisterAttendie("Serhiy Kalinets");
            registrator.Register("CQRS Quest");
            registrator.Register("New Year");


            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}