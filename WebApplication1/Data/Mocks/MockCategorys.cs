using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Mocks
{
    public class MockCategorys : ICategores
    {
        public IEnumerable<Categorys> AllCategorys

        {
            get
            {
                return new List<Categorys>
                {
                    new Categorys
                    {
                        Id = 0,
                        Name = "печи",
                        Description = "Печь прибор для заморозки блюд",

                    },
                    new Categorys
                    {
                        Id = 1,
                        Name = "Чайники",
                        Description = "Чайники греют воду и душу",
                    }
                };
            }
        }
    }
}
