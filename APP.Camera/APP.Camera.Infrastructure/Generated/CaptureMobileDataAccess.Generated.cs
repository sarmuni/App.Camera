﻿//Generated by .NET Class Generator Tools

using System;
using System.Data;
using System.Data.SqlClient;
using APP.Framework.Infrastructure;

using APP.Camera.Domain;
using System.Collections.Generic;

namespace APP.Camera.Infrastructure
{
public partial class CaptureMobileDataAccess
{	private DAL DALInfo;

	public CaptureMobileDataAccess(DAL objDAL)
	{
		DALInfo = objDAL;
		DALInfo.ConnectionString = new Connection(DALInfo).ConnectionString(DALInfo.ApplicationMode);
	}

	private static T Mapper<T>(object obj)
	{
		T val = default(T);
		if (obj != DBNull.Value)
		{
			val = (T) obj;
		}
		return val;
	}



#region Standard
public CaptureMobile GetCaptureMobileByCaptureMobileID(int ID)
{
	SqlConnection conn = new SqlConnection(DALInfo.ConnectionString);
	SqlCommand cmd = new SqlCommand("up_RetrieveCaptureMobile", conn);
	CaptureMobile objTbl = new CaptureMobile();
	cmd.CommandType = CommandType.StoredProcedure;

	cmd.Parameters.AddWithValue("@ID",ID);
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
			return null;
		}
	}
	catch (Exception ex)
	{
		throw ex;
	}
	finally
	{
		da.Close();
		conn.Close();
		cmd.Dispose();
	}

	return objTbl;
}


public List<CaptureMobile> GetCaptureMobileList()
{
	SqlConnection conn = new SqlConnection(DALInfo.ConnectionString);
	SqlCommand cmd = new SqlCommand("up_RetrieveCaptureMobileList", conn);
	List<CaptureMobile> captureMobileList = new List<CaptureMobile>();
	cmd.CommandType = CommandType.StoredProcedure;

	SqlDataReader da = default(SqlDataReader);
	try
	{
		cmd.Connection.Open();
		da = cmd.ExecuteReader();

		if (da.HasRows)
		{
			captureMobileList = MoveDataToCollection(da);
		}
		else
		{
			return captureMobileList;
		}
	}
	catch (Exception ex)
	{
		throw ex;
	}
	finally
	{
		da.Close();
		conn.Close();
		cmd.Dispose();
	}

	return captureMobileList;
}


public List<CaptureMobile> GetCaptureMobileListCustom(string Where, string OrderBy, int Start, int Limit)
{
	SqlConnection conn = new SqlConnection(DALInfo.ConnectionString);
	SqlCommand cmd = new SqlCommand("up_RetrieveCaptureMobileListCustom", conn);
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

	List<CaptureMobile> captureMobileList = new List<CaptureMobile>();
	cmd.CommandType = CommandType.StoredProcedure;

	SqlDataReader da = default(SqlDataReader);
	cmd.Connection.Open();
	da = cmd.ExecuteReader();

	try
	{
		if (da.HasRows)
		{
			if (Start == 0 && Limit == 0)
			{
				captureMobileList = MoveDataToCollection(da, false);
			}
			else
			{
				captureMobileList = MoveDataToCollection(da, true);
			}
		}
		else
		{
			return captureMobileList;
		}
	}
	finally
	{
		da.Close();
		conn.Close();
		cmd.Dispose();
	}

	return captureMobileList;
}


private List<CaptureMobile> MoveDataToCollection(SqlDataReader MyReader,Boolean isCustom = false)
{
	List<CaptureMobile> captureMobileList = new List<CaptureMobile>();
	while (MyReader.Read())
	{
		CaptureMobile objCaptureMobile = new CaptureMobile();
		objCaptureMobile.ID = Mapper<int>(MyReader["id"]);
		objCaptureMobile.DirName = MyReader["dirname"].ToString().Trim();
		objCaptureMobile.CaptureFile = MyReader["capturefile"].ToString().Trim();
		objCaptureMobile.CrtUsrID = MyReader["crtusrid"].ToString().Trim();
		objCaptureMobile.TsCrt = Mapper<DateTime>(MyReader["tscrt"]);
		objCaptureMobile.ModUsrID = MyReader["modusrid"].ToString().Trim();
		objCaptureMobile.TsMod = Mapper<DateTime?>(MyReader["tsmod"]);
		objCaptureMobile.ActiveFlag = MyReader["activeflag"].ToString().Trim();
		objCaptureMobile.RowState = DataRowState.Unchanged;

		if (isCustom == true)
		{
			objCaptureMobile.RowNumber = Convert.ToInt64(MyReader["RowNumber"]);
			objCaptureMobile.TotalRecord = Convert.ToInt64(MyReader["TotalRecord"]);
		}
		captureMobileList.Add(objCaptureMobile);
	}
	return captureMobileList;
}


