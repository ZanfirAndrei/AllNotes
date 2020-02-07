using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllNotes.Domain.Dtos;
using AllNotes.Domain.Models.Memo;
using AllNotes.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllNotes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListController : ControllerBase
    {
        private readonly ICheckListServices _checkListServices;
        private readonly ICheckBoxServices _checkBoxServices;


        public CheckListController(ICheckListServices checkListServices,
                                  ICheckBoxServices checkBoxServices)
        {
            _checkListServices = checkListServices;
            _checkBoxServices = checkBoxServices;
        }


        #region CheckList
        [HttpGet("GetCheckLists")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetAllCheckListsAsync()
        {
            IList<CheckListDto> result = await _checkListServices.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("GetCheckLists/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> GetCheckListAsync([FromRoute] int id)
        {
            CheckListDto result = await _checkListServices.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost("AddCheckList")]
        [AllowAnonymous]
        public async Task<ObjectResult> AddCheckListAsync([FromBody] CheckListDto dto)
        {
            CheckListDto result = await _checkListServices.CreateAsync(dto);

            return Ok(result);
        }

        [HttpPut("UpdateCheckList/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> UpdateCheckListAsync([FromRoute] int id, [FromBody] CheckListDto dto)
        {
            CheckListDto result = await _checkListServices.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest(new { message = "CheckList not available" });
            }

            //var checkList = new CheckList { Id = result.Id, Name = name , IsComplete = isComplete};
            var res = await _checkListServices.UpdateAsync(dto);

            return Ok(res);
        }

        [HttpDelete("DeleteCheckList/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> DeleteCheckList([FromRoute] int id)
        {
            CheckListDto result = await _checkListServices.GetByIdAsync(id);
            await _checkListServices.DeleteAsync(result);

            return Ok(result);
        }
        #endregion


        #region CheckBox
        //[HttpGet("GetCheckBoxes")]
        //[AllowAnonymous]
        //public async Task<ObjectResult> GetAllCheckBoxesAsync()
        //{
        //    IList<CheckBoxDto> result = await _checkBoxServices.GetAllAsync();

        //    return Ok(result);
        //}

        //[HttpGet("GetCheckBoxes/{id}")]
        //[AllowAnonymous]
        //public async Task<ObjectResult> GetCheckBoxAsync([FromRoute] int id)
        //{
        //    CheckBoxDto result = await _checkBoxServices.GetByIdAsync(id);

        //    return Ok(result);
        //}

        //[HttpPost("AddCheckBox")]
        //[AllowAnonymous]
        //public async Task<ObjectResult> AddCheckBoxAsync([FromBody] string name, int checkListId)
        //{

        //    CheckBox result = await _checkBoxServices.CreateAsync(name,checkListId);

        //    return Ok(result);
        //}

        [HttpPut("UpdateCheckBox/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> UpdateCheckBoxAsync([FromRoute] int id, [FromBody] CheckBoxDto dto)
        {
            CheckBoxDto res = await _checkBoxServices.GetByIdAsync(id);
            if (res == null)
            {
                return BadRequest(new { message = "CheckBox not available" });
            }

            //var checkBox = new CheckBox { Id = result.Id, Name = dto.Name, IsChecked = dto.IsChecked};
            var result = await _checkBoxServices.UpdateAsync(dto);

            return Ok(result);
        }

        [HttpDelete("DeleteCheckBox/{id}")]
        [AllowAnonymous]
        public async Task<ObjectResult> DeleteCheckBox([FromRoute] int id)
        {
            CheckBoxDto result = await _checkBoxServices.GetByIdAsync(id);
            await _checkBoxServices.DeleteAsync(result);

            return Ok(result);
        }
        #endregion
    }
}
