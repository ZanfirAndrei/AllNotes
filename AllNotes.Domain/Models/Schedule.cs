using AllNotes.Domain.Models.BaseModel;
using AllNotes.Domain.Models.Sport;
using AllNotes.Domain.Models.Memo;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.Models
{
    public class Schedule : BaseEntity
    {
        public DateTime Date { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<CheckList> CheckLists { get; set; }
        public virtual ICollection<CheckBox> CheckBoxes { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
