using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Repositories.Interface;

namespace WebApplication1.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await dbContext.Categories.ToListAsync();
                   
        }

        public async Task<Category?> GetById(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
           Category? exisitngCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if(exisitngCategory != null) 
            {
                dbContext.Entry(exisitngCategory).CurrentValues.SetValues(category);
                await dbContext.SaveChangesAsync();
                return category;
                
            }
            return null;
        }
    }
}
