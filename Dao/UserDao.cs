using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBookStore.Models.WebBookStore;
using WebBookStore.Common;
using WebBookStore.Models.UtilsModel;

namespace WebBookStore.Dao
{
    public class UserDao
    {
        WBSDbContext db = null;

        public UserDao()
        {
            db = new WBSDbContext();
        }

        public long Insert(NGUOIDUNG user)
        {
            db.NGUOIDUNGs.Add(user);
            db.SaveChanges();
            return user.ID;
        }

        public long Update(RegisterModel model)
        {
            var user = db.NGUOIDUNGs.SingleOrDefault(x => x.Email == model.Email);
            user.HoVaTen = model.HoVaTen;
            user.SDT = model.SDT;
            user.MatKhau = Encryptor.MD5Hash(model.MatKhau);
            user.DiaChi = model.DiaChi;
            db.SaveChanges();

            return user.ID;
        }

        public bool CheckEmail(string email)
        {
            return db.NGUOIDUNGs.Count(x => x.Email == email) > 0;
        }

        public List<string> GetListCredential(string email)
        {
            var user = db.NGUOIDUNGs.SingleOrDefault(x => x.Email == email);
            var data = (from a in db.PHANQUYENs
                       join b in db.NHOMNDs on a.MaNhomND equals b.ID
                       join c in db.QUYENs on a.MaQuyen equals c.ID
                       where b.ID == user.MaNhom
                       select new 
                       {
                           MaQuyen = a.MaQuyen,
                           MaNhomND = a.MaNhomND
                       }).AsEnumerable().Select(x => new PHANQUYEN()
                       {
                           MaQuyen = x.MaQuyen,
                           MaNhomND = x.MaNhomND
                       });
            return data.Select(x => x.MaQuyen).ToList();
        }
        public NGUOIDUNG GetByID(long ID)
        {
            return db.NGUOIDUNGs.SingleOrDefault(x => x.ID == ID);
        }
        public NGUOIDUNG GetByEmail(string userName)
        {
            return db.NGUOIDUNGs.SingleOrDefault(x => x.Email == userName);
        }

        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.NGUOIDUNGs.SingleOrDefault(x => x.Email == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.MaNhom != CommonConstants.CUSTOMER_GROUP)
                    {
                        if (result.TrangThai == 0)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.MatKhau == passWord)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.TrangThai == 0)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.MatKhau == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }
    }
}