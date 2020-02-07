using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllNotes.Domain.Dtos;
using AllNotes.Domain.Models.Sport;
using AllNotes.Services.IServices;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<ObjectResult> GetAllCategoriesAsync()
        {
            IList<CategoryDto> result = await _categoryServices.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("GetCategories/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetCategoryAsync([FromRoute] int id)
        {
            CategoryDto result = await _categoryServices.GetByIdAsync(id);

            return Ok(result);
        }

        //[HttpPost("AddCategory")]
        //[AllowAnonymous]
        //public async Task<ObjectResult> AddCategoryAsync([FromBody] string name)
        //{

        //    Category result = await _categoryServices.CreateAsync(name);

        //    return Ok(result);
        //}

        [HttpPut("UpdateCategory/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> UpdateCategoryAsync([FromRoute] int id, [FromBody] CategoryDto dto)
        {
            CategoryDto result = await _categoryServices.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest(new { message = "Categry not available" });
            }

            //var category = new Category { Id = result.Id, Name = name};
            var res = await _categoryServices.UpdateAsync(dto);

            return Ok(res);
        }

        [HttpDelete("DeleteCategory/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> DeleteCategory([FromRoute] int id)
        {
            Category result = await _categoryServices.GetByIdAsync(id);
            await _categoryServices.DeleteAsync(result);

            return Ok(result);
        }
        #endregion


        #region Exercise
        [HttpGet("GetExercises")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetAllExercisesAsync()
        {
            IList<ExerciseDto> result = await _exerciseServices.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetExercises/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetExercisesAsync([FromRoute] int id)
        {
            ExerciseDto result = await _exerciseServices.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("AddExercise")]
        [AllowAnonymous]
        public async Task<ObjectResult> AddExercisesAsync([FromBody] ExercisesDto dto)
        {
            ExerciseDto result = await _exerciseServices.CreateAsync( dto );
            return Ok(result);
        }

        [HttpPut("UpdateExercise/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> UpdateExercisesAsync([FromRoute] int id, [FromBody] ExercisesDto dto)
        {
            ExerciseDto result = await _exerciseServices.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest(new { message = "Exercise not available" });
            }

            //var exercise = new Exercise { Id = result.Id, Name = name, Description = description, CategoryId = categoryId };
            var res = await _exerciseServices.UpdateAsync(dto);

            return Ok(res);
        }

        [HttpDelete("DeleteExercise/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> DeleteExercises([FromRoute] int id)
        {
            ExerciseDto result = await _exerciseServices.GetByIdAsync(id);
            await _exerciseServices.DeleteAsync(result);

            return Ok(result);
        }
        #endregion


        #region Series
        [HttpGet("GetSeries")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetAllSeriesAsync()
        {
            IList<SeriesDto> result = await _seriesServices.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetSeries/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetSeriesAsync([FromRoute] int id)
        {
            SeriesDto result = await _seriesServices.GetByIdAsync(id);
            return Ok(result);
        }

        //[HttpPost("AddSeries")]
        //[AllowAnonymous]
        //public async Task<ObjectResult> AddSeriesAsync([FromBody] int repeats, float weights, int exerciseId)
        //{
        //    Series result = await _seriesServices.CreateAsync(repeats, weights, exerciseId);
        //    return Ok(result);
        //}

        [HttpPut("UpdateSeries/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> UpdateSeriesAsync([FromRoute] int id, [FromBody] SeriesDto dto)
        {
            SeriesDto result = await _seriesServices.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest(new { message = "Series not available" });
            }

            //var series = new Series { Id = result.Id, Repeats = repeats, Weights = weights, ExerciseId = exerciseId };
            var res = await _seriesServices.UpdateAsync(dto);

            return Ok(res);
        }

        [HttpDelete("DeleteSeries/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> DeleteSeries([FromRoute] int id)
        {
            SeriesDto result = await _seriesServices.GetByIdAsync(id);
            await _seriesServices.DeleteAsync(result);

            return Ok(result);
        }
        #endregion


    }
}