using GameIntroDAL;
using GameIntroModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameIntroBLL
{
    public static class CategoryManager
    {
        public static IList<Category> GetAllCategory()
        {
            return CategoryService.GetAllCatgory();
        }
        public static Category GetCategoryById(int id)
        {
           return  CategoryService.GetCategoryById(id);
        }
    }
}
