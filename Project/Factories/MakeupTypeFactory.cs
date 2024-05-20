using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factories
{
    public class MakeupTypeFactory
    {
        public static MakeupTypes Create(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupType mt = new MakeupType();
            mt.MakeupTypeID = MakeupTypeID;
            mt.MakeupTypeName = MakeupTypeName;
            return mt;
        }
    }
}