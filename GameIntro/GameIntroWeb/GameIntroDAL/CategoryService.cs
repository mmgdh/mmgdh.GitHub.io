using GameIntroModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameIntroDAL
{
    public class CategoryService
    {
        public static IList<Category> GetAllCatgory()
        {
            string sql = "SELECT * FROM Categories";

            List<Category> list = new List<Category>();

            try
            {
                DataTable table = DBHelper.GetDataSet(sql);

                foreach (DataRow row in table.Rows)
                {
                    Category category = new Category();

                    category.Id = (int)row["Id"];
                    category.Type = (string)row["Type"];

                    list.Add(category);
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static Category GetCategoryById(int id)
        {
            string sql = "SELECT * FROM Categories WHERE Id = @Id";

            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    Category category = new Category();

                    category.Id = (int)reader["Id"];
                    category.Type = (string)reader["Type"];

                    reader.Close();

                    return category;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        public static Category GetCategoryByType(String Type)
        {
            string sql = "SELECT * FROM Categories WHERE Type = @Type";
            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Type", Type));
                if (reader.Read())
                {
                    Category category = new Category();

                    category.Id = (int)reader["Id"];
                    category.Type = (string)reader["Type"];

                    reader.Close();

                    return category;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
    }
}
