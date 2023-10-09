using APP.Framework;
using APP.Framework.Infrastructure;
using System;

namespace APP.Camera.Infrastructure
{
    public class Connection
    {
        private DAL DALInfo;
        private string ApplicationName = "Camera";
        private string SQLProfilerInfo;

        public Connection(DAL objDAL)
        {
            DALInfo = objDAL;
            SQLProfilerInfo = "Application Name=" + ApplicationName + ";Workstation ID=" + DALInfo.GlobalID + ";";
        }

        public string ConnectionString(Enumeration.ApplicationMode ApplicationMode)
        {
            if (ApplicationMode == Enumeration.ApplicationMode.Development)
            {
                return APPConnectionDev;
            }
            else if (ApplicationMode == Enumeration.ApplicationMode.Testing)
            {
                return APPConnectionTst;
            }
            else if (ApplicationMode == Enumeration.ApplicationMode.Production)
            {
                return APPConnectionPrd;
            }
            else
            {
                return "";
            }
        }

        public string UserEmployeeConnectionString(Enumeration.ApplicationMode ApplicationMode)
        {
            if (ApplicationMode == Enumeration.ApplicationMode.Development)
            {
                return APPConnectionDev;
            }
            else if (ApplicationMode == Enumeration.ApplicationMode.Testing)
            {
                return APPConnectionTst;
            }
            else if (ApplicationMode == Enumeration.ApplicationMode.Production)
            {
                return APPConnectionPrd;
            }
            else
            {
                return "";
            }
        }

        public string MailConnectionString(Enumeration.ApplicationMode ApplicationMode)
        {
            if (ApplicationMode == Enumeration.ApplicationMode.Development)
            {
                return APPConnectionDev;
            }
            else if (ApplicationMode == Enumeration.ApplicationMode.Testing)
            {
                return APPConnectionTst;
            }
            else if (ApplicationMode == Enumeration.ApplicationMode.Production)
            {
                return APPConnectionPrd;
            }
            else
            {
                return "";
            }
        }

        private string APPConnectionDev
        {
            get
            {
                string returnValue = "";
                returnValue = "Data Source=IDSRGVPDBS01;Initial Catalog=ACL;Persist Security Info=True;User ID=xxxx;Password=xxxx;" + SQLProfilerInfo;
                return returnValue;
            }
        }

        private string APPConnectionTst
        {
            get
            {
                string returnValue = "";
                returnValue = "Data Source=IDSRGVPDBS01;Initial Catalog=ACL;Persist Security Info=True;User ID=xxxx;Password=xxxx;" + SQLProfilerInfo;
                return returnValue;
            }
        }

        private string APPConnectionPrd
        {
            get
            {
                string returnValue = "";
                returnValue = "Data Source=IDSRGVPDBS01;Initial Catalog=ACL;Persist Security Info=True;User ID=xxxx;Password=xxxx;" + SQLProfilerInfo;
                return returnValue;
            }
        }

        private string MailConnectionDev
        {
            get
            {
                string returnValue = "";
                returnValue = "Data Source=IDSRGVPDBS01;Initial Catalog=ACL;Persist Security Info=True;User ID=xxxx;Password=xxxx;" + SQLProfilerInfo;
                return returnValue;
            }
        }

        private string MailConnectionTst
        {
            get
            {
                string returnValue = "";
                returnValue = "Data Source=IDSRGVPDBS01;Initial Catalog=ACL;Persist Security Info=True;User ID=xxxx;Password=xxxx;" + SQLProfilerInfo;
                return returnValue;
            }
        }

        private string MailConnectionPrd
        {
            get
            {
                string returnValue = "";
                returnValue = "Data Source=IDSRGVPDBS01;Initial Catalog=ACL;Persist Security Info=True;User ID=xxxx;Password=xxxx;" + SQLProfilerInfo;
                return returnValue;
            }
        }

    }
}
