using WebApplication1.Data.Models;

namespace WebApplication1.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Items> AllItems { get; }
    }
}
