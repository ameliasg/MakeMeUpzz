using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class MakeupHandler
    {
        MakeupRepository makeupRepo = new MakeupRepository();

        public void InsertMakeup(int id, String MakeupName, int Price, int Weight, int BrandID, int TypeID)
        {
            makeupRepo.InsertMakeup(id, MakeupName, Price, Weight, BrandID, TypeID);
        }
        public List<Makeup> getMakeupsByBrand(int brandID)
        {
            return makeupRepo.GetMakeupByBrandID(brandID);
        }
        public Makeup SearchMakeup(int MakeupId)
        {
            return makeupRepo.GetMakeupByID(MakeupId);
        }
        public void UpdateMakeup(int id, String MakeupName, int Price, int Weight, int BrandID, int TypeID)
        {
            makeupRepo.UpdateMakeupByID(id, MakeupName, Price, Weight, BrandID, TypeID);
        }

        public void DeleteMakeup(int MakeupId)
        {
            makeupRepo.RemoveMakeupByID(MakeupId);
        }
    }
}