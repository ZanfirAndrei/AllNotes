using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllNotes.Models
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        //public int UserId { get; set; }
        public ScheduleDto? Schedule { get; set; }
        public ICollection<CheckBoxDto>? CheckBoxes { get; set; }
    }
}
