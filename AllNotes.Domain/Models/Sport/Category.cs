using AllNotes.Domain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.Models.Sport
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        
    }
}
