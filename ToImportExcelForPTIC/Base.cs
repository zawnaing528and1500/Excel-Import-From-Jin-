using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Toyo.Core
{
    public class Base
    {
        #region Attributes

        private SqlConnection _Con;
        public string _ConStr = string.Empty;
        public SqlConnection Con
        {
            get { return _Con; }
            set { _Con = value; }
        }
        private SqlCommand _Cmd;

        public SqlCommand Cmd
        {
            get { return _Cmd; }
            set { _Cmd = value; }
        }
        private SqlDataAdapter _Adp;

        public SqlDataAdapter Adp
        {
            get { return _Adp; }
            set { _Adp = value; }
        }
        #endregion

        #region OpenConnection

        public bool checkDatabase()
        {
            SqlConnection conn = DBManager.GetInstance().GetDbConnection();
            if (conn.State == ConnectionState.Open)
            {
                DBManager.GetInstance().CloseDbConnection();
                return true;
            }
            else return false;
        }
        public void OpenConnection()
        {
            if (_Con == null) this._Con = DBManager.GetInstance().GetDbConnection();
            CloseConnection();
            _Con.Open();
        }
        public void CloseConnection()
        {
            if (_Con.State == ConnectionState.Open) _Con.Close();
        }
        #endregion

        #region ConvertObj n ConvertValue...

        public object ConvertObj(DataRow dr, object obj)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            object[] valueList = new object[props.Count];

            for (int i = 0; i < props.Count; i++)
            {
                object obj2 = dr[i];
                valueList[i] = obj2;
            }
            for (int i = 0; i < props.Count; i++)
            {
                if (valueList[i] != System.DBNull.Value)
                    props[i].SetValue(obj, valueList[i]);
            }
            return obj;
        }

        public object ConvertObjWithImage(DataRow dr, object obj)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            object[] valueList = new object[props.Count];

            for (int i = 0; i <= props.Count - 1; i++)
            {
                object obj2 = dr[i];
                valueList[i] = obj2;
            }
            for (int i = 0; i <= props.Count - 1; i++)
            {
                if (valueList[i] != System.DBNull.Value)
                    props[i].SetValue(obj, valueList[i]);
            }
            return obj;
        }

        public object[] ConvertValueList(object obj)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            object[] valueList = new object[props.Count];
            for (int i = 0; i < props.Count; i++)
            {
                if (props[i].GetValue(obj) != null)
                    valueList[i] = props[i].GetValue(obj).ToString();
                
                else valueList[i] = "";
            }
            return valueList;
        }

        public object[] ConvertValueListNullable(object obj)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            object[] valueList = new object[props.Count];
            for (int i = 0; i < props.Count; i++)
            {
                if (props[i].GetValue(obj) != null)
                    valueList[i] = props[i].GetValue(obj).ToString();

                else valueList[i] = null;
            }
            return valueList;
        }

        public string[] ConvertColName(object obj)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            string[] valueList = new string[props.Count];
            for (int i = 0; i < props.Count; i++)
                valueList[i] = props[i].Name;
            return valueList;
        }

        public SqlDbType GetDbType(object obj)
        {
            return (obj.GetType() == new decimal().GetType()) ? SqlDbType.Decimal : (obj.GetType() == new DateTime().GetType()) ? SqlDbType.DateTime : (obj.GetType() == true.GetType()) ? SqlDbType.Bit : (obj.GetType() == 1.GetType()) ? SqlDbType.Int : SqlDbType.Binary;
        }

        #endregion

        #region CRUD

        public void InsertWtithNoObject(string queryString)
        {
            //OpenConnection();
            //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            //cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = queryString;
            ////"INSERT Region (RegionID, RegionDescription) VALUES (5, 'NorthWestern')"
            //cmd.ExecuteScalar();
            //CloseConnection();
            SqlTransaction transaction = null;
            OpenConnection();
            transaction = _Con.BeginTransaction();
            _Cmd = new SqlCommand();
            _Cmd.Connection = _Con;
            _Cmd.Transaction = transaction;
            _Cmd.CommandText = queryString;
            _Cmd.ExecuteScalar();
            transaction.Commit();
        }
        public int Insert(string tblName, string[] ColNames, object[] valuesList)
        {
            SqlTransaction transaction = null;
            int insertedId = 0;
            try
            {
                #region Prepare String...

                string _sql = "INSERT INTO " + tblName;
                _sql += "(";
                for (int i = 1; i < ColNames.Length - 1; i++)
                {
                    _sql += ColNames[i] + ",";
                }
                _sql += ColNames[ColNames.Length - 1];
                _sql += ") OUTPUT INSERTED.ID VALUES(";
                //_sql += ") VALUES(";
                for (int i = 1; i < valuesList.Length - 1; i++)
                {
                    _sql += "@" + ColNames[i] + ",";
                }
                _sql += "@" + ColNames[ColNames.Length - 1] + ")";

                #endregion

                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;
                _Cmd.CommandText = _sql;

                for (int i = 1; i < ColNames.Length; i++)
                {
                    if (valuesList[i] == null) 
                    {
                        _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else if (valuesList[i].GetType() == "".GetType())
                    {
                        _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                    }
                    else
                    {
                        _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                    }

                }
                object obj = _Cmd.ExecuteScalar();
                transaction.Commit();
                insertedId = (int)obj;

            }
            catch (Exception ex)
            {
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                    MessageBox.Show("Insert Error:" + ex.ToString());
                }
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return insertedId;
        }

        public int InsertNotIncludeOutPut(string tblName, string[] ColNames, object[] valuesList)
        {
            SqlTransaction transaction = null;
            int insertedId = 0;
            try
            {
                #region Prepare String...

                string _sql = "INSERT INTO " + tblName;
                _sql += "(";
                for (int i = 1; i < ColNames.Length - 1; i++)
                {
                    _sql += ColNames[i] + ",";
                }
                _sql += ColNames[ColNames.Length - 1];
                //_sql += ") OUTPUT INSERTED.ID VALUES(";
                _sql += ") VALUES(";
                for (int i = 1; i < valuesList.Length - 1; i++)
                {
                    _sql += "@" + ColNames[i] + ",";
                }
                _sql += "@" + ColNames[ColNames.Length - 1] + ")";

                #endregion

                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;
                _Cmd.CommandText = _sql;

                for (int i = 1; i < ColNames.Length; i++)
                {
                    if (valuesList[i].GetType() == "".GetType())
                        _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                    else
                        _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];

                }
                object obj = _Cmd.ExecuteScalar();
                transaction.Commit();
                insertedId = (int)obj;

            }
            catch (SqlException ex)
            {
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                    MessageBox.Show("Insert Error:" + ex.ToString());
                }
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return insertedId;
        }

        public int InsertWithImage(string tblName, string[] ColNames, object[] valuesList, byte[] img)
        {
            SqlTransaction transaction = null;
            int insertedId = 0;
            try
            {
                #region Prepare String...

                string _sql = "INSERT INTO " + tblName;
                _sql += "(";
                for (int i = 1; i < ColNames.Length - 1; i++)
                {
                    _sql += ColNames[i] + ",";
                }
                _sql += ColNames[ColNames.Length - 1];
                _sql += ") OUTPUT INSERTED.ID VALUES(";
                for (int i = 1; i < valuesList.Length - 1; i++)
                {
                    _sql += "@" + ColNames[i] + ",";
                }
                _sql += "@" + ColNames[ColNames.Length - 1] + ")";

                #endregion

                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;
                _Cmd.CommandText = _sql;

                for (int i = 1; i < ColNames.Length; i++)
                {
                    if (i == ColNames.Length - 1)
                    {
                        _Cmd.Parameters.Add("@" + ColNames[i], SqlDbType.Image).Value = img;
                    }
                    else
                    {
                        if (valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                        else
                            _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                    }
                }
                insertedId = (int)_Cmd.ExecuteScalar();
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                    MessageBox.Show("Insert Error:" + ex.ToString());
                }
                throw ex;
            }
            finally { CloseConnection(); }

            return insertedId;
        }

        public int Update(string tblName, string Id, string[] ColNames, object[] valuesList)
        {
            SqlTransaction transaction = null;
            int _effectedRow = 0;
            try
            {
                #region Prepare String...

                string _sql = "UPDATE " + tblName;
                _sql += " SET ";
                for (int i = 1; i < ColNames.Length - 1; i++)
                {
                    _sql += ColNames[i] + "=" + "@" + ColNames[i] + ", ";
                }
                _sql += ColNames[ColNames.Length - 1] + "=" + "@" + ColNames[ColNames.Length - 1] + " WHERE ID=" + Id;

                #endregion
                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;
                _Cmd.CommandText = _sql;

                for (int i = 1; i < ColNames.Length; i++)
                {
                    if (valuesList[i].GetType() == "".GetType())
                        _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                    else _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                }
                _effectedRow = _Cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                    MessageBox.Show("Insert Error:" + ex.ToString());
                }
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return _effectedRow;
        }

        public int UpdateWithImage(string tblName, string Id, string[] ColNames, object[] valuesList, byte[] img)
        {
            int _effectedRow = 0;
            SqlTransaction transaction = null;
            try
            {
                #region Prepare String...

                string _sql = "UPDATE " + tblName;
                _sql += " SET ";
                for (int i = 1; i < ColNames.Length - 1; i++)
                {
                    _sql += ColNames[i] + "=" + "@" + ColNames[i] + ", ";
                }
                _sql += ColNames[ColNames.Length - 1] + "=" + "@" + ColNames[ColNames.Length - 1] + " WHERE ID=" + Id;

                #endregion
                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;
                _Cmd.CommandText = _sql;

                for (int i = 1; i < ColNames.Length; i++)
                {
                    if (i == ColNames.Length - 1)
                    {
                        _Cmd.Parameters.Add("@" + ColNames[i], SqlDbType.Image).Value = img;
                    }
                    else
                    {
                        if (valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                        else _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                    }
                }
                _effectedRow = _Cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                    MessageBox.Show("Insert Error:" + ex.ToString());
                }

            }
            finally
            {
                CloseConnection();
            }
            return _effectedRow;
        }

        public int UpdateByConditon(string tblName, string condition, string[] ColNames, object[] valuesList)
        {
            SqlTransaction transaction = null;
            int _effectedRow = 0;
            try
            {
                #region Prepare String...

                string _sql = "UPDATE " + tblName;
                _sql += " SET ";
                for (int i = 1; i < ColNames.Length - 1; i++)
                {
                    _sql += ColNames[i] + "=" + "@" + ColNames[i] + ", ";
                }
                _sql += ColNames[ColNames.Length - 1] + "=" + "@" + ColNames[ColNames.Length - 1] + " WHERE " + condition;

                #endregion

                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;
                _Cmd.CommandText = _sql;

                for (int i = 1; i < ColNames.Length; i++)
                {
                    if (valuesList[i].GetType() == "".GetType())
                        _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                    else _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                }
                _effectedRow = _Cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                    MessageBox.Show("Insert Error:" + ex.ToString());
                }
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return _effectedRow;
        }

        public int Truncate(string tblName)
        {
            SqlTransaction transaction = null;
            int _effectedRow = 0;
            try
            {
                #region Prepare String..
                string _sql = String.Format("TRUNCATE TABLE {0}", tblName);
                #endregion
                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;
                _Cmd.CommandText = _sql;

                _effectedRow = _Cmd.ExecuteNonQuery();

                transaction.Commit();

            }
            catch (SqlException ex)
            {
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                    MessageBox.Show("Insert Error:" + ex.ToString());
                }
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return _effectedRow;
        }

        public int Delete(string tblName, string ID)
        {
            SqlTransaction transaction = null;
            int _effectedRow = 0;
            try
            {

                #region Prepare String..
                string _sql = String.Format("DELETE FROM {0} WHERE ID={1}", tblName, ID);
                #endregion
                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;
                _Cmd.CommandText = _sql;

                _effectedRow = _Cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                    MessageBox.Show("Insert Error:" + ex.ToString());
                }
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return _effectedRow;
        }

        public int DeleteByCondition(string tblName, string condition)
        {
            int _effectedRow = 0;
            try
            {

                #region Prepare String..
                string _sql = String.Format("DELETE FROM {0} WHERE {1}", tblName, condition);
                #endregion
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                _effectedRow = _Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return _effectedRow;
        }

        public int DeleteByAll(string tblName)
        {
            int _effectedRow = 0;
            try
            {

                #region Prepare String..
                string _sql = String.Format("DELETE FROM {0} ", tblName);
                #endregion
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                _effectedRow = _Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            } return _effectedRow;
        }

        public DataTable Select(string tblName, string condition)
        {
            DataTable _ResTable = new DataTable();
            try
            {
                string _sql = String.Format("SELECT * FROM {0} WHERE {1}", tblName, condition);
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return _ResTable;
        }
        #endregion
        //Su Wut Yee Naing(16.7.2015)
        #region For Paging
        public DataTable SelectTopRows(string tblName, double count, int start)
        {
            DataTable _ResTable = new DataTable();
            try
            {
                // string _sql = String.Format("SELECT TOP {0} * FROM {1} WHERE ID NOT IN (SELECT TOP {2} ID FROM {1}) order by Id", count, tblName, start);

                string _sql = String.Format("SELECT * FROM (SELECT ROW_NUMBER() OVER ( ORDER BY Id ) AS RowNum, * FROM {0}) AS RowConstrainedResult WHERE RowNum >= {2} AND RowNum <= {1} ORDER BY RowNum", tblName, start, count);

                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return _ResTable;
        }

        public DataTable SelectTopRowsFinal(string tblName, int start, int end)
        {
            DataTable _ResTable = new DataTable();
            try
            {
                string _sql = String.Format("SELECT * FROM (SELECT ROW_NUMBER() OVER ( ORDER BY Id desc) AS RowNum, * FROM {0}) AS RowConstrainedResult WHERE RowNum >= {1} AND RowNum <= {2} ORDER BY RowNum", tblName, start, end);

                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return _ResTable;
        }
        //Su Wut Yee Naing(29.7.2015)
        #region For Paging
        //public DataTable SelectTopRowsByCondition(string tblName, double count, int start,string condition)
        //{
        //    DataTable _ResTable = new DataTable();
        //    try
        //    {
        //        string _sql = String.Format("SELECT TOP {0} ROW_NUMBER() OVER ( ORDER BY Id desc) AS RowNum,* FROM {1} WHERE ID NOT IN (SELECT TOP {2} ID FROM {1} WHERE {3}) AND {3}", count, tblName, start, condition);
        //        OpenConnection();
        //        _Cmd = new SqlCommand(_sql, _Con);
        //        _Adp = new SqlDataAdapter(_Cmd);
        //        _Adp.Fill(_ResTable);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        CloseConnection();
        //    }
        //    return _ResTable;
        //}

        public DataTable SelectTopRowByCondition(string tblName, string condition, double count, int start)
        {
            DataTable _ResTable = new DataTable();
            try
            {
                string _sql = String.Format("SELECT TOP {0} (ROW_NUMBER() OVER ( ORDER BY Id desc)+{2}) AS RowNum,* FROM {1} WHERE ID NOT IN (SELECT TOP {2} ID FROM {1} WHERE {3}  order by ID desc) and {3}", count, tblName, start, condition);
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return _ResTable;
        }
        #endregion

        public DataTable SelectAll(string tblName)
        {
            DataTable _ResTable = new DataTable();
            try
            {
                string _sql = "SELECT * FROM " + tblName;
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            } return _ResTable;
        }
        #endregion

        #region SelectMaxID
        public int SelectMaxID(string tblName)
        {
            int Id = 0;
            try
            {
                DataTable _ResTable = new DataTable();
                #region Prepare String
                string _sql = "SELECT MAX(ID) AS ID FROM " + tblName;
                #endregion
                OpenConnection();

                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
                if (_ResTable.Rows.Count > 0)
                    Id = int.Parse(_ResTable.Rows[0][0].ToString());

            }
            catch (Exception ex)
            {
                return Id;
            }
            finally
            {
                CloseConnection();
            }
            return Id;
        }

        public string SelectMaxValueID(string tblName, String SetColumnField)
        {
            string value = "";
            try
            {
                DataTable _ResTable = new DataTable();
                #region Prepare String
                string _sql = "SELECT " + SetColumnField + " AS ID FROM " + tblName;
                #endregion
                OpenConnection();

                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
                if (_ResTable.Rows.Count > 0)
                    value = _ResTable.Rows[0][0].ToString();

            }
            catch (Exception ex)
            {
                return value;
            }
            finally
            {
                CloseConnection();
            }
            return value;
        }

        public string SelectMaxIDByCondition(string tblName, string condition)
        {
            string value = "";
            try
            {
                OpenConnection();
                DataTable _ResTable = new DataTable();
                string _sql = "SELECT MAX(ID) AS ID FROM " + tblName + " WHERE " + condition;
                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
                if (_ResTable.Rows.Count > 0)
                {
                    value = _ResTable.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return value;
        }
        #endregion

        #region isExist
        public bool CheckRec(string tblName, string key)
        {
            bool flg = false;
            string _sql = String.Format("SELECT * FROM {0} WHERE ID={1}", tblName, key);
            OpenConnection();
            try
            {
                DataTable _resTable = new DataTable();
                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                Adp.Fill(_resTable);
                if (_resTable.Rows.Count > 0)
                    flg = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

            return flg;
        }
        public bool isExist(string tblName, string condition)
        {
            bool exist = false;
            try
            {
                DataTable dt = Select(tblName, condition);
                if (dt.Rows.Count > 0)
                    exist = true;
                return exist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region getImageById

        public byte[] getImageById(string tblName, String getValueImage, string id)
        {
            byte[] b = null;
            try
            {
                OpenConnection();
                string _sql = "SELECT " + getValueImage + " FROM " + tblName + " WHERE ID=" + id;
                _Cmd = new SqlCommand(_sql, _Con);
                b = (byte[])_Cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return b;
        }

        #endregion

        #region GetColumn
        public DataTable getColumn(string tblName, string columns, string condition)
        {
            DataTable dt = new DataTable();

            try
            {
                OpenConnection();
                string _sql = null;
                if (condition != "")
                    _sql = "SELECT " + columns + " FROM " + tblName + " WHERE " + condition + "";
                else _sql = "SELECT " + columns + " FROM " + tblName;
                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(dt);
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        #endregion

        #region UpdateQuery
        public void UpdateQuery(string tblName, string query)
        {
            SqlTransaction transaction = null;
            string _sql = String.Format("UPDATE {0} SET {1}", tblName, query);
            OpenConnection();

            try
            {
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;
                _Cmd.CommandText = _sql;

                _Cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                    MessageBox.Show("Insert Error:" + ex.ToString());
                }
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region SelectByCondition
        public DataTable SelectByCondition(string tblName, List<string> colName, List<object> valuesList, string extraCondition)
        {
            DataTable _ResTable = new DataTable();
            try
            {
                string _sql = String.Format("SELECT * FROM {0} WHERE ", tblName);
                _sql += extraCondition;
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                for (int i = 0; i < colName.Count; i++)
                {
                    if (valuesList[i].GetType() == "".GetType())
                        _Cmd.Parameters.Add(colName[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                    else _Cmd.Parameters.Add("@" + colName[i], GetDbType(valuesList[i])).Value = valuesList[i];
                }
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
            }
            catch (Exception ex) 
            {
                throw ex; 
            }
            finally
            {
                CloseConnection();
            }
            return _ResTable;
        }
        #endregion

        #region SelectByQuery
        public DataTable SelectByQuery(string query)
        {
            DataTable _ResTable = new DataTable();
            string _sql = query;
            try
            {
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return _ResTable;
        }
        #endregion

        #region InsertQuery

        public int InsertQuery(string query)
        {
            int insertedID = 0;
            SqlTransaction transaction = null;
            try
            {
                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;
                _Cmd.CommandText = query;
                insertedID = (int)_Cmd.ExecuteScalar();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();

                    MessageBox.Show("Insert Error:" + ex.ToString());
                }

            }
            finally
            {
                CloseConnection();
            }
            return insertedID;
        }

        #endregion

        #region execute ....

        public void Execute_SP(string tblName, string condition)
        {
            try
            {
                OpenConnection();
                string query = "execute " + tblName + " " + condition;
                _Cmd = new SqlCommand(query, _Con);
                _Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        #endregion

        #region ReplaceQuery Value
        public string ReplaceQueryValue(string value)
        {
            return value.Replace("'", "'");
        }

        #endregion


        #region DeleteList with Transaction

        public void ListwithTransaction(List<String> queryList)
        {
            SqlTransaction transaction = null;
            
            try
            {
                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;

                foreach (String query in queryList)
                {
                    _Cmd.CommandText = query;
                    _Cmd.ExecuteScalar();
                }
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                #region ...
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                }
                throw ex;
                #endregion
            }
            finally { CloseConnection(); }
        }

        #endregion

        #region Create Info Detail
        public int CreateInfo_Detail(string tblInfoName, string tblDetailName, object infoVo, List<object> detailVoList, List<String> queryList, List<string> deleteList)
        {
            SqlTransaction transaction = null;
            int InsertedID = 0;
            try
            {
                String[] ColNames = ConvertColName(infoVo);
                object[] valuesList = ConvertValueList(infoVo);

                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;

                #region Delete List
                foreach (String Query in deleteList)
                {
                    _Cmd.CommandText = Query;
                    _Cmd.ExecuteScalar();
                }
                #endregion

                #region Prepare String...

                string _sql = "INSERT INTO " + tblInfoName + "";
                _sql += "(";
                for (int i = 1; i < ColNames.Length - 1; i++)
                {
                    _sql += ColNames[i] + ",";
                }
                _sql += ColNames[ColNames.Length - 1];
                _sql += ") OUTPUT INSERTED.ID VALUES(";
                for (int i = 1; i < valuesList.Length - 1; i++)
                {
                    _sql += "@" + ColNames[i] + ",";
                }
                _sql += "@" + ColNames[ColNames.Length - 1] + ")";
                #endregion

                #region For Insert Info
                _Cmd.CommandText = _sql;
                for (int i = 1; i < ColNames.Length; i++)
                {
                    if (valuesList[i].GetType() == "".GetType())
                        _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                    else
                        _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                }

                InsertedID = (int)_Cmd.ExecuteScalar();
                _Cmd.Parameters.Clear();
                #endregion

                #region For Insert Detail
                foreach (object detailVo in detailVoList)
                {
                    #region Prepare String...
                    int detailInsertedID = 0;
                    String[] Detail_ColNames = ConvertColName(detailVo);
                    object[] Detail_valuesList = ConvertValueList(detailVo);
                    _sql = "INSERT INTO " + tblDetailName + " ";
                    _sql += "(";
                    for (int i = 1; i < Detail_ColNames.Length - 1; i++)
                    {
                        _sql += Detail_ColNames[i] + ",";
                    }
                    _sql += Detail_ColNames[Detail_ColNames.Length - 1];
                    _sql += ") OUTPUT INSERTED.ID VALUES(";

                    for (int i = 1; i < Detail_valuesList.Length - 1; i++)
                    {
                        if (tblDetailName == "Used_Leave")
                        {
                            _sql += "@" + Detail_ColNames[i] + ",";
                        }
                        else
                        {
                            if (i == 1)
                            {
                                _sql += InsertedID + ",";
                            }
                            else
                                _sql += "@" + Detail_ColNames[i] + ",";
                        }
                    }
                    if (tblDetailName == "Used_Leave")
                    {
                        _sql += InsertedID + ")";
                    }
                    else
                    {
                        _sql += "@" + Detail_ColNames[Detail_ColNames.Length - 1] + ")";
                    }
                    #endregion

                    _Cmd.CommandText = _sql;
                    for (int i = 1; i < Detail_ColNames.Length; i++)
                    {
                        if (Detail_valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(Detail_ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(Detail_valuesList[i].ToString()));
                        else
                            _Cmd.Parameters.Add("@" + Detail_ColNames[i], GetDbType(Detail_valuesList[i])).Value = Detail_valuesList[i];
                    }
                    detailInsertedID = (int)_Cmd.ExecuteScalar();
                    _Cmd.Parameters.Clear();
                }

                #endregion

                #region QueryList

                foreach (String query in queryList)
                {
                    if (tblDetailName == "Used_Leave")
                    {
                        _Cmd.CommandText = query + InsertedID;
                    }
                    else
                        _Cmd.CommandText = query;
                    _Cmd.ExecuteScalar();
                }

                #endregion
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                #region ...
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                }
                throw ex;
                #endregion
            }
            finally { CloseConnection(); }

            return InsertedID;
        }
        #endregion

        #region Create Object List

        public int Create_Object_List(string tblName, List<Object> objList, List<String> queryList, List<String> deleteList)
        {
            SqlTransaction transaction = null;
            int InsertedID = 0;
            try
            {
                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;
                #region For Insert Detail
                foreach (object detailVo in objList)
                {
                    #region Prepare String...
                    int detailInsertedID = 0;
                    String[] Detail_ColNames = ConvertColName(detailVo);
                    object[] Detail_valuesList = ConvertValueList(detailVo);
                    string _sql = "INSERT INTO " + tblName + " ";
                    _sql += "(";
                    for (int i = 1; i < Detail_ColNames.Length - 1; i++)
                    {
                        _sql += Detail_ColNames[i] + ",";
                    }
                    _sql += Detail_ColNames[Detail_ColNames.Length - 1];
                    _sql += ") OUTPUT INSERTED.ID VALUES(";

                    for (int i = 1; i < Detail_valuesList.Length - 1; i++)
                    {
                        _sql += "@" + Detail_ColNames[i] + ",";
                    }

                    _sql += "@" + Detail_ColNames[Detail_ColNames.Length - 1] + ")";

                    #endregion

                    _Cmd.CommandText = _sql;
                    for (int i = 1; i < Detail_ColNames.Length; i++)
                    {
                        if (Detail_valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(Detail_ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(Detail_valuesList[i].ToString()));
                        else
                            _Cmd.Parameters.Add("@" + Detail_ColNames[i], GetDbType(Detail_valuesList[i])).Value = Detail_valuesList[i];
                    }
                    detailInsertedID = (int)_Cmd.ExecuteScalar();
                    _Cmd.Parameters.Clear();
                }

                #endregion
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                #region ...
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                }
                throw ex;
                #endregion
            }
            finally
            {
                CloseConnection();
            }
            return InsertedID;
        }

        #endregion

        #region Update Info Detail
        public int UpdateInfo_Detail(string tblInfoName, string tblDetailName, int infoId, object infoVo, List<object> detailVoList, List<String> queryList, List<string> deleteList)
        {
            int _UpdateInfoID = 0;
            SqlTransaction transaction = null;
            String[] ColNames = ConvertColName(infoVo);
            object[] valuesList = ConvertValueList(infoVo);
            try
            {
                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;
                #region Delete List
                foreach (String Query in deleteList)
                {
                    _Cmd.CommandText = Query;
                    _Cmd.ExecuteScalar();
                }
                #endregion

                #region Preparing String for update ...

                string _sql = "UPDATE " + tblInfoName + "";
                _sql += " SET ";
                for (int i = 1; i < ColNames.Length - 1; i++)
                {
                    _sql += ColNames[i] + "=" + "@" + ColNames[i] + ", ";
                }
                _sql += ColNames[ColNames.Length - 1] + "=" + "@" + ColNames[ColNames.Length - 1] + " WHERE ID=" + infoId;

                #endregion
                #region Info Save
                _Cmd.CommandText = _sql;
                for (int i = 1; i < ColNames.Length; i++)
                {
                    if (valuesList[i].GetType() == "".GetType())
                        _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                    else _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                }
                _UpdateInfoID = _Cmd.ExecuteNonQuery();
                _Cmd.Parameters.Clear();
                #endregion
                #region For Insert Detail
                foreach (object detailVo in detailVoList)
                {
                    #region Prepare String...
                    int detailInserdedID = 0;
                    String[] Detail_ColNames = ConvertColName(detailVo);
                    object[] Detail_valuesList = ConvertValueList(detailVo);

                    int detailId = (Detail_valuesList[0] == null ? 0 : int.Parse(Detail_valuesList[0].ToString()));

                    if (detailId != 0)
                    {
                        _sql = "UPDATE " + tblDetailName + "";
                        _sql += " SET ";
                        for (int i = 1; i < Detail_ColNames.Length - 1; i++)
                        {

                            _sql += Detail_ColNames[i] + "=" + "@" + Detail_ColNames[i] + ", ";
                        }
                        _sql += Detail_ColNames[Detail_ColNames.Length - 1] + "=" + "@" + Detail_ColNames[Detail_ColNames.Length - 1] + " WHERE ID=" + detailId;
                        _Cmd.CommandText = _sql;
                        for (int i = 1; i < Detail_ColNames.Length; i++)
                        {
                            if (Detail_valuesList[i].GetType() == "".GetType())
                                _Cmd.Parameters.Add(Detail_ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(Detail_valuesList[i].ToString()));
                            else _Cmd.Parameters.Add("@" + Detail_ColNames[i], GetDbType(Detail_valuesList[i])).Value = Detail_valuesList[i];
                        }
                        detailInserdedID = _Cmd.ExecuteNonQuery();
                        _Cmd.Parameters.Clear();
                    #endregion
                    }
                    else
                    {
                        _sql = "INSERT INTO " + tblDetailName + " ";
                        _sql += "(";
                        for (int i = 1; i < Detail_ColNames.Length - 1; i++)
                        {
                            _sql += Detail_ColNames[i] + ",";
                        }
                        _sql += Detail_ColNames[Detail_ColNames.Length - 1];
                        _sql += ") OUTPUT INSERTED.ID VALUES(";
                        for (int i = 1; i < Detail_valuesList.Length - 1; i++)
                        {
                            if (tblDetailName == "Used_Leave")
                            {
                                _sql += "@" + Detail_ColNames[i] + ",";
                            }
                            else
                            {
                                if (i == 1)
                                {
                                    _sql += infoId + ",";
                                }
                                else
                                    _sql += "@" + Detail_ColNames[i] + ",";
                            }
                        }
                        if (tblDetailName == "Used_Leave")
                        {
                            _sql += infoId + ")";
                        }
                        else
                        {
                            _sql += "@" + Detail_ColNames[Detail_ColNames.Length - 1] + ")";
                        }
                        _Cmd.CommandText = _sql;

                        for (int i = 1; i < Detail_ColNames.Length; i++)
                        {
                            if (Detail_valuesList[i].GetType() == "".GetType())
                                _Cmd.Parameters.Add(Detail_ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(Detail_valuesList[i].ToString()));
                            else _Cmd.Parameters.Add("@" + Detail_ColNames[i], GetDbType(Detail_valuesList[i])).Value = Detail_valuesList[i];
                        }
                        detailInserdedID = (int)_Cmd.ExecuteScalar();
                        _Cmd.Parameters.Clear();
                    }
                }

                #endregion
                #region QueryList

                foreach (String query in queryList)
                {
                    if (tblDetailName == "Used_Leave")
                    {
                        _Cmd.CommandText = query + infoId;
                    }
                    else _Cmd.CommandText = query;
                    _Cmd.ExecuteScalar();
                }
                #endregion
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                }
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

            return infoId;
        }
        #endregion

        #region Transaction Query List
        public void Transaction_QueryList(List<String> queryList)
        {
            SqlTransaction transaction = null;
            try
            {
                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;

                #region Query List
                foreach (String Query in queryList)
                {
                    _Cmd.CommandText = Query;
                    _Cmd.ExecuteScalar();
                }
                #endregion
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                #region ...
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                }
                throw ex;
                #endregion
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion #region Create/Update Info Detail

        #region  Create Two Table
        //public int Create_Create(string tblName, int infoId, string[] ColNames, object[] valuesList, string tblDetailName, string[] Detail_ColNames, object[] Detail_valuesList, int manualId)
        //{
        //    //  int detailInserdedID = 0;
        //    int insertedId = 0;
        //    SqlTransaction transaction = null;
        //    string _sql = null;
        //    try
        //    {
        //        OpenConnection();
        //        transaction = _Con.BeginTransaction();
        //        _Cmd = new SqlCommand();
        //        _Cmd.Connection = _Con;
        //        _Cmd.Transaction = transaction;

        //        #region Attendance Create
        //        if (infoId == 0)
        //        {
        //            #region Prepare String...

        //            _sql = "INSERT INTO " + tblName;
        //            _sql += "(";
        //            for (int i = 1; i < ColNames.Length - 1; i++)
        //            {
        //                _sql += ColNames[i] + ",";
        //            }
        //            _sql += ColNames[ColNames.Length - 1];
        //            _sql += ")OUTPUT INSERTED.ID VALUES(";
        //            for (int i = 1; i < valuesList.Length - 1; i++)
        //            {
        //                _sql += "@" + ColNames[i] + ",";
        //            }
        //            _sql += "@" + ColNames[ColNames.Length - 1] + ")";

        //            #endregion

        //            _Cmd.CommandText = _sql;

        //            for (int i = 1; i < ColNames.Length; i++)
        //            {
        //                if (valuesList[i].GetType() == "".GetType())
        //                    _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
        //                else
        //                    _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
        //            }
        //            insertedId = (int)_Cmd.ExecuteScalar();
        //            _Cmd.Parameters.Clear();
        //        }
        //        else
        //        {
        //            #region Preparing String for update ...

        //            _sql = "UPDATE " + tblName + "";
        //            _sql += " SET ";
        //            for (int i = 1; i < ColNames.Length - 1; i++)
        //            {
        //                _sql += ColNames[i] + "=" + "@" + ColNames[i] + ", ";
        //            }
        //            _sql += ColNames[ColNames.Length - 1] + "=" + "@" + ColNames[ColNames.Length - 1] + " WHERE ID=" + infoId;

        //            #endregion
        //            #region Info Save
        //            _Cmd.CommandText = _sql;
        //            for (int i = 1; i < ColNames.Length; i++)
        //            {
        //                if (valuesList[i].GetType() == "".GetType())
        //                    _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
        //                else _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
        //            }
        //            int _UpdateInfoID = _Cmd.ExecuteNonQuery();
        //            _Cmd.Parameters.Clear();
        //            insertedId = infoId;
        //            #endregion
        //        }

        //        #endregion

        //        #region Manual Create
        //        if (manualId == 0)
        //        {
        //            _sql = "INSERT INTO " + tblDetailName;
        //            _sql += "(";
        //            for (int i = 1; i < Detail_ColNames.Length - 1; i++)
        //            {
        //                _sql += Detail_ColNames[i] + ",";
        //            }
        //            _sql += Detail_ColNames[Detail_ColNames.Length - 1];
        //            _sql += ")OUTPUT INSERTED.ID VALUES(";
        //            for (int i = 1; i < Detail_valuesList.Length - 1; i++)
        //            {
        //                if (i == 1)
        //                {
        //                    _sql += insertedId + ",";
        //                }
        //                else
        //                {
        //                    _sql += "@" + Detail_ColNames[i] + ",";
        //                }
        //            }
        //            _sql += "@" + Detail_ColNames[Detail_ColNames.Length - 1] + ")";

        //            _Cmd.CommandText = _sql;

        //            for (int i = 1; i < Detail_ColNames.Length; i++)
        //            {
        //                if (Detail_valuesList[i].GetType() == "".GetType())
        //                    _Cmd.Parameters.Add(Detail_ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(Detail_valuesList[i].ToString()));
        //                else
        //                    _Cmd.Parameters.Add("@" + Detail_ColNames[i], GetDbType(Detail_valuesList[i])).Value = Detail_valuesList[i];

        //            }

        //            _Cmd.ExecuteNonQuery();

        //        }
        //        else // This is for Edit Manual Setting
        //        {
        //            _sql = "UPDATE " + tblDetailName + "";
        //            _sql += " SET ";
        //            for (int i = 1; i < Detail_ColNames.Length - 1; i++)
        //            {
        //                _sql += Detail_ColNames[i] + "=" + "@" + Detail_ColNames[i] + ", ";
        //            }
        //            _sql += Detail_ColNames[Detail_ColNames.Length - 1] + "=" + "@" + Detail_ColNames[Detail_ColNames.Length - 1] + " WHERE ID=" + manualId;


        //            #region Info Save
        //            _Cmd.CommandText = _sql;
        //            for (int i = 1; i < Detail_ColNames.Length; i++)
        //            {
        //                if (Detail_valuesList[i].GetType() == "".GetType())
        //                    _Cmd.Parameters.Add(Detail_ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(Detail_valuesList[i].ToString()));
        //                else _Cmd.Parameters.Add("@" + Detail_ColNames[i], GetDbType(Detail_valuesList[i])).Value = Detail_valuesList[i];
        //            }
        //            int _UpdateInfoID = _Cmd.ExecuteNonQuery();
        //            _Cmd.Parameters.Clear();
        //            #endregion
        //        }

        //        #endregion
        //        transaction.Commit();
        //    }
        //    catch (SqlException ex)
        //    {
        //        if (_Con.State == ConnectionState.Open)
        //        {
        //            transaction.Rollback();
        //            transaction.Dispose();
        //            _Cmd.Dispose();
        //            MessageBox.Show("Insert Error:" + ex.ToString());
        //        }
        //    }
        //    finally
        //    {
        //        CloseConnection();
        //    }
        //    return insertedId;
        //}

        #endregion

        #region  Create three Table
        public int Create_Attendance_Manual_History(string tblName, int infoId, string[] ColNames, object[] valuesList, string tblDetailName, string[] Detail_ColNames, object[] Detail_valuesList, int manualId, string[] thirdColNames, object[] thirdValuesList)
        {
            //  int detailInserdedID = 0;
            int insertedId = 0;
            SqlTransaction transaction = null;
            string _sql = null;
            int insertedManualId = 0;
            try
            {
                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;

                #region Attendance Create
                if (infoId == 0)
                {
                    #region Prepare String...

                    _sql = "INSERT INTO " + tblName;
                    _sql += "(";
                    for (int i = 1; i < ColNames.Length - 1; i++)
                    {
                        _sql += ColNames[i] + ",";
                    }
                    _sql += ColNames[ColNames.Length - 1];
                    _sql += ")OUTPUT INSERTED.ID VALUES(";
                    for (int i = 1; i < valuesList.Length - 1; i++)
                    {
                        _sql += "@" + ColNames[i] + ",";
                    }
                    _sql += "@" + ColNames[ColNames.Length - 1] + ")";

                    #endregion

                    _Cmd.CommandText = _sql;

                    for (int i = 1; i < ColNames.Length; i++)
                    {
                        if(valuesList[i] ==null)
                            _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = DBNull.Value;
                        else if (valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                        else
                            _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                    }
                    insertedId = (int)_Cmd.ExecuteScalar();
                    _Cmd.Parameters.Clear();
                }
                else
                {
                    #region Preparing String for update ...

                    _sql = "UPDATE " + tblName + "";
                    _sql += " SET ";
                    for (int i = 1; i < ColNames.Length - 1; i++)
                    {
                        _sql += ColNames[i] + "=" + "@" + ColNames[i] + ", ";
                    }
                    _sql += ColNames[ColNames.Length - 1] + "=" + "@" + ColNames[ColNames.Length - 1] + " WHERE ID=" + infoId;

                    #endregion
                    #region Info Save
                    _Cmd.CommandText = _sql;
                    for (int i = 1; i < ColNames.Length; i++)
                    {
                        if (valuesList[i] == null)
                        {
                            _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = DBNull.Value;
                        }
                        else if (valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                        else _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                    }
                    int _UpdateInfoID = _Cmd.ExecuteNonQuery();
                    _Cmd.Parameters.Clear();
                    insertedId = infoId;
                    #endregion
                }

                #endregion

                #region Manual Create
                if (manualId == 0)
                {
                    _sql = "INSERT INTO " + tblDetailName;
                    _sql += "(";
                    for (int i = 1; i < Detail_ColNames.Length - 1; i++)
                    {
                        _sql += Detail_ColNames[i] + ",";
                    }
                    _sql += Detail_ColNames[Detail_ColNames.Length - 1];
                    _sql += ")OUTPUT INSERTED.ID VALUES(";
                    for (int i = 1; i < Detail_valuesList.Length - 1; i++)
                    {
                        if (i == 1)
                        {
                            _sql += insertedId + ",";
                        }
                        else
                        {
                            _sql += "@" + Detail_ColNames[i] + ",";
                        }
                    }
                    _sql += "@" + Detail_ColNames[Detail_ColNames.Length - 1] + ")";

                    _Cmd.CommandText = _sql;

                    for (int i = 1; i < Detail_ColNames.Length; i++)
                    {
                        if (Detail_valuesList[i]== null)
                            _Cmd.Parameters.Add(Detail_ColNames[i], SqlDbType.NVarChar).Value = DBNull.Value;
                        else if (Detail_valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(Detail_ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(Detail_valuesList[i].ToString()));
                        else
                            _Cmd.Parameters.Add("@" + Detail_ColNames[i], GetDbType(Detail_valuesList[i])).Value = Detail_valuesList[i];

                    }

                    insertedManualId = (int)_Cmd.ExecuteScalar();
                    _Cmd.Parameters.Clear();

                    #region .. Manual History

                    _sql = "INSERT INTO FP_Manual_History";
                    _sql += "(";
                    for (int i = 1; i < thirdColNames.Length - 1; i++)
                    {
                        _sql += thirdColNames[i] + ",";
                    }
                    _sql += thirdColNames[thirdColNames.Length - 1];
                    _sql += ")OUTPUT INSERTED.ID VALUES(";
                    for (int i = 1; i < thirdValuesList.Length - 1; i++)
                    {
                        if (i == 1)
                        {
                            _sql += insertedManualId + ",";
                        }
                        else
                        {
                            _sql += "@" + thirdColNames[i] + ",";
                        }
                    }
                    _sql += "@" + thirdColNames[thirdColNames.Length - 1] + ")";

                    _Cmd.CommandText = _sql;

                    for (int i = 1; i < thirdColNames.Length; i++)
                    {
                        if (thirdValuesList[i]== null)
                            _Cmd.Parameters.Add(thirdColNames[i], SqlDbType.NVarChar).Value = DBNull.Value;
                        else if (thirdValuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(thirdColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(thirdValuesList[i].ToString()));
                        else
                            _Cmd.Parameters.Add("@" + thirdColNames[i], GetDbType(thirdValuesList[i])).Value = thirdValuesList[i];

                    }

                    insertedManualId = (int)_Cmd.ExecuteScalar();
                    _Cmd.Parameters.Clear();

                    #endregion
                }
                else // This is for Edit Manual Setting
                {
                    _sql = "UPDATE " + tblDetailName + "";
                    _sql += " SET ";
                    for (int i = 1; i < Detail_ColNames.Length - 1; i++)
                    {
                        _sql += Detail_ColNames[i] + "=" + "@" + Detail_ColNames[i] + ", ";
                    }
                    _sql += Detail_ColNames[Detail_ColNames.Length - 1] + "=" + "@" + Detail_ColNames[Detail_ColNames.Length - 1] + " WHERE ID=" + manualId;

                    #region Info Save
                    _Cmd.CommandText = _sql;
                    for (int i = 1; i < Detail_ColNames.Length; i++)
                    {
                        if (Detail_valuesList[i] == null)
                            _Cmd.Parameters.Add(Detail_ColNames[i], SqlDbType.NVarChar).Value = DBNull.Value;
                        else if (Detail_valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(Detail_ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(Detail_valuesList[i].ToString()));
                        else _Cmd.Parameters.Add("@" + Detail_ColNames[i], GetDbType(Detail_valuesList[i])).Value = Detail_valuesList[i];
                    }
                    int _UpdateInfoID = _Cmd.ExecuteNonQuery();
                    _Cmd.Parameters.Clear();
                    #endregion
                }

                #endregion
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                    MessageBox.Show("Insert Error:" + ex.ToString());
                }
            }
            finally
            {
                CloseConnection();
            }
            return insertedId;
        }

        #endregion

        #region Execute_SP_DT
        public DataTable Execute_SP_DT(string tblName, string condition)
        {
            DataTable _ResTable = new DataTable();
            try
            {
                string _sql = "execute " + tblName + " " + condition;
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return _ResTable;
        }

        #endregion

        #region Execute_NonQuery
        public int ExecuteNonQuery(string _sql)
        {
            int effectedRows = 0;
            try
            {
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                effectedRows = _Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return effectedRows;
        }

        #endregion

        #region  Create Two Table are not related
        public int Create_Update_For_SalaryChange(string tblName, int infoId, string[] ColNames, object[] valuesList, string tblDetailName, string[] Detail_ColNames, object[] Detail_valuesList, List<String> queryList)
        {
            int insertedId = 0;
            SqlTransaction transaction = null;
            string _sql = null;
            try
            {
                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;

                #region Query List
                foreach (String Query in queryList)
                {
                    _Cmd.CommandText = Query;
                    _Cmd.ExecuteScalar();
                }
                #endregion

                #region
                if (infoId == 0)
                {
                    #region Prepare String...

                    _sql = "INSERT INTO " + tblName;
                    _sql += "(";
                    for (int i = 1; i < ColNames.Length - 1; i++)
                    {
                        _sql += ColNames[i] + ",";
                    }
                    _sql += ColNames[ColNames.Length - 1];
                    _sql += ")OUTPUT INSERTED.ID VALUES(";
                    for (int i = 1; i < valuesList.Length - 1; i++)
                    {
                        _sql += "@" + ColNames[i] + ",";
                    }
                    _sql += "@" + ColNames[ColNames.Length - 1] + ")";

                    #endregion

                    _Cmd.CommandText = _sql;

                    for (int i = 1; i < ColNames.Length; i++)
                    {
                        if (valuesList[i].GetType() == "".GetType())
                        {
                            if (valuesList[i].ToString() == "")
                            {
                                _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = DBNull.Value;
                            }
                            else
                                _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                        }
                        else
                            _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                    }
                    insertedId = (int)_Cmd.ExecuteScalar();
                    _Cmd.Parameters.Clear();
                }
                else
                {
                    #region Preparing String for update ...

                    _sql = "UPDATE " + tblName + "";
                    _sql += " SET ";
                    for (int i = 1; i < ColNames.Length - 1; i++)
                    {
                        _sql += ColNames[i] + "=" + "@" + ColNames[i] + ", ";
                    }
                    _sql += ColNames[ColNames.Length - 1] + "=" + "@" + ColNames[ColNames.Length - 1] + " WHERE ID=" + infoId;

                    #endregion
                    #region Info Save
                    _Cmd.CommandText = _sql;
                    for (int i = 1; i < ColNames.Length; i++)
                    {
                        if (valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                        else _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                    }
                    int _UpdateInfoID = _Cmd.ExecuteNonQuery();
                    _Cmd.Parameters.Clear();
                    insertedId = infoId;
                    #endregion
                }
                #endregion

                #region update
                if (Detail_valuesList[0].ToString() == "0")
                {
                    _sql = "INSERT INTO " + tblDetailName;
                    _sql += "(";
                    for (int i = 1; i < Detail_ColNames.Length - 1; i++)
                    {
                        _sql += Detail_ColNames[i] + ",";
                    }
                    _sql += Detail_ColNames[Detail_ColNames.Length - 1];
                    _sql += ")OUTPUT INSERTED.ID VALUES(";
                    for (int i = 1; i < Detail_valuesList.Length - 1; i++)
                    {
                        if (i == 1)
                        {
                            _sql += insertedId + ",";
                        }
                        else
                        {
                            _sql += "@" + Detail_ColNames[i] + ",";
                        }
                    }
                    _sql += "@" + Detail_ColNames[Detail_ColNames.Length - 1] + ")";

                    _Cmd.CommandText = _sql;

                    for (int i = 1; i < Detail_ColNames.Length; i++)
                    {
                        if (Detail_valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(Detail_ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(Detail_valuesList[i].ToString()));
                        else
                            _Cmd.Parameters.Add("@" + Detail_ColNames[i], GetDbType(Detail_valuesList[i])).Value = Detail_valuesList[i];

                    }

                    _Cmd.ExecuteNonQuery();
                }
                else
                {
                    _sql = "UPDATE " + tblDetailName + "";
                    _sql += " SET ";
                    for (int i = 1; i < Detail_ColNames.Length - 1; i++)
                    {
                        _sql += Detail_ColNames[i] + "=" + "@" + Detail_ColNames[i] + ", ";
                    }
                    _sql += Detail_ColNames[Detail_ColNames.Length - 1] + "=" + "@" + Detail_ColNames[Detail_ColNames.Length - 1] + " WHERE ID=" + Detail_valuesList[0].ToString();


                    #region Info Save
                    _Cmd.CommandText = _sql;
                    for (int i = 1; i < Detail_ColNames.Length; i++)
                    {
                        if (Detail_valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(Detail_ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(Detail_valuesList[i].ToString()));
                        else _Cmd.Parameters.Add("@" + Detail_ColNames[i], GetDbType(Detail_valuesList[i])).Value = Detail_valuesList[i];
                    }
                    int updatedid = _Cmd.ExecuteNonQuery();
                    _Cmd.Parameters.Clear();
                    #endregion
                }

                #endregion
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                    MessageBox.Show("Insert Error:" + ex.ToString());
                }
            }
            finally
            {
                CloseConnection();
            }
            return insertedId;
        }

        #endregion

        #region  Create Two Table are not related
        public int Create_Update_For_Probation_office_Order(string tblName, int infoId, string[] ColNames, object[] valuesList, string tblDetailName, string[] Detail_ColNames, object[] Detail_valuesList, byte[] img, List<String> queryList)
        {
            int insertedId = 0;
            SqlTransaction transaction = null;
            string _sql = null;
            try
            {
                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;

                #region Query List
                foreach (String Query in queryList)
                {
                    _Cmd.CommandText = Query;
                    _Cmd.ExecuteScalar();
                }
                #endregion

                #region
                if (infoId == 0)
                {
                    #region Prepare String...

                    _sql = "INSERT INTO " + tblName;
                    _sql += "(";
                    for (int i = 1; i < ColNames.Length - 1; i++)
                    {
                        _sql += ColNames[i] + ",";
                    }
                    _sql += ColNames[ColNames.Length - 1];
                    _sql += ")OUTPUT INSERTED.ID VALUES(";
                    for (int i = 1; i < valuesList.Length - 1; i++)
                    {
                        _sql += "@" + ColNames[i] + ",";
                    }
                    _sql += "@" + ColNames[ColNames.Length - 1] + ")";

                    #endregion

                    _Cmd.CommandText = _sql;

                    for (int i = 1; i < ColNames.Length; i++)
                    {
                        if (valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                        else
                            _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                    }
                    insertedId = (int)_Cmd.ExecuteScalar();
                    _Cmd.Parameters.Clear();
                }
                else
                {
                    #region Preparing String for update ...

                    _sql = "UPDATE " + tblName + "";
                    _sql += " SET ";
                    for (int i = 1; i < ColNames.Length - 1; i++)
                    {
                        _sql += ColNames[i] + "=" + "@" + ColNames[i] + ", ";
                    }
                    _sql += ColNames[ColNames.Length - 1] + "=" + "@" + ColNames[ColNames.Length - 1] + " WHERE ID=" + infoId;

                    #endregion
                    #region Info Save
                    _Cmd.CommandText = _sql;
                    for (int i = 1; i < ColNames.Length; i++)
                    {
                        if (valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                        else _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                    }
                    int _UpdateInfoID = _Cmd.ExecuteNonQuery();
                    _Cmd.Parameters.Clear();
                    insertedId = infoId;
                    #endregion
                }

                #endregion

                #region update
                if (Detail_valuesList[0].ToString() == "0")
                {
                    _sql = "INSERT INTO " + tblDetailName;
                    _sql += "(";
                    for (int i = 1; i < Detail_ColNames.Length - 1; i++)
                    {
                        _sql += Detail_ColNames[i] + ",";
                    }
                    _sql += Detail_ColNames[Detail_ColNames.Length - 1];
                    _sql += ")OUTPUT INSERTED.ID VALUES(";
                    for (int i = 1; i < Detail_valuesList.Length - 1; i++)
                    {
                        // no need to insert Info Id to detail Table bcoz info table is not related to detail table
                        _sql += "@" + Detail_ColNames[i] + ",";
                    }
                    _sql += "@" + Detail_ColNames[Detail_ColNames.Length - 1] + ")";

                    _Cmd.CommandText = _sql;

                    for (int i = 1; i < Detail_ColNames.Length; i++)
                    {
                        if (i == Detail_ColNames.Length - 1)
                        {
                            _Cmd.Parameters.Add("@" + Detail_ColNames[i], SqlDbType.Image).Value = img;
                        }
                        else
                        {
                            if (Detail_valuesList[i].GetType() == "".GetType())
                                _Cmd.Parameters.Add(Detail_ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(Detail_valuesList[i].ToString()));
                            else
                                _Cmd.Parameters.Add("@" + Detail_ColNames[i], GetDbType(Detail_valuesList[i])).Value = Detail_valuesList[i];
                        }
                    }

                    _Cmd.ExecuteNonQuery();
                }
                else
                {
                    _sql = "UPDATE " + tblDetailName + "";
                    _sql += " SET ";
                    for (int i = 1; i < Detail_ColNames.Length - 1; i++)
                    {
                        _sql += Detail_ColNames[i] + "=" + "@" + Detail_ColNames[i] + ", ";
                    }
                    _sql += Detail_ColNames[Detail_ColNames.Length - 1] + "=" + "@" + Detail_ColNames[Detail_ColNames.Length - 1] + " WHERE ID=" + Detail_valuesList[0].ToString();


                    #region Info Save
                    _Cmd.CommandText = _sql;
                    for (int i = 1; i < Detail_ColNames.Length; i++)
                    {
                        if (i == Detail_ColNames.Length - 1)
                        {
                            _Cmd.Parameters.Add("@" + Detail_ColNames[i], SqlDbType.Image).Value = img;
                        }
                        else
                        {
                            if (Detail_valuesList[i].GetType() == "".GetType())
                                _Cmd.Parameters.Add(Detail_ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(Detail_valuesList[i].ToString()));
                            else _Cmd.Parameters.Add("@" + Detail_ColNames[i], GetDbType(Detail_valuesList[i])).Value = Detail_valuesList[i];
                        }
                    }
                    int updatedid = _Cmd.ExecuteNonQuery();
                    _Cmd.Parameters.Clear();
                    #endregion
                }

                #endregion
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                    MessageBox.Show("Insert Error:" + ex.ToString());
                }
            }
            finally
            {
                CloseConnection();
            }
            return insertedId;
        }

        #endregion

        #region Create Update Object List
        public int Create_Update_Object_List(string tblName, int Id, string[] ColNames, object[] valuesList, List<String> queryList)
        {
            SqlTransaction transaction = null;
            int InsertedID = 0;
            string _sql = null;
            try
            {
                OpenConnection();
                transaction = _Con.BeginTransaction();
                _Cmd = new SqlCommand();
                _Cmd.Connection = _Con;
                _Cmd.Transaction = transaction;

                #region Query List
                foreach (String Query in queryList)
                {
                    _Cmd.CommandText = Query;
                    _Cmd.ExecuteScalar();
                }
                #endregion

                #region
                if (Id == 0)
                {
                    #region Prepare String...

                    _sql = "INSERT INTO " + tblName;
                    _sql += "(";
                    for (int i = 1; i < ColNames.Length - 1; i++)
                    {
                        _sql += ColNames[i] + ",";
                    }
                    _sql += ColNames[ColNames.Length - 1];
                    _sql += ")OUTPUT INSERTED.ID VALUES(";
                    for (int i = 1; i < valuesList.Length - 1; i++)
                    {
                        _sql += "@" + ColNames[i] + ",";
                    }
                    _sql += "@" + ColNames[ColNames.Length - 1] + ")";

                    #endregion

                    _Cmd.CommandText = _sql;

                    for (int i = 1; i < ColNames.Length; i++)
                    {
                        if (valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                        else
                            _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                    }
                    InsertedID = (int)_Cmd.ExecuteScalar();
                    _Cmd.Parameters.Clear();
                }
                else
                {
                    #region Preparing String for update ...

                    _sql = "UPDATE " + tblName + "";
                    _sql += " SET ";
                    for (int i = 1; i < ColNames.Length - 1; i++)
                    {
                        _sql += ColNames[i] + "=" + "@" + ColNames[i] + ", ";
                    }
                    _sql += ColNames[ColNames.Length - 1] + "=" + "@" + ColNames[ColNames.Length - 1] + " WHERE ID=" + Id;

                    #endregion
                    #region  Save
                    _Cmd.CommandText = _sql;
                    for (int i = 1; i < ColNames.Length; i++)
                    {
                        if (valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                        else _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                    }
                    int _UpdateInfoID = _Cmd.ExecuteNonQuery();
                    _Cmd.Parameters.Clear();
                    InsertedID = Id;
                    #endregion
                }

                #endregion
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                #region ...
                if (_Con.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                    _Cmd.Dispose();
                }
                throw ex;
                #endregion
            }
            finally
            {
                CloseConnection();
            }
            return InsertedID;
        }
        #endregion

    }
}
