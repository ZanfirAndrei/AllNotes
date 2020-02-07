using AllNotes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllNotes.Domain.EF.Users
{
    public class UserRepository
    {
        public static List<User> Users;

        static UserRepository()
        {
            Users = new List<User>();
        }
    }
}