public TransactionResult Update(ref List<CaptureMobile> objList)
{
	List<SqlCommand> ArraySQLCmd = new List<SqlCommand>();
	TransactionDB TransDB = new TransactionDB(DALInfo);
	TransactionResult ObjTransResult = default(TransactionResult);

	GetBatchQueryUpdate(objList,ref ArraySQLCmd);

	ObjTransResult = TransDB.BatchUpdate(ArraySQLCmd);

	if (ObjTransResult.Result == 1)
	{
		objList = AcceptChanges(ref objList);
	}

	return ObjTransResult;
}

public TransactionResult Update(ref CaptureMobile item)
{
	List<SqlCommand> ArraySQLCmd = new List<SqlCommand>();
	TransactionDB TransDB = new TransactionDB(DALInfo);
	TransactionResult ObjTransResult = default(TransactionResult);

	GetSingleQueryUpdate(item,ref ArraySQLCmd);

	ObjTransResult = TransDB.BatchUpdate(ArraySQLCmd);

	if (ObjTransResult.Result == 1 && !item.RowState.Equals(DataRowState.Deleted))
	{
		item.RowState = DataRowState.Unchanged;
	}

	return ObjTransResult;
}

public List<CaptureMobile> AcceptChanges(ref List<CaptureMobile> objList)
{
	List<CaptureMobile> DataBindCol = new List<CaptureMobile>();

	foreach (CaptureMobile item in objList)
	{
		if (item.RowState != DataRowState.Deleted)
		{
			item.RowState = DataRowState.Unchanged;
			DataBindCol.Add(item);
		}
	}
	objList= new List<CaptureMobile>();
	objList = DataBindCol;
	return DataBindCol;
}

public void GetSingleQueryUpdate(CaptureMobile item, ref List<SqlCommand> ArraySQLCmd)
{
		CaptureMobile itm = item;
	DALInfo.AssignedInfo(ref itm);
	UpdateQuery(itm, ArraySQLCmd);
}

public void GetBatchQueryUpdate(List<CaptureMobile> objDomain, ref List<SqlCommand> ArraySQLCmd)
{
	foreach (CaptureMobile item in objDomain)
	{
		CaptureMobile itm = item;
		DALInfo.AssignedInfo(ref itm);
		UpdateQuery(itm, ArraySQLCmd);
	}
}

public void UpdateQuery(CaptureMobile item, List<SqlCommand> ArraySQLCmd)
{
	SqlCommand cmd = null;
	if (item.RowState == DataRowState.Added)
	{
		cmd = new SqlCommand("up_InsertCaptureMobile");
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@dirname", SqlDbType.VarChar, 100).Value = item.DirName == null ? (object)DBNull.Value : item.DirName;
		cmd.Parameters.Add("@capturefile", SqlDbType.VarChar, 500).Value = item.CaptureFile == null ? (object)DBNull.Value : item.CaptureFile;
		cmd.Parameters.Add("@crtusrid", SqlDbType.VarChar, 10).Value = item.CrtUsrID;
		cmd.Parameters.Add("@modusrid", SqlDbType.VarChar, 10).Value = item.ModUsrID == null ? (object)DBNull.Value : item.ModUsrID;
		cmd.Parameters.Add("@activeflag", SqlDbType.Char, 1).Value = item.ActiveFlag;
	}
	else if (item.RowState == DataRowState.Modified)
	{
		cmd = new SqlCommand("up_UpdateCaptureMobile");
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@id", SqlDbType.Int, 4).Value = item.ID;
		cmd.Parameters.Add("@dirname", SqlDbType.VarChar, 100).Value = item.DirName == null ? (object)DBNull.Value : item.DirName;
		cmd.Parameters.Add("@capturefile", SqlDbType.VarChar, 500).Value = item.CaptureFile == null ? (object)DBNull.Value : item.CaptureFile;
		cmd.Parameters.Add("@modusrid", SqlDbType.VarChar, 10).Value = item.ModUsrID == null ? (object)DBNull.Value : item.ModUsrID;
		cmd.Parameters.Add("@activeflag", SqlDbType.Char, 1).Value = item.ActiveFlag;
	}
	else if (item.RowState == DataRowState.Deleted)
	{
		cmd = new SqlCommand("up_DeleteCaptureMobile");
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@id", SqlDbType.Int, 4).Value = item.ID;
		cmd.Parameters.Add("@modusrid", SqlDbType.VarChar, 10).Value = item.ModUsrID == null ? (object)DBNull.Value : item.ModUsrID;
	}

	if (cmd != null)
	{
		ArraySQLCmd.Add(cmd);
	}
}


#endregion
}
}