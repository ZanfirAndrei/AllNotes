using System;
using System.Collections.Generic;
using System.Text;
using AllNotes.Domain.Models.Memo;
using AllNotes.Domain.Models.Sport;
using Microsoft.AspNetCore.Identity;

namespace AllNotes.Domain.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<CheckList> CheckLists { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
