namespace TestHeraCategory.Core.BL.Responses.Category;

public sealed record CategoryResponse
{
    public int CategoryId { get; init; } = default!;
    public string CategoryName { get; init; } = default!;
    public int?  ParentCategoryId { get; init; }
}