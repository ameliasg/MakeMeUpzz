using Project.Factories;
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
        public void InsertMakeupBrand(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrand makeupbrand = MakeupBrandFactory.Create(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
            db.MakeupBrands.Add(makeupbrand);
            db.SaveChanges();
        }
        public int GetLastBrandID()
        {
            return (from x in db.MakeupBrands select x.MakeupBrandID).ToList().LastOrDefault();
        }
        public List<MakeupBrand> GetMakeupBrands()
        {
            return db.MakeupBrands.ToList();
        }
        public void RemoveMakeupBrandByID(int id)
        {
            MakeupBrand makeupbrand = db.MakeupBrands.Find(id);
            db.MakeupBrands.Remove(makeupbrand);
            db.SaveChanges();
        }
        public void UpdateMakeupBrandByID(int id, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrand updateMakeupBrand = db.MakeupBrands.Find(id);
            updateMakeupBrand.MakeupBrandName = MakeupBrandName;
            updateMakeupBrand.MakeupBrandRating = MakeupBrandRating;
            db.SaveChanges();
        }
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
        public MakeupBrand GetMakeupBrandByID(int id)
        {
            return (from x in db.MakeupBrands
                    where x.MakeupBrandID.Equals(id)
                    select x).FirstOrDefault();
        }
    }
}