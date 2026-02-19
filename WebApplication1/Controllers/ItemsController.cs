using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.ViewModell;

namespace WebApplication1.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategores IAllCategores;
        VMItems VMItems = new VMItems();
        public ItemsController(IItems IAllItems, ICategores IAllCategores)
        {
            this.IAllItems = IAllItems;
            this.IAllCategores = IAllCategores;
        }
        public ViewResult List(int id = 0)
        {
            ViewBag.Title = "Страница с предметами";
            VMItems.Items = IAllItems.AllItems;
            VMItems.Categorys = IAllCategores.AllCategorys;
            VMItems.SelectCategory = id;
            

            return View(VMItems);
        }
    }
}
