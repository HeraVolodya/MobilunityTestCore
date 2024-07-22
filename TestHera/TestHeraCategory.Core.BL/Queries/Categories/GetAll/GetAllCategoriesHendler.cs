using MediatR;
using TestHeraCategory.Core.BL.Queries.Categories.GetAll;
using TestHeraCategory.Core.BL.Responses.Category;
using TestHeraCategory.DataAccess;

public class GetAllCategoriesHendler : IRequestHandler<GetAllCategoriesQuery, List<CategoryResponse>>
{
    private readonly MockDbContext _context;

    public GetAllCategoriesHendler(MockDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryResponse>> Handle(
        GetAllCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(c => c.CategoryName.Contains(request.SearchTerm));
            }

            return query.Select(c => new CategoryResponse
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                ParentCategoryId = c.ParentCategoryId,
            }).ToList();
        }, cancellationToken);
    }
}