namespace WebApplication1.Data.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string img {  get; set; }
        public int Price { get; set; }
        public Categorys category {  get; set; } 
    }
}
