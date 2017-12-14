// -----------------------------------------------------------------------
// <copyright file="UserLogVO.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Toyo.Core
{
    using System;
    using System.Collections.Generic;
    
    using System.Text;
    using Toyo.Core;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UserLogVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime logDate;

        public DateTime LogDate
        {
            get { return logDate; }
            set { logDate = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string module;

        public string Module
        {
            get { return module; }
            set { module = value; }
        }
        private string formName;

        public string FormName
        {
            get { return formName; }
            set { formName = value; }
        }
        private string action;

        public string Action
        {
            get { return action; }
            set { action = value; }
        }

    }
}
