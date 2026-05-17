using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;
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


            var allItems = IAllItems.AllItems;
 
            if (id != 0)
            {
                VMItems.Items = allItems.Where(x => x.category.Id == id);
            }
            else
            {
                VMItems.Items = allItems;
            }

            VMItems.Categorys = IAllCategores.AllCategorys;
            VMItems.SelectCategory = id;

            return View(VMItems);
        }
        public ActionResult Basket(int idItem = -1)
        {
            if (idItem != -1)
            {
                if(count == 0)
                {
                    Startup.BasketItem.Remove(Startup.BasketItem.Find(x => x.Id == idItem));
                }
                else 
                    Startup.BasketItem.Find(x => x.Id == idItem).Count = count;
               
            }
            return Json(Startup.BasketItem);
        }
        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Categorys> Categories = AllCategorys.AllCategories;

            return View(Categories);
        }
    }
}
