﻿
using APP.Framework.Domain;
using System;
using System.Diagnostics;

//Generated by .NET Class Generator Tools
namespace APP.Camera.Domain.Dto
{

    [DebuggerStepThrough()]
    public partial class Getmenu : AbstractTable
    {
        private int _MenuID;
        private int _ParentID;
        private int _Seq;
        private string _MenuText;
        private string _PageName;

        public int MenuID
        {
            get
            {
                return _MenuID;
            }
            set
            {
                _MenuID = value;
                Modify();
            }
        }

        public int ParentID
        {
            get
            {
                return _ParentID;
            }
            set
            {
                _ParentID = value;
                Modify();
            }
        }

        public int Seq
        {
            get
            {
                return _Seq;
            }
            set
            {
                _Seq = value;
                Modify();
            }
        }

        public string MenuText
        {
            get
            {
                return _MenuText;
            }
            set
            {
                _MenuText = value;
                Modify();
            }
        }

        public string PageName
        {
            get
            {
                return _PageName;
            }
            set
            {
                _PageName = value;
                Modify();
            }
        }


    }

}