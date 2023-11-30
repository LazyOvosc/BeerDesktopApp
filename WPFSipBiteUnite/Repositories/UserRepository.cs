﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSipBiteUnite.DataBaseClasses;
using WPFSipBiteUnite.DbContext;

namespace WPFSipBiteUnite.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        User GetUserById(int userId);
        User GetUserByName(string name);
        List<User> GetAllUsers();
    }

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }
        
        public User GetUserByName(string name)
        {
            return _context.Users.First(u=>u.name==name);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        
    }
}
