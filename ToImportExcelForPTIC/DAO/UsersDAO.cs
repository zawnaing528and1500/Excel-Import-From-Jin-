using System;
using System.Data;

namespace Toyo.Core
{
    public class UsersDAO
    {
        Base b = new Base();
//        public int Insert(UsersVO vo)
//        {
//            int lastInsertId = 0;
//            try
//            {
//                lastInsertId = b.Insert("Users", b.ConvertColName(vo), b.ConvertValueList(vo));
//                string syncDataToOtherDB = @"SET IDENTITY_INSERT [{0}].[dbo].[Users] ON
//                                           INSERT INTO [{0}].[dbo].[Users]([ID],[EmpID],[UserName],[Password],[AccessLevelID],[AssignUserID],[AssignPassword],[IsAssign],[CreatedDate],[UpdatedDate],[IsActive])
//                                           SELECT [ID],[EmpID],[UserName],[Password],[AccessLevelID],[AssignUserID],[AssignPassword],[IsAssign],[CreatedDate],[UpdatedDate],[IsActive]
//                                           FROM [dbo].[Users]
//                                           WHERE [ID]={1}
//                                           SET IDENTITY_INSERT [{0}].[dbo].[Users] OFF ";
//                if (Program.Branch == "HO")
//                {
//                    string salesDataBaseName = Properties.Settings.Default.PTIC_Sales_DbName;

//                    string cmdSql = string.Format(syncDataToOtherDB, salesDataBaseName, lastInsertId);
//                    int effectedCount = b.ExecuteNonQuery(cmdSql);
//                }
//                else if (Program.Branch == "Factory")
//                {
//                    string FactoryDataBaseName = Properties.Settings.Default.Proven_Factory_DbName;

//                    string cmdSql = string.Format(syncDataToOtherDB, FactoryDataBaseName, lastInsertId);
//                    int effectedCount = b.ExecuteNonQuery(cmdSql);
//                }

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            return lastInsertId;
//        }

        //public int Update(UsersVO vo)
        //{
        //    int ID = 0;
        //    try
        //    {
        //        b.Update("Users", vo.ID.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
        //        ID = vo.ID;
        //        string syncDataToOtherDB = @"UPDATE [{0}].[dbo].[Users] SET [EmpID]=" + vo.EmpID + ",[UserName]=N'" + vo.UserName + "',[Password]=N'" + vo.Password
        //                                  + "',[AccessLevelID]=" + vo.AccesslevelID + ",[AssignUserID]=" + vo.AssignUserID + ",[AssignPassword]=N'" + vo.AssignPassword + "',[IsAssign]='" + vo.IsAssign
        //                                  + "',[UpdatedDate]='" + vo.UpdatedDate + "',[IsActive]='" + vo.IsActive + "' WHERE [ID]={1}";
        //        if (Program.Branch == "HO")
        //        {
        //            string salesDataBaseName = Properties.Settings.Default.PTIC_Sales_DbName;

        //            string cmdSql = string.Format(syncDataToOtherDB, salesDataBaseName, ID);
        //            int effectedCount = b.ExecuteNonQuery(cmdSql);
        //        }
        //        else if (Program.Branch == "Factory")
        //        {
        //            string FactoryDataBaseName = Properties.Settings.Default.Proven_Factory_DbName;

        //            string cmdSql = string.Format(syncDataToOtherDB, FactoryDataBaseName, ID);
        //            int effectedCount = b.ExecuteNonQuery(cmdSql);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ID;
        //}

        public bool isExist(string key)
        {
            return b.CheckRec("Users", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("Users");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public UsersVO GetByID(int id)
        {
            UsersVO vo = new UsersVO();
            DataTable dt = Select("ID=" + id + "");
            if (dt.Rows.Count > 0)
                vo = b.ConvertObj(dt.Rows[0], new UsersVO()) as UsersVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("Users", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        public DataTable SelectByQuery(string value1)
        {
            DataTable dt = new DataTable();
            try
            { 
                dt = b.SelectByQuery("select * from Users where UserName=N'" + value1 + "'");
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
                b.Delete("Users", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsExist(string Condition)
        {
            bool exist = false;
            try
            {
                DataTable dt = Select(Condition);
                if (dt.Rows.Count > 0)
                    exist = true;
                return exist;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DataTable SelectAllView()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("vw_Users_List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectViewByCodition(string Codition)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("vw_Users_List", Codition);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        #region Paging
        public DataTable SelectTopRowsFinal(int start, int end)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowsFinal("vw_Users_List", start, end);
            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }


        public DataTable SelectTopRowByCondition(double count, int start, string condition)
        {
            DataTable dt;
            try
            {
                dt = b.SelectTopRowByCondition("vw_Users_List", condition, count, start);

            }
            catch (Exception Sql)
            { throw Sql; }
            return dt;
        }
        #endregion

    }
}
