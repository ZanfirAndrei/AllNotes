using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllNotes.Models
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryDto Category { get; set; }
        public ScheduleDto? Schedule { get; set; }
        public ICollection<SeriesDto> Series { get; set; }
    }
}
