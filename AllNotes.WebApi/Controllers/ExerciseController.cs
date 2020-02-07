using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllNotes.Domain.Dtos;
using AllNotes.Domain.Models;
using AllNotes.Domain.Models.Sport;
using AllNotes.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly IScheduleServices _scheduleServices;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;


        public ExerciseController(ICategoryServices categoryServices, 
                                  IExerciseServices exerciseServices,
                                  ISeriesServices seriesServices,
                                  IScheduleServices scheduleServices,
                                  UserManager<User> userManager,
                                  IMapper mapper)
        {
            _categoryServices = categoryServices;
            _exerciseServices = exerciseServices;
            _seriesServices = seriesServices;
            _scheduleServices = scheduleServices;
            _userManager = userManager;
            _mapper = mapper;
        }

        #region Exercise
        [HttpGet("GetExercises")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetAllExercisesAsync()
        {
            try
            {
                var result = await _exerciseServices.GetAllAsync();
                return Ok(_mapper.Map<IList<Exercise>, IList<ExerciseDto>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetExercises/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetExercisesAsync([FromRoute] int id)
        {
            Exercise result = await _exerciseServices.GetByIdAsync(id);
            return Ok(_mapper.Map<Exercise, ExerciseDto>(result));
        }

        [HttpPost("AddExercise")]
        [AllowAnonymous]
        public async Task<ObjectResult> AddExercisesAsync([FromBody] ExerciseDto dto)
        {
            //try
            //{
                Exercise exercise = _mapper.Map<ExerciseDto, Exercise>(dto);

                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                exercise.UserId = user.Id;

                if (exercise.Schedule != null)
                {
                    var schedule = _scheduleServices.GetByDate(exercise.Schedule.Date);
                    if (schedule != null)
                    {
                        exercise.ScheduleId = schedule.Id;
                    }
                    else
                    {
                        var resultS = await _scheduleServices.CreateAsync(exercise.Schedule.Date.ToString());
                        exercise.ScheduleId = resultS.Id;
                    }
                }
                else
                {
                    exercise.ScheduleId = null;
                }

                Exercise result = await _exerciseServices.CreateAsync(exercise);
                
                if (result.Series.Count > 0)
                {
                    foreach (SeriesDto i in dto.Series)
                    {
                        await _seriesServices.CreateAsync(i.Repeats, i.Weights, result.Id);
                    }
                }

                return Ok(_mapper.Map<Exercise, ExerciseDto>(result));
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new { message = ex.Message });
            //}
        }

        [HttpPut("UpdateExercise/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> UpdateExercisesAsync([FromRoute] int id, [FromBody] ExerciseDto dto)
        {
            //try
            //{
                Exercise exercise = _mapper.Map<ExerciseDto, Exercise>(dto);

                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                exercise.UserId = user.Id;

                if (exercise.Schedule != null)
                {
                    var schedule = _scheduleServices.GetByDate(exercise.Schedule.Date);
                    if (schedule != null)
                    {
                        exercise.ScheduleId = schedule.Id;
                    }
                    else
                    {
                        var resultS = await _scheduleServices.CreateAsync(exercise.Schedule.Date.ToString());
                        exercise.ScheduleId = resultS.Id;
                    }
                }
                else
                {
                    exercise.ScheduleId = null;
                }

                Exercise result = await _exerciseServices.UpdateAsync(exercise);

                IList<Series> series = await _seriesServices.GetAllAsync();
                foreach (Series i in series)
                {
                    if (i.ExerciseId == result.Id)
                    {
                        await _seriesServices.DeleteAsync(i);
                    }
                }

                if (result.Series.Count > 0)
                {
                    foreach (SeriesDto i in dto.Series)
                    {
                        await _seriesServices.CreateAsync(i.Repeats, i.Weights , result.Id);
                    }
                }

                return Ok(_mapper.Map<Exercise, ExerciseDto>(result));
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new { message = ex.Message });
            //}
        }

        [HttpDelete("DeleteExercise/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> DeleteExercises([FromRoute] int id)
        {
            Exercise result = await _exerciseServices.GetByIdAsync(id);
            await _exerciseServices.DeleteAsync(result);

            return Ok(result);
        }
        #endregion


        #region Categories
        //[HttpGet("GetCategories")]
        //[AllowAnonymous]
        //public async Task<ObjectResult> GetAllCategoriesAsync()
        //{
        //    IList<Category> result = await _categoryServices.GetAllAsync();

        //    return Ok(result);
        //}

        //[HttpGet("GetCategories/{id}")]
        //[AllowAnonymous]
        //public async Task<ObjectResult> GetCategoryAsync([FromRoute] int id)
        //{
        //    Category result = await _categoryServices.GetByIdAsync(id);

        //    return Ok(result);
        //}

        //[HttpPost("AddCategory")]
        //[AllowAnonymous]
        //public async Task<ObjectResult> AddCategoryAsync([FromBody] string name)
        //{

        //    Category result = await _categoryServices.CreateAsync(name);

        //    return Ok(result);
        //}

        //[HttpPut("UpdateCategory/{id}")]
        //public async Task<ObjectResult> UpdateCategoryAsync([FromRoute] int id, [FromBody] string name)
        //{
        //    Category result = await _categoryServices.GetByIdAsync(id);
        //    if (result == null)
        //    {
        //        return BadRequest(new { message = "Categry not available" });
        //    }

        //    var category = new Category { Id = result.Id, Name = name};
        //    await _categoryServices.UpdateAsync(category);

        //    return Ok(result);
        //}

        //[HttpDelete("DeleteCategory/{id}")]
        //public async Task<ObjectResult> DeleteCategory([FromRoute] int id)
        //{
        //    Category result = await _categoryServices.GetByIdAsync(id);
        //    await _categoryServices.DeleteAsync(result);

        //    return Ok(result);
        //}
        #endregion


        #region Series
        //[HttpGet("GetSeries")]
        //public async Task<ObjectResult> GetAllSeriesAsync()
        //{
        //    IList<Series> result = await _seriesServices.GetAllAsync();
        //    return Ok(result);
        //}

        //[HttpGet("GetSeries/{id}")]
        //public async Task<ObjectResult> GetSeriesAsync([FromRoute] int id)
        //{
        //    Series result = await _seriesServices.GetByIdAsync(id);
        //    return Ok(result);
        //}

        //[HttpPost("AddSeries")]
        //public async Task<ObjectResult> AddSeriesAsync([FromBody] int repeats, float weights, int exerciseId)
        //{
        //    Series result = await _seriesServices.CreateAsync(repeats, weights, exerciseId);
        //    return Ok(result);
        //}

        //[HttpPut("UpdateSeries/{id}")]
        //public async Task<ObjectResult> UpdateSeriesAsync([FromRoute] int id, [FromBody] int repeats, float weights, int exerciseId)
        //{
        //    Series result = await _seriesServices.GetByIdAsync(id);
        //    if (result == null)
        //    {
        //        return BadRequest(new { message = "Series not available" });
        //    }

        //    var series = new Series { Id = result.Id, Repeats = repeats, Weights = weights, ExerciseId = exerciseId };
        //    await _seriesServices.UpdateAsync(series);

        //    return Ok(result);
        //}

        //[HttpDelete("DeleteSeries/{id}")]
        //public async Task<ObjectResult> DeleteSeries([FromRoute] int id)
        //{
        //    Series result = await _seriesServices.GetByIdAsync(id);
        //    await _seriesServices.DeleteAsync(result);

        //    return Ok(result);
        //}
        #endregion


    }
}