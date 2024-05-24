using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class UserHandler
    {
        UserRepository userRepo = new UserRepository();
        public void InsertUser(int id, String UserName, String UserEmail, DateTime DOB, String UserGender, String UserRole, String Password)
        {
            userRepo.InsertUser(id, UserName, UserEmail, DOB, UserGender, UserRole, Password);
        }
        public User CheckEmailUnique(string email)
        {
            return userRepo.CheckEmailUnique(email);
        }

        public User Login(string email, string password)
        {
            return userRepo.Login(email, password);
        }

        public User GetUserIDByEmail(string email)
        {
            return userRepo.GetUserIDByEmail(email);
        }

        public void UpdateUser(int id, String UserName, String UserEmail, DateTime DOB, String UserGender, String UserRole, String Password)
        {
            userRepo.UpdateUserByID(id, UserName, UserEmail, DOB, UserGender, UserRole, Password);
        }

        public void DeleteAccount(int UserId)
        {
            userRepo.RemoveUser(UserId);
        }
    }
}