using AllNotes.Domain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.Models.Sport
{
    public class Exercise : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
//        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int? ScheduleId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Schedule Schedule { get; set; }
        //        public virtual User User { get; set; }
        public virtual ICollection<Series> Series { get; set; }

    }
}
