using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BonkCrud.Models
{
    public class DataAccess
    {
        crudContext db = new crudContext();

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return db.Users.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Item> GetAllItems()
        {
            try
            {
                return db.Items.ToList();
            }
            catch
            {
                throw;
            }
        }

        public int AddUser(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int UpdateUser(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int AddItem(Item item)
        {
            try
            {
                db.Items.Add(item);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int UpdateItem(Item item)
        {
            try
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public Item GetItemData(int id)
        {
            try
            {
                Item item = db.Items.Find(id);
                return item;
            }
            catch
            {
                throw;
            }
        }

        public int DeleteUser(int id)
        {
            try
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int DeleteItem(int id)
        {
            try
            {
                Item item = db.Items.Find(id);
                db.Items.Remove(item);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public User GetUserData(int id)
        {
            try
            {
                User user = db.Users.Find(id);
                return user;
            }
            catch
            {
                throw;
            }
        }


    }
}
