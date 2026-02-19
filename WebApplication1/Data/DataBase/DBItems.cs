using MySql.Data.MySqlClient;
using System.Xml.Linq;
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
                // создаём список предметов
                List<Items> items = new List<Items>();
                // открываем подключение к базе данных
                MySqlConnection MySqlConnection = Conection.MySqlOpen();
                // получаем данные из таблицы предметов
                MySqlDataReader ItemsData = Conection.MySqlQuery("SELECT * FROM 23pr.items ORDER BY `Name`;", MySqlConnection);
                // читаем данные
                while (ItemsData.Read())
                {
                    // заполняем список
                    items.Add(new Items()
                    {
                        Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                        Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                        Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                        img = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                        Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                        category = ItemsData.IsDBNull(5) ? null : Categorys.Where(x => x.Id == ItemsData.GetInt32(5)).First()
                    });
                    // закрываем соединение
                    MySqlConnection.Close();
                 

                }
                return items;
            }
        }
    }
}
