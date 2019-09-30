using Demo.Models;
using Demo.Pocos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Demo.Repository
{
    public class UserService : IUserRepository
    {
        public int AddUser(UserPocos user)
        {
            using (DemoDbEntities db = new DemoDbEntities())
            {
                User newUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    Description = user.Description,
                    DepartmentId = user.DepartmentId,
                    Country = user.Country,
                    Active = user.Active,

                };
                db.Users.Add(newUser);
                db.SaveChanges();
                return newUser.Id;
            }

        }

        public void DeleteUser(int id)
        {
            using (DemoDbEntities db=new DemoDbEntities())
            {
                db.Users.Remove(db.Users.Where(z => z.Id == id).FirstOrDefault());
                db.SaveChanges();
            }
        }

        public User GetUser(int? id)
        {
            using (DemoDbEntities db=new DemoDbEntities())
            {
                return db.Users.FirstOrDefault(z => z.Id == id);
            }
        }

        public List<User> GetUsers()
        {
            DemoDbEntities db = new DemoDbEntities();
            
                return db.Users.ToList();

        }

        public void UpdateUser(UserPocos user)
        {
            using (DemoDbEntities db = new DemoDbEntities())
            {
               User olduser= db.Users.FirstOrDefault(z => z.Id == user.Id);
                olduser.FirstName = user.FirstName;
                olduser.LastName = user.LastName;
                olduser.Country = user.Country;
                olduser.Address = user.Address;
                olduser.DepartmentId = user.DepartmentId;
                olduser.Description = user.Description;
                olduser.Active = user.Active;
                db.SaveChanges();
            }
           
        }
    }
}