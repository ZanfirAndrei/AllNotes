using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllNotes.Domain.Dtos
{
    public class CheckBoxDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
        public int CheckListId { get; set; }
        public ScheduleDto? Schedule { get; set; }
        //public NoteViewModel? Note { get; set; }
        //public CheckListViewModel? CheckList { get; set; }
    }
}
