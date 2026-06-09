using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Data.Mocks
{
    public class MockItems : IItems
    {
        public ICategores _category = new MockCategorys();

        public IEnumerable<Items> AllItems
        {
            get
            {
                return new List<Items>()
                {
                    new Items() {
                        Id = 0,
                        Name = "DEXP DK-2200D",
                        Description = "Благодаря черному корпусу работает лучше",
                        img = "https://c.dns-shop.ru/thumb/st1/fit/320/250/0a2aa88619a86c403eb236779d398bd5/13af31a9ab99756ef17f59d69553592c3c0f584df4e9377627901d871a9b720a.jpg",
                        Price = 6000,
                        category = _category.AllCategorys.Where(x => x.Id == 1).First()
                    },
                    new Items() {
                        Id = 1,
                        Name = "Крутой чайник",
                        Description = "Благодаря черному корпусу работает лучше",
                        img = "https://c.dns-shop.ru/thumb/st1/fit/320/250/0a2aa88619a86c403eb236779d398bd5/13af31a9ab99756ef17f59d69553592c3c0f584df4e9377627901d871a9b720a.jpg",
                        Price = 6000,
                        category = _category.AllCategorys.Where(x => x.Id == 1).First()
                    },
                    new Items() {
                        Id = 2,
                        Name = "Некрутой чайник",
                        Description = "Благодаря черному корпусу работает лучше",
                        img = "https://c.dns-shop.ru/thumb/st1/fit/320/250/0a2aa88619a86c403eb236779d398bd5/13af31a9ab99756ef17f59d69553592c3c0f584df4e9377627901d871a9b720a.jpg",
                        Price = 6000,
                        category = _category.AllCategorys.Where(x => x.Id == 1).First()
                    },
                    new Items() {
                        Id = 3,
                        Name = "Чайник",
                        Description = "Благодаря черному корпусу работает лучше",
                        img = "https://c.dns-shop.ru/thumb/st1/fit/320/250/0a2aa88619a86c403eb236779d398bd5/13af31a9ab99756ef17f59d69553592c3c0f584df4e9377627901d871a9b720a.jpg",
                        Price = 6000,
                        category = _category.AllCategorys.Where(x => x.Id == 1).First()
                    },
                    new Items() {
                        Id = 4,
                        Name = "Не чайник",
                        Description = "Благодаря черному корпусу работает лучше",
                        img = "https://c.dns-shop.ru/thumb/st4/fit/320/250/719c3a1544acc574f4f03ca2bf1f2d6a/41c5b8c3c552a0e4a0af35916ceb8d43bc2ec6e982b3212eeefad4d099314bef.jpg",
                        Price = 6000,
                        category = _category.AllCategorys.Where(x => x.Id == 2).First()
                    },
                };
            }
        }

        // Добавленный метод Add
        public int Add(Items item)
        {
            // Для мок-объекта просто возвращаем новый ID (максимальный + 1)
            int newId = AllItems.Max(x => x.Id) + 1;
            item.Id = newId;

            // В мок-реализации ничего не сохраняем, просто возвращаем ID
            // При желании можно добавить в список, но список только для чтения
            return newId;
        }
    }
}