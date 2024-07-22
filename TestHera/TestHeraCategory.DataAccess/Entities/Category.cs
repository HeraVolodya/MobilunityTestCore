namespace TestHeraCategory.DataAccess.Entities;

public sealed class Category
{
    public int CategoryId { get; init; } = default!;
    public string CategoryName { get; init; } = default!;
    public int?  ParentCategoryId { get; init; }
    public Category ParentCategory { get; set; }
    public List<Category> SubCategories { get; set; } = new List<Category>();
}