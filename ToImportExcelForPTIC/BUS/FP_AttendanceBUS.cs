using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Toyo.Core
{
    public class FP_AttendanceBUS
    {
        Base b = new Base();
        FP_AttendanceDAO dao = new FP_AttendanceDAO();
        //public int  Create(FP_AttendanceVO vo)
        //{            
        //    int id;
        //    if (!dao.isExist(" InDate='" + vo.InDate+ "' AND OutDate='"+ vo.OutDate+ "' AND EMPID='" + vo.EmpID + "' and ScheduleID="+ vo.ScheduleId))
        //    {
        //        id = dao.Insert(vo);
        //    }
        //    else
        //    {    

        //        id = dao.Update(vo);
        //    }
        //    return id;
        //}
        //public int Update(FP_AttendanceVO vo)
        //{
        //    int id = 0;

        //    try
        //    {
        //        id = dao.Update(vo);
        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        MessageBox.Show("Update Error:" + sqlEx);
        //    }

        //    return id;
        //}

        public int UpdateByAttendanceID(FP_AttendanceVO vo)
        {
            int id = 0;

            try
            {
                id = dao.UpdateByAttendanceID(vo);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Update Error:" + sqlEx);
            }

            return id;
        }
        //public int CreateNew(FP_AttendanceVO vo)
        //{
        //    int id = 0;
        //    try
        //    {
        //        id = dao.Insert(vo);
        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        MessageBox.Show("Update Error:" + sqlEx);
        //    }

        //    return id;
        //}

        //public int CreateFromOtherActivity(FP_AttendanceVO vo)
        //{
        //    int id=0;
        //    try{
            
        //   // if (!dao.isExist(" InDate='" + vo.InDate + "' AND OutDate='" + vo.OutDate + "' AND EMPID='" + vo.EmpID + "' and ShiftID=" + vo.ShiftID))
        //    if (!dao.isExist(" InDate='" + vo.InDate + "' AND EMPID='" + vo.EmpID + "' and ShiftID=" + vo.ShiftID))
        //    {
        //        id = dao.Insert(vo);
        //    }
        //    else
        //    {
        //        id = dao.Update(vo);
        //    }
        //    }catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return id;
        //}
        public int CreateAttendance(FP_AttendanceVO vo)
        {
            int id = 0;
             string condition = "ShiftDateIn='"+vo.ShiftDateIn+ "' AND ShiftDateOut='"+vo.ShiftDateOut+"' AND InDate='" + vo.InDate + "' AND OutDate='" + vo.OutDate + "' AND EMPID='" + vo.EmpID + "' and ShiftID=" + vo.ShiftID;
         //string condition = " InDate='" + vo.InDate + "' AND EMPID='" + vo.EmpID + "' and ShiftID=" + vo.ShiftID;            
            DataTable dt = b.Select("FP_Attendance", condition);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    bool flg = (bool)dr["isOtherActivity"];
                    if (!flg)
                        id = dao.Update(vo);
                }
            }
            else
            {
                id = dao.Insert(vo);
            }

            return id;
        }
    }
}
