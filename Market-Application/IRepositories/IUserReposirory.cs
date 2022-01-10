using Market_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Market_Application.IRepositories
{
     interface IUserReposirory
    {
        public void Create(User user);

        User Login(string login, string password);

    }
}
