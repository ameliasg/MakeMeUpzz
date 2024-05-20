using Project.Handlers;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Controller
{
    public class MakeupTypeController
    {
        MakeupTypeHandler typeHandler = new MakeupTypeHandler();

        public String CheckType(String name)
        {
            String errorMsg = null;
            if (name.Length == 0)
            {
                errorMsg = "Makeup Type Name must be filled!";
            }
            else if (name.Length > 99)
            {
                errorMsg = "Makeup Type Name length must be less than 100 characters!";
            }
            return errorMsg;
        }

        public String Insert(int id, String name)
        {
            String errorMsg = CheckType(name);
            if (errorMsg == null)
            {
                typeHandler.InsertMakeupType(id, name);
            }
            return errorMsg;
        }

        public String Update(int id, String name)
        {
            String errorMsg = CheckType(name);
            if (errorMsg == null)
            {
                MakeupType type = typeHandler.GetMakeupType(id);
                typeHandler.UpdateType(id, name);
            }
            return errorMsg;
        }

        public void Delete(int typeId)
        {
            typeHandler.DeleteMakeupType(typeId);
        }
    }
}