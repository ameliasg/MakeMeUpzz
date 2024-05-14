using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class MakeupTypeRepository
    {
        DatabaseEntities db = DatabaseSingleton.GetInstance();
        public List<String> GetMakeupTypeNames()
        {
            return (from x in db.MakeupTypes select x.MakeupTypeName).ToList();

        }
        public int GetMakeupTypeIDByName(String name)
        {
            return (from x in db.MakeupTypes where x.MakeupTypeName.Equals(name) 
                    select x.MakeupTypeID).FirstOrDefault();
        }
        public String GetMakeupTypeNameByID(int id)
        {
            return (from x in db.MakeupTypes
                    where x.MakeupTypeID.Equals(id)
                    select x.MakeupTypeName).FirstOrDefault();
        }
    }
}