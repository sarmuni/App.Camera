﻿//Generated by .NET Class Generator Tools

using System;
using System.Data;
using System.Data.SqlClient;
using APP.Framework.Infrastructure;

using APP.Camera.Domain;
using System.Collections.Generic;

namespace APP.Camera.Infrastructure
{
    public partial class MsSerialDataAccess
    {
        private DAL DALInfo;

        public MsSerialDataAccess(DAL objDAL)
        {
            DALInfo = objDAL;
            DALInfo.ConnectionString = new Connection(DALInfo).ConnectionString(DALInfo.ApplicationMode);
        }

        private static T Mapper<T>(object obj)
        {
            T val = default(T);
            if (obj != DBNull.Value)
            {
                val = (T)obj;
            }
            return val;
        }



        #region Standard
        public MsSerial GetMsSerialByMsSerialID(string SerialID)
        {
            SqlConnection conn = new SqlConnection(DALInfo.ConnectionString);
            SqlCommand cmd = new SqlCommand("up_RetrieveMsSerial", conn);
            MsSerial objTbl = new MsSerial();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SerialID", SerialID);
            SqlDataReader da = default(SqlDataReader);
            try
            {
                cmd.Connection.Open();
                da = cmd.ExecuteReader();

                if (da.HasRows)
                {
                    objTbl = MoveDataToCollection(da)[0];
                }
                else
                {
                    return objTbl;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                da.Close();
                conn.Close();
                cmd.Dispose();
            }

            return objTbl;
        }


        public List<MsSerial> GetMsSerialList()
        {
            SqlConnection conn = new SqlConnection(DALInfo.ConnectionString);
            SqlCommand cmd = new SqlCommand("up_RetrieveMsSerialList", conn);
            List<MsSerial> msSerialList = new List<MsSerial>();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader da = default(SqlDataReader);
            try
            {
                cmd.Connection.Open();
                da = cmd.ExecuteReader();

                if (da.HasRows)
                {
                    msSerialList = MoveDataToCollection(da);
                }
                else
                {
                    return msSerialList;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                da.Close();
                conn.Close();
                cmd.Dispose();
            }

            return msSerialList;
        }


        public List<MsSerial> GetMsSerialListCustom(string Where, string OrderBy, int Start, int Limit)
        {
            SqlConnection conn = new SqlConnection(DALInfo.ConnectionString);
            SqlCommand cmd = new SqlCommand("up_RetrieveMsSerialListCustom", conn);
            SqlParameter orderBy = new SqlParameter("@OrderBy", SqlDbType.VarChar);
            SqlParameter where = new SqlParameter("@Where", SqlDbType.VarChar);
            SqlParameter start = new SqlParameter("@Start", SqlDbType.Int);
            SqlParameter limit = new SqlParameter("@Limit", SqlDbType.VarChar);

            Start = (Start - 1) * Limit;

            where.Value = Where;
            orderBy.Value = OrderBy;
            start.Value = Start;
            limit.Value = Limit;

            cmd.Parameters.Add(where);
            cmd.Parameters.Add(orderBy);
            cmd.Parameters.Add(start);
            cmd.Parameters.Add(limit);

            List<MsSerial> msSerialList = new List<MsSerial>();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader da = default(SqlDataReader);
            cmd.Connection.Open();
            da = cmd.ExecuteReader();

            try
            {
                if (da.HasRows)
                {
                    msSerialList = MoveDataToCollection(da, true);
                }
                else
                {
                    return msSerialList;
                }
            }
            finally
            {
                da.Close();
                conn.Close();
                cmd.Dispose();
            }

            return msSerialList;
        }


        private List<MsSerial> MoveDataToCollection(SqlDataReader MyReader, Boolean isCustom = false)
        {
            List<MsSerial> msSerialList = new List<MsSerial>();
            while (MyReader.Read())
            {
                MsSerial objMsSerial = new MsSerial();
                objMsSerial.SerialID = MyReader["serialid"].ToString().Trim();
                objMsSerial.SerialDesc = MyReader["serialdesc"].ToString().Trim();
                objMsSerial.Remark = MyReader["remark"].ToString().Trim();
                objMsSerial.SerialLength = Mapper<int>(MyReader["seriallength"]);
                objMsSerial.StartNum = Mapper<int>(MyReader["startnum"]);
                objMsSerial.EndNum = Mapper<int>(MyReader["endnum"]);
                objMsSerial.CurrentNum = Mapper<int>(MyReader["currentnum"]);
                objMsSerial.TsCrt = Mapper<DateTime>(MyReader["tscrt"]);
                objMsSerial.CrtUsrID = MyReader["crtusrid"].ToString().Trim();
                objMsSerial.TsMod = Mapper<DateTime>(MyReader["tsmod"]);
                objMsSerial.ModUsrID = MyReader["modusrid"].ToString().Trim();
                objMsSerial.ActiveFlag = MyReader["activeflag"].ToString().Trim();
                objMsSerial.RowState = DataRowState.Unchanged;

                if (isCustom == true)
                {
                    objMsSerial.RowNumber = Convert.ToInt64(MyReader["RowNumber"]);
                    objMsSerial.TotalRecord = Convert.ToInt64(MyReader["TotalRecord"]);
                }
                msSerialList.Add(objMsSerial);
            }
            return msSerialList;
        }


        public TransactionResult Update(ref List<MsSerial> objList)
        {
            List<SqlCommand> ArraySQLCmd = new List<SqlCommand>();
            TransactionDB TransDB = new TransactionDB(DALInfo);
            TransactionResult ObjTransResult = default(TransactionResult);

            GetBatchQueryUpdate(objList, ref ArraySQLCmd);

            ObjTransResult = TransDB.BatchUpdate(ArraySQLCmd);

            if (ObjTransResult.Result == 1)
            {
                objList = AcceptChanges(ref objList);
            }

            return ObjTransResult;
        }

        public TransactionResult Update(ref MsSerial item)
        {
            List<SqlCommand> ArraySQLCmd = new List<SqlCommand>();
            TransactionDB TransDB = new TransactionDB(DALInfo);
            TransactionResult ObjTransResult = default(TransactionResult);

            GetSingleQueryUpdate(item, ref ArraySQLCmd);

            ObjTransResult = TransDB.BatchUpdate(ArraySQLCmd);

            if (ObjTransResult.Result == 1 && !item.RowState.Equals(DataRowState.Deleted))
            {
                item.RowState = DataRowState.Unchanged;
            }

            return ObjTransResult;
        }

        public List<MsSerial> AcceptChanges(ref List<MsSerial> objList)
        {
            List<MsSerial> DataBindCol = new List<MsSerial>();

            foreach (MsSerial item in objList)
            {
                if (item.RowState != DataRowState.Deleted)
                {
                    item.RowState = DataRowState.Unchanged;
                    DataBindCol.Add(item);
                }
            }
            objList = new List<MsSerial>();
            objList = DataBindCol;
            return DataBindCol;
        }

        public void GetBatchQueryUpdate(List<MsSerial> objDomain, ref List<SqlCommand> ArraySQLCmd)
        {
            foreach (MsSerial item in objDomain)
            {
                MsSerial itm = item;
                DALInfo.AssignedInfo(ref itm);
                UpdateQuery(itm, ArraySQLCmd);
            }
        }

        public void GetSingleQueryUpdate(MsSerial item, ref List<SqlCommand> ArraySQLCmd)
        {
            MsSerial itm = item;
            DALInfo.AssignedInfo(ref itm);
            UpdateQuery(itm, ArraySQLCmd);
        }

        public void UpdateQuery(MsSerial item, List<SqlCommand> ArraySQLCmd)
        {
            SqlCommand cmd = null;
            if (item.RowState == DataRowState.Added)
            {
                cmd = new SqlCommand("up_InsertMsSerial");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@serialid", SqlDbType.VarChar, 50).Value = item.SerialID;
                cmd.Parameters.Add("@serialdesc", SqlDbType.NVarChar, 510).Value = item.SerialDesc;
                cmd.Parameters.Add("@remark", SqlDbType.VarChar, 250).Value = item.Remark;
                cmd.Parameters.Add("@seriallength", SqlDbType.Int, 4).Value = item.SerialLength;
                cmd.Parameters.Add("@startnum", SqlDbType.Int, 4).Value = item.StartNum;
                cmd.Parameters.Add("@endnum", SqlDbType.Int, 4).Value = item.EndNum;
                cmd.Parameters.Add("@currentnum", SqlDbType.Int, 4).Value = item.CurrentNum;
                cmd.Parameters.Add("@crtusrid", SqlDbType.VarChar, 50).Value = item.CrtUsrID;
                cmd.Parameters.Add("@modusrid", SqlDbType.VarChar, 50).Value = item.ModUsrID;
                cmd.Parameters.Add("@activeflag", SqlDbType.Char, 1).Value = item.ActiveFlag;
            }
            else if (item.RowState == DataRowState.Modified)
            {
                cmd = new SqlCommand("up_UpdateMsSerial");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@serialid", SqlDbType.VarChar, 50).Value = item.SerialID;
                cmd.Parameters.Add("@serialdesc", SqlDbType.NVarChar, 510).Value = item.SerialDesc;
                cmd.Parameters.Add("@remark", SqlDbType.VarChar, 250).Value = item.Remark;
                cmd.Parameters.Add("@seriallength", SqlDbType.Int, 4).Value = item.SerialLength;
                cmd.Parameters.Add("@startnum", SqlDbType.Int, 4).Value = item.StartNum;
                cmd.Parameters.Add("@endnum", SqlDbType.Int, 4).Value = item.EndNum;
                cmd.Parameters.Add("@currentnum", SqlDbType.Int, 4).Value = item.CurrentNum;
                cmd.Parameters.Add("@modusrid", SqlDbType.VarChar, 50).Value = item.ModUsrID;
                cmd.Parameters.Add("@activeflag", SqlDbType.Char, 1).Value = item.ActiveFlag;
            }
            else if (item.RowState == DataRowState.Deleted)
            {
                cmd = new SqlCommand("up_DeleteMsSerial");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@serialid", SqlDbType.VarChar, 50).Value = item.SerialID;
                cmd.Parameters.Add("@modusrid", SqlDbType.VarChar, 50).Value = item.ModUsrID;
            }

            if (cmd != null)
            {
                ArraySQLCmd.Add(cmd);
            }
        }


        #endregion
    }
}