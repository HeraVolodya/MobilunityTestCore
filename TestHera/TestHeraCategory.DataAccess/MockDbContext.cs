using TestHeraCategory.DataAccess.Entities;

namespace TestHeraCategory.DataAccess;

public class MockDbContext
{
    public List<Category> Categories { get; set; } = new List<Category>();

    public MockDbContext()
    {
        Categories.Add(new Category { CategoryId = 1, CategoryName = "Fruits", ParentCategoryId = null });
        Categories.Add(new Category { CategoryId = 2, CategoryName = "Apples", ParentCategoryId = 1 });

        // Setting up the relationships
        foreach (var category in Categories)
        {
            category.ParentCategory = Categories.FirstOrDefault(c => c.CategoryId == category.ParentCategoryId);
            if (category.ParentCategory != null)
            {
                category.ParentCategory.SubCategories.Add(category);
            }
        }
    }
}