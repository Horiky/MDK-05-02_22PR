using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Interfaces;

namespace WebApplication1.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategores IAllCategores;
        public ItemsController(IItems IAllItems, ICategores IAllCategores)
        {
            this.IAllItems = IAllItems;
            this.IAllCategores = IAllCategores;
        }
        public ViewResult List()
        {
            ViewBag.Title = "Страница с предметами";
            var cars = IAllItems.AllItems;
            return View(cars);
        }
    }
}
