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
                        img = "https://www.dns-shop.ru/product/74815b45b14f1b29/elektrocajnik-dexp-dk-2200d-cernyj/",
                        Price = 6000,
                        category = _category.AllCategorys.Where(x => x.Id == 0).First()
                    },
                    new Items() {
                        Id = 0,
                        Name = "Крутой чайник",
                        Description = "Благодаря черному корпусу работает лучше",
                        img = "https://www.dns-shop.ru/product/74815b45b14f1b29/elektrocajnik-dexp-dk-2200d-cernyj/",
                        Price = 6000,
                        category = _category.AllCategorys.Where(x => x.Id == 0).First()
                    },
                    new Items() {
                        Id = 0,
                        Name = "Некрутой чайник",
                        Description = "Благодаря черному корпусу работает лучше",
                        img = "https://www.dns-shop.ru/product/74815b45b14f1b29/elektrocajnik-dexp-dk-2200d-cernyj/",
                        Price = 6000,
                        category = _category.AllCategorys.Where(x => x.Id == 0).First()
                    },
                    new Items() {
                        Id = 0,
                        Name = "Чайник",
                        Description = "Благодаря черному корпусу работает лучше",
                        img = "https://www.dns-shop.ru/product/74815b45b14f1b29/elektrocajnik-dexp-dk-2200d-cernyj/",
                        Price = 6000,
                        category = _category.AllCategorys.Where(x => x.Id == 0).First()
                    },
                    new Items() {
                        Id = 0,
                        Name = "Не чайник",
                        Description = "Благодаря черному корпусу работает лучше",
                        img = "https://www.dns-shop.ru/product/74815b45b14f1b29/elektrocajnik-dexp-dk-2200d-cernyj/",
                        Price = 6000,
                        category = _category.AllCategorys.Where(x => x.Id == 0).First()
                    },
            };
        }
        }
    } }
