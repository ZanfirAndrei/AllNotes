using AllNotes.Domain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.Models.Memo
{
    public class CheckList : BaseEntity
    {
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsComplete { get; set; }
        public int? ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual ICollection<CheckBox> CheckBoxes { get; set; }

    }
}
