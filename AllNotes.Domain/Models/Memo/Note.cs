using AllNotes.Domain.Models.BaseModel;
using AllNotes.Domain.Models.Sport;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.Models.Memo
{
    public class Note : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime Timestamp { get; set; }
        public string? UserId { get; set; }
        public int? ScheduleId { get; set; }
        public virtual User User { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual ICollection<CheckBox> CheckBoxes { get; set; }

    }
}
