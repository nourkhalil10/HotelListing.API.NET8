using WebApplication1.Models.Domain;

namespace WebApplication1.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Category?> GetById(Guid id);
        Task<Category?> UpdateAsync(Category category);
    }
}
