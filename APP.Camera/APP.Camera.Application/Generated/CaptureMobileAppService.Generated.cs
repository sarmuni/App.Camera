using APP.Framework.Application;
using APP.Framework.Infrastructure;

using APP.Camera.Domain;
using APP.Camera.Domain.Dto;
using APP.Camera.Infrastructure;
using System;
using System.Diagnostics;
using System.Collections.Generic;
namespace APP.Camera.Application
{
[DebuggerStepThrough()]
public partial class CaptureMobileAppService : AbstractAppService
{
#region Collection
	public CaptureMobileAppService(AbstractUserProfile objUser) : base(objUser)
	{
	}


	public List<CaptureMobile> GetCaptureMobileList()
	{
		return new CaptureMobileDataAccess(DALInfo).GetCaptureMobileList();
	}


	public List<CaptureMobile> GetCaptureMobileListCustom(string Where = "", string OrderBy = "", int Start = 0, int Limit = 0)
	{
		return new CaptureMobileDataAccess(DALInfo).GetCaptureMobileListCustom(Where, OrderBy, Start, Limit);
	}


	public CaptureMobile GetCaptureMobileByCaptureMobileID(int ID)
	{
		return new CaptureMobileDataAccess(DALInfo).GetCaptureMobileByCaptureMobileID(ID);
	}

	public TransactionResult Update(ref List<CaptureMobile> objList)
	{
		return new CaptureMobileDataAccess(DALInfo).Update(ref objList);
	}

	public TransactionResult Update(ref CaptureMobile item)
	{
		return new CaptureMobileDataAccess(DALInfo).Update(ref item);
	}

#endregion
}
}