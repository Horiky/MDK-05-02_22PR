using MySql.Data.MySqlClient;
using System.Xml.Linq;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;
using WebApplication1.Data.Common;
namespace WebApplication1.Data.DataBase
{
    public class DBCategory : ICategores
    {
        public IEnumerable<Categorys> AllCategorys {
            get {

                List<Categorys> categorys = new List<Categorys>();

                MySqlConnection MySq1Connection = Conection.MySqlOpen();

                MySqlDataReader CategorysData = Conection.MySqlQuery("SELECT * FROM 23pr.Categorys ORDER BY `name` ; ", MySq1Connection);

                while (CategorysData.Read())
                {

                    categorys.Add(new Categorys()
                    {

                        Id = CategorysData.IsDBNull(0) ? -1 : CategorysData.GetInt32(0),
                        Name = CategorysData.IsDBNull(1) ? null : CategorysData.GetString(1),
                        Description = CategorysData.IsDBNull(2) ? null : CategorysData.GetString(2)

                    });
                }
                return categorys;
            }
        }
    }
}
