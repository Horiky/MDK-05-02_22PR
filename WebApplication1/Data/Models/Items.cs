namespace WebApplication1.Data.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string img { get; set; }
        public int Price { get; set; }
        public Categorys category { get; set; }
        public Items(Items item = null)
        {
            this.Id = item.Id;
            this.Name = item.Name;
            this.Description = item.Description;
            this.img = item.img;
            this.category = item.category;
            this.Price = item.Price;
        }
    }
}
   

