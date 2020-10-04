using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryBusiness
    {
        private CategoryRepository categoryRepository;

        public CategoryBusiness()
        {
            categoryRepository = new CategoryRepository();
        }

        public List<Category> GetCategories()
        {
            return categoryRepository.GetCategories();
        }

        public bool InsertCategory(Category category)
        {
            int result = 0;
            if (category != null)
            {
                result = categoryRepository.InsertCategory(category);
            }
            return result > 0 ? true : false;
        }
        public bool UpdateCategory(Category category)
        {
            int result = 0;
            if (category != null)
            {
                result = categoryRepository.UpdateCategory(category);
            }
            return result > 0 ? true : false;
        }
    }
}