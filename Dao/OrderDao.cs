using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBookStore.Models.WebBookStore;
namespace WebBookStore.Dao
{
    public class OrderDao
    {
        WBSDbContext db = null;
        public OrderDao()
        {
            db = new WBSDbContext();
        }
        public long insert(DONHANG order)
        {
            db.DONHANGs.Add(order);
            db.SaveChanges();
            return order.ID;
        }
    }
}