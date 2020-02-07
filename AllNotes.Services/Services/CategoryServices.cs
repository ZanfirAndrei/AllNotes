using AllNotes.Domain.Dtos;
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

        public async Task<IList<CategoryDto>> GetAllAsync()
        {
            var result = await WrapperRepository.Category.GetAllAsync();

            List<CategoryDto> resultDto  = new List<CategoryDto>();

            CategoryDto category;

            if (result.Count > 0) { 
                foreach( Category i in result)
                {
                    category = new CategoryDto()
                    {
                        Id = i.Id,
                        Name = i.Name

                    };

                    resultDto.Add(category);
                }
                return resultDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var result = await WrapperRepository.Category.GetByIdAsync(id);

            CategoryDto categoryDto = new CategoryDto()
            {
                Id = result.Id,
                Name = result.Name

            };

            return categoryDto;
        }

        public async Task<CategoryDto> CreateAsync(CategoryDto dto)
        {
            Category category = new Category();
            category.Name = dto.Name;
            var result = await WrapperRepository.Category.CreateAsync(category);
            await base.CommitChanges();

            CategoryDto categoryDto = new CategoryDto()
            {
                Id = result.Id,
                Name = result.Name

            };

            return categoryDto;
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto dto)
        {
            var result = await WrapperRepository.Category.GetByIdAsync(category.Id);
            result.Name = dto.Name;
            await base.CommitChanges();

            CategoryDto categoryDto = new CategoryDto()
            {
                Id = result.Id,
                Name = result.Name

            };
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