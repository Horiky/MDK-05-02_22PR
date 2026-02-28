namespace WebApplication1.Data.Models
{
    public class ItemBasket:Items
    {
        public int Count { get; set; }
        public ItemBasket(int Count, Items item) : base(item)
        {
            this.Count = Count;
        }
    }
}
