using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models.Sport;
using AllNotes.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllNotes.Services.Services
{
    public class CategoryServices : BaseServices, ICategoryServices
    {
        public IWrapperRepository WrapperRepository { get; }

        public CategoryServices(AllNotesDbContext context, IWrapperRepository wrapperRepository) : base(context)
        {
            WrapperRepository = wrapperRepository;
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            var result = await WrapperRepository.Category.GetAllAsync();

            return result;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var result = await WrapperRepository.Category.GetByIdAsync(id);

            return result;
        }

        public async Task<Category> CreateAsync(string name)
        {
            Category category = new Category();
            category.Name = name;
            var result = await WrapperRepository.Category.CreateAsync(category);
            await base.CommitChanges();

            return result;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            var result = await WrapperRepository.Category.GetByIdAsync(category.Id);
            result.Name = category.Name;
            await base.CommitChanges();

            return result;
        }

        public async Task<Category> DeleteAsync(Category category)
        {
            var result = WrapperRepository.Category.Delete(category);
            await base.CommitChanges();

            return result;
        }
    }
}