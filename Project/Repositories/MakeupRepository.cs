using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Factories;
using Project.Models;

namespace Project.Repositories
{
    public class MakeupRepository
    {
        DatabaseEntities db = DatabaseSingleton.GetInstance();
        public List<Makeup> GetMakeups()
        {
            //return (from x in db.Makeups select x).ToList();
            return db.Makeups.ToList();
        }
        public int GetLastMakeupID()
        {
            return (from x in db.Makeups select x.MakeupID).ToList().LastOrDefault();
        }
        public void InsertMakeup(int MakeupID, String MakeupName, int MakeuPrice, int MakeWeight, 
            int MakeupTypeID, int MakeupBrandID)
        {
            Makeup makeup = MakeupFactory.Create(MakeupID, MakeupName, MakeuPrice, MakeWeight, 
                MakeupTypeID, MakeupBrandID);
            db.Makeups.Add(makeup);
            db.SaveChanges();
        }
        public void RemoveMakeupByID(int id)
        {
            Makeup makeup = db.Makeups.Find(id);
            db.Makeups.Remove(makeup);
            db.SaveChanges();
        }
        public Makeup GetMakeupByID(int id)
        {
            Makeup makeup= db.Makeups.Find(id);
            return makeup;
        }
        public void UpdateMakeupByID(int id, String MakeupName, int MakeupPrice, int MakeupWeight, 
            int MakeupTypeID, int MakeupBrandID)
        {
            Makeup updateMakeup = GetMakeupByID(id);
            //updateMakeup.MakeupID = id;
            updateMakeup.MakeupName = MakeupName;
            updateMakeup.MakeupPrice = MakeupPrice;
            updateMakeup.MakeupWeight = MakeupWeight;
            updateMakeup.MakeupTypeID = MakeupTypeID;
            updateMakeup.MakeupBrandID = MakeupBrandID;
            db.SaveChanges();
        }
    }
}