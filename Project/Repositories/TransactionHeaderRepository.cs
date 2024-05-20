using Project.Factories;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class TransactionHeaderRepository
    {
        DatabaseEntities db = DatabaseSingleton.GetInstance();
        public void InsertTransactionHeader(int TransactionHeaderID, int UserID, DateTime TransactionDate, String Status)
        {
            TransactionHeader transactionheader = TransactionHeaderFactory.Create(TransactionHeaderID, UserID, TransactionDate, Status);
            db.TransactionHeaders.Add(transactionheader);
            db.SaveChanges();
        }
        public List<TransactionHeader> GetTransactionHeaders()
        {
            return db.TransactionHeaders.ToList();
        }
        public List<TransactionHeader> GetTHByUser(int id)
        {
            return (from transaction in db.TransactionHeaders where transaction.UserID == id select transaction).ToList();
        }
        public void RemoveTransactionHeaderByID(int id)
        {
            TransactionHeader transactionheader = db.TransactionHeaders.Find(id);
            db.TransactionHeaders.Add(transactionheader);
            db.SaveChanges();
        }
        public void UpdateTransactionHeaderByID(int id, int UserID, DateTime TransactionDate, String Status)
        {
            TransactionHeader updateTransactionHeader = db.TransactionHeaders.Find(id);
            updateTransactionHeader.UserID = UserID;
            updateTransactionHeader.TransactionDate = TransactionDate;
            updateTransactionHeader.Status = Status;
            db.SaveChanges();
        }
        public String GetTransactionHeaderStatus(int id)
        {
            return (from x in db.TransactionHeaders where x.TransactionID==id select x.Status).FirstOrDefault();
        }
       
        public TransactionHeader GetTransactionHeaderByID(int id)
        {
            return (from x in db.TransactionHeaders
                    where x.TransactionID.Equals(id)
                    select x).FirstOrDefault();
        }
    }
}