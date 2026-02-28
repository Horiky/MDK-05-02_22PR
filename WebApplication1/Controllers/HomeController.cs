using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController:Controller
    {
        public RedirectResult Index()
        {
            return Redirect("/Items/List");
        }
    }
}
