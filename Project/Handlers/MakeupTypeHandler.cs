using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class MakeupTypeHandler
    {
        MakeupTypeRepository typeRepo = new MakeupTypeRepository();
        public void InsertMakeupType(int id, String name)
        {
            typeRepo.InsertMakeupType(id, name);
        }

        //public MakeupType getUniqueName(String name)
        //{
        //    return typeRepo.getUniqueName(name);
        //}

        public List<MakeupType> GetAllMakeupType()
        {
            return typeRepo.GetMakeupTypes();
        }

        public MakeupType GetMakeupType(int id)
        {
            return typeRepo.GetMakeupTypeByID(id);
        }
        public void UpdateType(int id, String name)
        {
            typeRepo.UpdateMakeupTypeByID(id, name);
        }

        public void DeleteMakeupType(int id)
        {
            typeRepo.RemoveMakeupTypeByID(id);
        }
    }
}