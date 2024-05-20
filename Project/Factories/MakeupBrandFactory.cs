using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.Factories
{
    public class MakeupBrandFactory
    {
        public static MakeupBrand Create(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrand mb = new MakeupBrand();
            mb.MakeupBrandID = MakeupBrandID;
            mb.MakeupBrandName = MakeupBrandName;
            mb.MakeupBrandRating = MakeupBrandRating;
            return mb;
        }
    }
}