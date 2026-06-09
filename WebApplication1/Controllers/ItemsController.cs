using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;
using WebApplication1.Data.ViewModell;

namespace WebApplication1.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItems IAllItems;
        private readonly ICategores IAllCategores;
        private readonly IWebHostEnvironment hostingEnvironment;
        private VMItems VMItems = new VMItems();

        // Единый конструктор
        public ItemsController(IItems IAllItems, ICategores IAllCategores, IWebHostEnvironment environment)
        {
            this.IAllItems = IAllItems;
            this.IAllCategores = IAllCategores;
            this.hostingEnvironment = environment;
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

        public ActionResult Basket(int idItem = -1, int count = 1)
        {
            if (idItem != -1)
            {
                var existingItem = Startup.BasketItem.Find(x => x.Id == idItem);

                if (count == 0)
                {
                    if (existingItem != null)
                        Startup.BasketItem.Remove(existingItem);
                }
                else
                {
                    if (existingItem != null)
                        existingItem.Count = count;
                    else
                    {
                        var item = IAllItems.AllItems.FirstOrDefault(x => x.Id == idItem);
                        if (item != null)
                            Startup.BasketItem.Add(new ItemBasket(count, item));
                    }
                }
            }
            return Json(Startup.BasketItem);
        }

        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Categorys> Categories = IAllCategores.AllCategorys;
            return View(Categories);
        }

        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory)
        {
            if (files != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    files.CopyTo(stream);
                }
            }

            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.img = files != null ? files.FileName : "";
            newItems.Price = Convert.ToInt32(price);
            newItems.category = new Categorys() { Id = idCategory };

            int id = IAllItems.Add(newItems);
            return Redirect("/Items/Update?id=" + id);
        }
    }

    public class Startup
    {
        public static List<ItemBasket> BasketItem = new List<ItemBasket>();
    }
}