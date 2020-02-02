using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllNotes.Domain.Models.Sport;
using AllNotes.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllNotes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IExerciseServices _exerciseServices;
        private readonly ISeriesServices _seriesServices;


        public ExerciseController(ICategoryServices categoryServices, 
                                  IExerciseServices exerciseServices,
                                  ISeriesServices seriesServices)
        {
            _categoryServices = categoryServices;
            _exerciseServices = exerciseServices;
            _seriesServices = seriesServices;
        }


        #region Categories
        [HttpGet("GetAllCategories")]
        public async Task<ObjectResult> GetAllCategoriesAsync()
        {
            IList<Category> result = await _categoryServices.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("GetCategory/{id}")]
        public async Task<ObjectResult> GetCategoryAsync([FromRoute] int id)
        {
            Category result = await _categoryServices.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost("AddCategory")]
        public async Task<ObjectResult> AddCategoryAsync([FromBody] string name)
        {

            Category result = await _categoryServices.CreateAsync(name);

            return Ok(result);
        }

        [HttpPut("UpdateCategory/{id}")]
        public async Task<ObjectResult> UpdateCategoryAsync([FromRoute] int id, [FromBody] string name)
        {
            Category result = await _categoryServices.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest(new { message = "Categry not available" });
            }

            var category = new Category { Id = result.Id, Name = name};
            await _categoryServices.UpdateAsync(category);

            return Ok(result);
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<ObjectResult> DeleteCategory([FromRoute] int id)
        {
            Category result = await _categoryServices.GetByIdAsync(id);
            await _categoryServices.DeleteAsync(result);

            return Ok(result);
        }
        #endregion


        #region Exercise
        
        #endregion


        #region Series
        
        #endregion


    }
}