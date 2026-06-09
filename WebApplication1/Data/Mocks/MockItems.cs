using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Data.Mocks
{
    public class MockItems : IItems
    {
        public ICategores _category = new MockCategorys();
        private List<Items> _items;

        public MockItems()
        {
            _items = new List<Items>()
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

        public IEnumerable<Items> AllItems
        {
            get { return _items; }
        }

        public int Add(Items item)
        {
            int newId = _items.Max(x => x.Id) + 1;
            item.Id = newId;
            _items.Add(item);
            return newId;
        }

        public void Update(Items item)
        {
            var existing = _items.FirstOrDefault(x => x.Id == item.Id);
            if (existing != null)
            {
                existing.Name = item.Name;
                existing.Description = item.Description;
                existing.img = item.img;
                existing.Price = item.Price;
                existing.category = item.category;
            }
        }

        public void Delete(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public Items GetItem(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }
    }
}