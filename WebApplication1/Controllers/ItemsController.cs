using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
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
        /// <summary>
        /// Метод добавления предмета
        /// </summary>
        /// <param name="name">Наименование предмета</param>
        /// <param name="description">Описание предмета</param>
        /// <param name="files">Изображение</param>
        /// <param name="price">Цена</param>
        /// <param name="idCategory">Код категории</param>
        /// <returns></returns>
        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory)
        {
            // если присутствует файл
            if (files != null)
            {
                // получаем путь к папке
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                // получаем путь к файлу
                var filePath = Path.Combine(uploads, files.FileName);
                // Копируем файл
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            // Создаём новый предмет, заполняем данные
            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = files.FileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Categorys = new Categorys() { Id = idCategory };
            // Вызываем метод добавления
            int id = IAllItems.Add(newItems);
            // Перенаправляем пользователя на страницу изменения
            return Redirect("/Items/Update?id=" + id);
        }
        // <summary> Предоставляет сведения о среде размещения веб-сайтов, в которой вы ...
        private readonly IHostingEnvironment hostingEnvironment;

        // <summary> Интерфейс объектов
        private Items IAllItems;
        // <summary> Интерфейс категорий
        private ICategorys IAllCategories;
        // <summary> Создаём модель, хранящую в себе данные
        VMItems VMItems = new VMItems();

        // <summary> Конструктор принимающий параметры
        public ItemsController(IItems IAllItems, ICategorys IAllCategories, IHostingEnvironment environment)
        {
            this.IAllItems = IAllItems;
            this.IAllCategories = IAllCategories;
            // запоминаем сведения
            this.hostingEnvironment = environment;
        }
    }
}
