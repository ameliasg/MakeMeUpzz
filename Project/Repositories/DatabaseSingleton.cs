using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class DatabaseSingleton
    {
        private static DatabaseEntities db = null;

        public static DatabaseEntities GetInstance()
        {
            if (db == null)
            {
                db = new DatabaseEntities();
            }
            return db;
        }
    }
}