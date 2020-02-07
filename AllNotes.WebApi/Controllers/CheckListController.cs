using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllNotes.Domain.Models.Memo;
using AllNotes.Models;
using AllNotes.Services.IServices;
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
        public async Task<ObjectResult> GetAllCheckListsAsync()
        {
            IList<CheckList> result = await _checkListServices.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("GetCheckLists/{id}")]
        public async Task<ObjectResult> GetCheckListAsync([FromRoute] int id)
        {
            CheckList result = await _checkListServices.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost("AddCheckList")]
        public async Task<ObjectResult> AddCheckListAsync([FromBody] CheckListDto dto)
        {



            CheckList result = await _checkListServices.CreateAsync(dto);

            return Ok(result);
        }

        [HttpPut("UpdateCheckList/{id}")]
        public async Task<ObjectResult> UpdateCheckListAsync([FromRoute] int id, [FromBody] string name, bool isComplete)
        {
            CheckList result = await _checkListServices.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest(new { message = "CheckList not available" });
            }

            var checkList = new CheckList { Id = result.Id, Name = name , IsComplete = isComplete};
            await _checkListServices.UpdateAsync(checkList);

            return Ok(result);
        }

        [HttpDelete("DeleteCheckList/{id}")]
        public async Task<ObjectResult> DeleteCheckList([FromRoute] int id)
        {
            CheckList result = await _checkListServices.GetByIdAsync(id);
            await _checkListServices.DeleteAsync(result);

            return Ok(result);
        }
        #endregion


        #region CheckBox
        [HttpGet("GetCheckBoxes")]
        public async Task<ObjectResult> GetAllBoxesAsync()
        {
            IList<CheckBox> result = await _checkBoxServices.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("GetCheckBoxes/{id}")]
        public async Task<ObjectResult> GetCheckBoxAsync([FromRoute] int id)
        {
            CheckBox result = await _checkBoxServices.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost("AddCheckBox")]
        public async Task<ObjectResult> AddCheckBoxAsync([FromBody] string name, int checkListId)
        {

            CheckBox result = await _checkBoxServices.CreateAsync(name,checkListId);

            return Ok(result);
        }

        [HttpPut("UpdateCheckBox/{id}")]
        public async Task<ObjectResult> UpdateCheckBoxAsync([FromRoute] int id, [FromBody] string name, bool isChecked)
        {
            CheckBox result = await _checkBoxServices.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest(new { message = "CheckBox not available" });
            }

            var checkBox = new CheckBox { Id = result.Id, Name = name, IsChecked = isChecked};
            await _checkBoxServices.UpdateAsync(checkBox);

            return Ok(result);
        }

        [HttpDelete("DeleteCheckBox/{id}")]
        public async Task<ObjectResult> DeleteCheckBox([FromRoute] int id)
        {
            CheckBox result = await _checkBoxServices.GetByIdAsync(id);
            await _checkBoxServices.DeleteAsync(result);

            return Ok(result);
        }
        #endregion
    }
}
