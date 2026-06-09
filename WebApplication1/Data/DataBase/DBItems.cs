using MySql.Data.MySqlClient;
using WebApplication1.Data.Common;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.DataBase
{
    public class DBItems : IItems
    {
        public IEnumerable<Categorys> Categorys = new DBCategory().AllCategorys;

        public IEnumerable<Items> AllItems
        {
            get
            {
                List<Items> items = new List<Items>();
                MySqlConnection MySqlConnection = Conection.MySqlOpen();
                // ИСПРАВЛЕНО: убрал 23pr.
                MySqlDataReader ItemsData = Conection.MySqlQuery("SELECT * FROM Items ORDER BY `Name`;", MySqlConnection);

                while (ItemsData.Read())
                {
                    items.Add(new Items()
                    {
                        Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                        Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                        Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                        img = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                        Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                        category = ItemsData.IsDBNull(5) ? null : Categorys.Where(x => x.Id == ItemsData.GetInt32(5)).FirstOrDefault()
                    });
                }
                MySqlConnection.Close();
                return items;
            }
        }

        public int Add(Items Item)
        {
            MySqlConnection MySqlConnection = Conection.MySqlOpen();
            // ИСПРАВЛЕНО: Items вместо items, IdCategory вместо IdCategory (оставил как есть, но таблица Items)
            Conection.MySqlQuery(
                $"INSERT INTO `Items` (`Name`, `Description`, `Img`, `Price`, `IdCategory`) VALUES ('{Item.Name}', '{Item.Description}', '{Item.img}', '{Item.Price}', {Item.category.Id});",
                MySqlConnection);
            MySqlConnection.Close();

            int IdItem = -1;
            MySqlConnection = Conection.MySqlOpen();
            MySqlDataReader MySqlDataReaderItem = Conection.MySqlQuery(
                $"SELECT `Id` FROM `Items` WHERE `Name` = '{Item.Name}' AND `Description` = '{Item.Description}' AND `Price` = '{Item.Price}' AND `IdCategory` = '{Item.category.Id}';",
                MySqlConnection);

            if (MySqlDataReaderItem.HasRows)
            {
                MySqlDataReaderItem.Read();
                IdItem = MySqlDataReaderItem.GetInt32(0);
            }
            MySqlConnection.Close();
            return IdItem;
        }
    }
}