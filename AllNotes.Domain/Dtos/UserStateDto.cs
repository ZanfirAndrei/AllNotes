using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.Dtos
{
    public class UserStateDto
    {
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
    }
}
