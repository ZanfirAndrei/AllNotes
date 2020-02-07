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
        [HttpGet("GetCategories")]
        public async Task<ObjectResult> GetAllCategoriesAsync()
        {
            IList<Category> result = await _categoryServices.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("GetCategories/{id}")]
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
        [HttpGet("GetExercises")]
        public async Task<ObjectResult> GetAllExercisesAsync()
        {
            IList<Exercise> result = await _exerciseServices.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetExercises/{id}")]
        public async Task<ObjectResult> GetExercisesAsync([FromRoute] int id)
        {
            Exercise result = await _exerciseServices.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("AddExercise")]
        public async Task<ObjectResult> AddExercisesAsync([FromBody] string name, string desc, int categoryId)
        {
            Exercise result = await _exerciseServices.CreateAsync(name,desc,categoryId);
            return Ok(result);
        }

        [HttpPut("UpdateExercise/{id}")]
        public async Task<ObjectResult> UpdateExercisesAsync([FromRoute] int id, [FromBody] string name, string description, int categoryId)
        {
            Exercise result = await _exerciseServices.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest(new { message = "Exercise not available" });
            }

            var exercise = new Exercise { Id = result.Id, Name = name, Description = description, CategoryId = categoryId };
            await _exerciseServices.UpdateAsync(exercise);

            return Ok(result);
        }

        [HttpDelete("DeleteExercise/{id}")]
        public async Task<ObjectResult> DeleteExercises([FromRoute] int id)
        {
            Exercise result = await _exerciseServices.GetByIdAsync(id);
            await _exerciseServices.DeleteAsync(result);

            return Ok(result);
        }
        #endregion


        #region Series
        [HttpGet("GetSeries")]
        public async Task<ObjectResult> GetAllSeriesAsync()
        {
            IList<Series> result = await _seriesServices.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetSeries/{id}")]
        public async Task<ObjectResult> GetSeriesAsync([FromRoute] int id)
        {
            Series result = await _seriesServices.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("AddSeries")]
        public async Task<ObjectResult> AddSeriesAsync([FromBody] int repeats, float weights, int exerciseId)
        {
            Series result = await _seriesServices.CreateAsync(repeats, weights, exerciseId);
            return Ok(result);
        }

        [HttpPut("UpdateSeries/{id}")]
        public async Task<ObjectResult> UpdateSeriesAsync([FromRoute] int id, [FromBody] int repeats, float weights, int exerciseId)
        {
            Series result = await _seriesServices.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest(new { message = "Series not available" });
            }

            var series = new Series { Id = result.Id, Repeats = repeats, Weights = weights, ExerciseId = exerciseId };
            await _seriesServices.UpdateAsync(series);

            return Ok(result);
        }

        [HttpDelete("DeleteSeries/{id}")]
        public async Task<ObjectResult> DeleteSeries([FromRoute] int id)
        {
            Series result = await _seriesServices.GetByIdAsync(id);
            await _seriesServices.DeleteAsync(result);

            return Ok(result);
        }
        #endregion


    }
}