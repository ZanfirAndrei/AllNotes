using AllNotes.Domain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.Models.Memo
{
    public class CheckBox : BaseEntity
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }
        public int? ScheduleId { get; set; }
        public int? NoteId { get; set; }
        public int? CheckListId { get; set; }
        public virtual Note Note { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual CheckList CheckList { get; set; }
    }
}
