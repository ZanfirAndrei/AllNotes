using AllNotes.Domain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.Models.Sport
{
    public class Series : BaseEntity
    {
        public int Repeats { get; set; }
        public float Weights { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}
