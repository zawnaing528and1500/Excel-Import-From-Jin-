using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Toyo.Core
{
    public class OfficeAccessoriesIssueDetailDAO
    {
        Base b = new Base();
        public int Insert(OfficeAccessoriesIssueDetailVO vo)
        {
            int lastInsertId = 0;

            try
            {
                lastInsertId = b.Insert("OfficeAccessories_Issue_Detail", b.ConvertColName(vo), b.ConvertValueList(vo));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        public bool isExist(string key)
        {
            return b.CheckRec("OfficeAccessories_Issue_Detail", key);
        }

        public int Update(OfficeAccessoriesIssueDetailVO vo)
        {
            int vehiclePartID = 0;
            try
            {
                b.Update("OfficeAccessories_Issue_Detail", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                vehiclePartID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vehiclePartID;
        }
        public OfficeAccessoriesIssueDetailVO GetByID(int id)
        {
            OfficeAccessoriesIssueDetailVO vo = new OfficeAccessoriesIssueDetailVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new OfficeAccessoriesIssueDetailVO()) as OfficeAccessoriesIssueDetailVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("OfficeAccessories_Issue_Detail", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }
        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("OfficeAccessories_Issue_Detail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable SelectAllByView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_OfficeAccessoriesIssueDetail");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
