using Project.Handlers;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Project.Controller
{
    public class MakeupBrandController
    {
        MakeupBrandHandler brandHandler = new MakeupBrandHandler();

        public String CheckBrand(String name, int rating)
        {
            String errorMsg = null;
            if (name.Length == 0)
            {
                errorMsg = "Makeup Brand Name must be filled!";
            }
            else if (name.Length > 99)
            {
                errorMsg = "Makeup Brand Name length must be less than 100 characters!";
            }
            if(rating < 0 || rating > 100)
            {
                errorMsg = "Rating must be between 1-100!";
            }
            return errorMsg;
        }

        public String Insert(int id, String name, int rating)
        {
            String errorMsg = CheckBrand(name, rating);
            if (errorMsg == null)
            {
                brandHandler.InsertMakeupBrand(id, name, rating);
            }
            return errorMsg;
        }

        public String Update(int id, String name, int rating)
        {
            String errorMsg = CheckBrand(name, rating);
            if (errorMsg == null)
            {
                MakeupBrand brand = brandHandler.GetMakeupBrandByID(id);
                brandHandler.Update(id, name, rating);
            }
            return errorMsg;
        }

        public void Delete(int brandId)
        {
            brandHandler.DeleteMakeupBrand(brandId);
        }
    }
}