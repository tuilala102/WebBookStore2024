using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBookStore.Models.WebBookStore;
using System.Collections;

namespace WebBookStore.Common
{
    [Serializable]
    public class UserLogin
    {
        public long ID { set; get; }
        public string Email { set; get; }
        public string MaNhom { set; get; }

        public List<SANPHAM> SanPhamDaXem
        {
            set; get;
        }
    }
}