using WebApplication1.Data.Models;

namespace WebApplication1.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Items> AllItems { get; }
        public int Add (Items item);
        public void Update(Items item);      
        public void Delete(int id);          
        public Items GetItem(int id);
    }
}
