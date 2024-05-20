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
        public void InsertMakeupType(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupType makeuptype = MakeupTypeFactory.Create(MakeupTypeID, MakeupTypeName);
            db.MakeupTypes.Add(makeuptype);
            db.SaveChanges();
        }
        public List<MakeupType> GetMakeupTypes()
        {
            return db.MakeupTypes.ToList();
        }
        public void RemoveMakeupTypeByID(int id)
        {
            MakeupTypes makeuptype = db.MakeupTypes.Find(id);
            db.MakeupTypes.add(makeuptype);
            db.SaveChanges();
        }
        public void UpdateMakeupTypeByID(int id, String MakeupTypeName)
        {
            MakeupType updateMakeupType = db.MakeupTypes.Find(id);
            updateMakeupType.MakeupTypeName = MakeupTypeName;
            db.SaveChanges();
        }
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
        public MakeupType GetMakeupTypeByID(int id)
        {
            return (from x in db.MakeupTypes
                    where x.MakeupTypeID.Equals(id)
                    select x).FirstOrDefault();
        }
    }
}