using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class MakeupBrandRepository
    {
        DatabaseEntities db = DatabaseSingleton.GetInstance();
        public List<String> GetMakeupBrandName()
        {
            return (from x in db.MakeupBrands select x.MakeupBrandName).ToList();
        }
        public int GetMakeupBrandIDByName(String name)
        {
            return (from x in db.MakeupBrands
                    where x.MakeupBrandName.Equals(name)
                    select x.MakeupBrandID).FirstOrDefault();
        }
        public String GetMakeupBrandNameByID(int id)
        {
            return (from x in db.MakeupBrands
                    where x.MakeupBrandID.Equals(id)
                    select x.MakeupBrandName).FirstOrDefault();
        }
    }
}