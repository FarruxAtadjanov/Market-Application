using System;
using System.Collections.Generic;
using System.Linq;
using Market_Application.IRepositories;
using Market_Application.Enum;
using System.IO;
using Market_Application.Servise;
using Market_Application.Models;
using Newtonsoft.Json;
using System.Threading;

namespace Market_Application.Repository

{
    internal class UserRepository : IUserReposirory
    {
        public void Create(User user)
        {
            
                string json = File.ReadAllText(Constants.UsersDbPath);
                IList<User> users = JsonConvert.DeserializeObject<List<User>>(json);
                users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Login = user.Login,
                    Password = user.Password,
                    Role = UserRole.User,

                });
                string jsonOut = JsonConvert.SerializeObject(users);
                File.WriteAllText(Constants.UsersDbPath, jsonOut);
                Console.WriteLine("Tabriklaymiz siz muaffaqiyatli ro'yxatdan o'tdingiz");

                Thread.Sleep(1500);
                Console.Clear();
                Menu.RunMainMenu();
            
        }

        public User Login(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
