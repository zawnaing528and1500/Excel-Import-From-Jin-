using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class BankDAO
    {
        Base b = new Base();
        public int Insert(BankVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert("Bank", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(BankVO vo)
        {
            int bankID = 0;
            try
            {
                b.Update("Bank", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                bankID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bankID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("Bank", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Bank");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public BankVO GetByID(int id)
        {
            BankVO vo = new BankVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new BankVO()) as BankVO;
            return vo;
        }
        public BankVO GetByBank(string bank)
        {
            BankVO vo = new BankVO();
            DataTable dt = Select("Bank='" + bank + "'");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new BankVO()) as BankVO;
            return vo;
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Bank", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByQuery(string value1, string value2)
        {
            DataTable dt = new DataTable();
            try
            {
                //List<string> col = new List<string>();
                //List<object> val = new List<object>();
                if (value1 != "" && value2 != "")
                {
                    //col.Add("Bank");
                    //col.Add("Town");
                    //val.Add(value1);
                    //val.Add(value2);
                    //return b.SelectByCondition("vw_Bank", col, val, "Bank=@Bank AND Town=@Town");
                    dt = b.SelectByQuery("select * from vw_Bank where Bank=N'" + value1 + "' AND Town=N'" + value2 + "'");
                }
                else if (value1 != "" && value2 == "")
                {
                    //col.Add("Bank");
                    //val.Add(value1);
                    //return b.SelectByCondition("vw_Bank", col, val, "Bank=@Bank");
                    dt = b.SelectByQuery("select * from vw_Bank where Bank=N'" + value1 + "'");
                }
                else if (value1 == "" && value2 != "")
                {
                    //col.Add("Town");
                    //val.Add(value2);
                    //return b.SelectByCondition("vw_Bank", col, val, "Town=@Town");
                    dt = b.SelectByQuery("select * from vw_Bank where Town=N'" + value2 + "'");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public void Delete(string id)
        {
            try
            {
                b.Delete("Bank", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectByCondition(string condition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Bank", condition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByView()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.SelectAll("vw_Bank");
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
    }
}
