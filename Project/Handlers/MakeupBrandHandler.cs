using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class MakeupBrandHandler
    {
        MakeupBrandRepository brandRepo = new MakeupBrandRepository();
        public void InsertMakeupBrand(int id, String BrandName, int BrandRating)
        {
            brandRepo.InsertMakeupBrand(id, BrandName, BrandRating);
        }

        //public MakeupBrand GetUniqueName(String name)
        //{
        //    return brandRepo.getUniqueName(name);
        //}

        public List<MakeupBrand> GetAllMakeupBrand()
        {
            return brandRepo.GetMakeupBrands();
        }

        public MakeupBrand GetMakeupBrand(int id)
        {
            return brandRepo.GetMakeupBrandByID(id);
        }
        public void Update(int id, String BrandName, int BrandRating)
        {
            brandRepo.UpdateMakeupBrandByID(id, BrandName, BrandRating);
        }

        public void DeleteMakeupBrand(int id)
        {
            brandRepo.RemoveMakeupBrandByID(id);
        }
    }
}