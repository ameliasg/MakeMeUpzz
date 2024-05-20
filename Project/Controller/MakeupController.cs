using Project.Handlers;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Project.Controller
{
    public class MakeupController
    {
        MakeupHandler mh = new MakeupHandler();

        public String CheckName(String name)
        {
            String errorMsg = null;
            if (name.Length == 0)
            {
                errorMsg = "Makeup Name must be filled!";
            }
            else if (name.Length > 99)
            {
                errorMsg = "Makeup Name length must be less than 100 characters!";
            }
            return errorMsg;
        }
        public String CheckPrice(int price)
        {
            String errorMsg = null;
            if (price < 1)
            {
                errorMsg = "Makeup Price must be filled!";
            }
            return errorMsg;
        }
        public String CheckWeight(int weight)
        {
            String errorMsg = null;
            if (weight > 1500)
            {
                errorMsg = "Makeup Weight cannot be greater than 1500 grams!";
            }
            return errorMsg;
        }

        public String Insert(int id, String name, int price, int weight, int typeId, int brandId)
        {
            String errorMsg = CheckName(name);
            if (errorMsg == null)
            {
                errorMsg = CheckPrice(price);
            }
            if (errorMsg == null)
            {
                errorMsg = CheckWeight(weight);
            }
            if (errorMsg == null)
            {
                errorMsg = null;
                mh.InsertMakeup(id, name, price, weight, brandId, typeId);
            }
            return errorMsg;
        }

        public String Update(int id, String name, int price, int weight, int typeId, int brandId)
        {
            String errorMsg = CheckName(name);
            if (errorMsg == null)
            {
                errorMsg = CheckPrice(price);
            }
            if (errorMsg == null)
            {
                errorMsg = CheckWeight(weight);
            }
            if (errorMsg == null)
            {
                errorMsg = null;
                Makeup makeup = mh.SearchMakeup(id);
                mh.UpdateMakeup(id, name, price, weight,brandId, typeId);
            }
            return errorMsg;
        }

        public void Delete(int MakeupId)
        {
            mh.DeleteMakeup(MakeupId);
        }
    }
}