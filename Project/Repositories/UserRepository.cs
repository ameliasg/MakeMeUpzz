using Project.Factories;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class UserRepository
    {
        DatabaseEntities db = DatabaseSingleton.GetInstance();
        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }
        public int GetLastUserID()
        {
            return (from x in db.Users select x.UserID).ToList().LastOrDefault();
        }
        public void InsertUser(int id, String Username, String Email, DateTime DOB, String Gender, String Role, String Password)
        {
            User user = UserFactory.Create(id, Username, Email, DOB, Gender, Role, Password);
            db.Users.Add(user);
            db.SaveChanges();
        }
        public User GetUserIDByEmail(String email)
        {
            return (from customer in db.Users where customer.UserEmail == email select customer).FirstOrDefault();
        }
        public User Login(string email, string password)
        {
            return (from customer in db.Users where customer.UserEmail == email && customer.UserPassword == password select customer).FirstOrDefault();
        }
        public User CheckEmailUnique(string email)
        {
            return (from customer in db.Users where customer.UserEmail == email select customer).FirstOrDefault();
        }
        public void RemoveUser(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }
        public User GetUserByID(int id)
        {
            User user = db.Users.Find(id);
            return user;
        }
        public void UpdateUserByID(int id, String Username, String Email, DateTime DOB, String Gender, String Role, String Password)
        {
            User updateUser = GetUserByID(id);
            updateUser.Username = Username;
            updateUser.UserEmail = Email;
            updateUser.UserDOB = DOB;
            updateUser.UserGender = Gender;
            updateUser.UserRole = Role;
            updateUser.UserPassword = Password;
            db.SaveChanges();
        }
    }
}