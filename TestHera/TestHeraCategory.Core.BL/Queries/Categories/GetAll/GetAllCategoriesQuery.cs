using MediatR;
using TestHeraCategory.Core.BL.Responses.Category;

namespace TestHeraCategory.Core.BL.Queries.Categories.GetAll;

public class  GetAllCategoriesQuery : IRequest<List<CategoryResponse>>
{
    public string? SearchTerm { get; init; }
}