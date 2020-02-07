using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllNotes.Domain.Dtos
{
    public class CheckListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsComplete { get; set; }
        public UserDto User { get; set; }
        public ScheduleDto? Schedule { get; set; }
        public ICollection<CheckBoxDto> CheckBoxes { get; set; }
    }
}
