using MySql.Data.MySqlClient;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;
using WebApplication1.Data.Common;

namespace WebApplication1.Data.DataBase
{
    public class DBCategory : ICategores
    {
        public IEnumerable<Categorys> AllCategorys
        {
            get
            {
                List<Categorys> categorys = new List<Categorys>();

                MySqlConnection MySqlConnection = Conection.MySqlOpen();

                // ИСПРАВЛЕНО: Shop.Categories вместо 23pr.Categorys
                MySqlDataReader CategorysData = Conection.MySqlQuery("SELECT * FROM Categories ORDER BY `Name`;", MySqlConnection);

                while (CategorysData.Read())
                {
                    categorys.Add(new Categorys()
                    {
                        Id = CategorysData.IsDBNull(0) ? -1 : CategorysData.GetInt32(0),
                        Name = CategorysData.IsDBNull(1) ? null : CategorysData.GetString(1),
                        Description = CategorysData.IsDBNull(2) ? null : CategorysData.GetString(2)
                    });
                }
                MySqlConnection.Close();
                return categorys;
            }
        }
    }
}