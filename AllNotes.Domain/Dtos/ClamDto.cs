
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.Dtos
{
    public class ClaimDto
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class UserClaims
    {
        public IEnumerable<ClaimDto> Claims { get; set; }
        public string UserName { get; set; }
    }
}
