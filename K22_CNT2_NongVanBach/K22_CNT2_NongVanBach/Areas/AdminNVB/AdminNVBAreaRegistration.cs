using System.Web.Mvc;

namespace K22_CNT2_NongVanBach.Areas.AdminNVB
{
    public class AdminNVBAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminNVB";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminNVB_default",
                "AdminNVB/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}