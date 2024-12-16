using ExBudget.Models;
using ExBudget.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExBudget.Services
{
    public class CategoryService
    {

        private static readonly CategoryRepository categoryRepo = new CategoryRepository();

        public static string SaveCategory(Category category)
        {

            if (category.Id == 0)
            {
                Category tempCategory = categoryRepo.FindByNameAndType(category.Name, category.TransactionType);
                if (tempCategory != null) {
                    return "Category already exists!";
                }
                if (!categoryRepo.Create(category))
                {
                    return "[Internal error]: could not save the category";
                }
                return string.Empty;
            }
            else
            {
                Category tempCategory = categoryRepo.FindById(category.Id);
                if (tempCategory != null)
                {
                    if (category.Equals(tempCategory))
                    {
                        return "Trying to save the same category";
                    }
                    tempCategory = categoryRepo.FindByNameAndType(category.Name, category.TransactionType);
                    if (tempCategory != null)
                    {
                        return "Category already exists!";
                    }
                    if (categoryRepo.Update(category)) {
                        return string.Empty;
                    }
                    else
                    {
                        return "[Internal error]: could not save the category";
                    }
                }
                else {
                    return "Category does not exists!";
                }
            }
        }

        internal static string Delete(int categoryId)
        {
            Category category = categoryRepo.FindById(categoryId);
            if (category == null) return $"Category with id {categoryId} does not exist";

            if (!categoryRepo.DeleteById(categoryId)) return "[Internal error]: could not delete the category";

            return string.Empty;
        }

        internal static List<Category> GetAllCategories()
        {
            return categoryRepo.GetAll();
        }

        internal static Category GetCategoryById(int selectedCategoryId)
        {
            return categoryRepo.FindById(selectedCategoryId);
        }
    }
}
