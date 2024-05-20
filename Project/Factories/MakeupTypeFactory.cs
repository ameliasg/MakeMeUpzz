using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.Factories
{
    public class MakeupTypeFactory
    {
        public static MakeupType Create(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupType mt = new MakeupType();
            mt.MakeupTypeID = MakeupTypeID;
            mt.MakeupTypeName = MakeupTypeName;
            return mt;
        }
    }
}