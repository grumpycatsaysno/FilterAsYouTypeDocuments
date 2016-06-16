using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Modules.Libraries.Documents;
using Telerik.Sitefinity.Modules.Libraries.Web.UI.Documents;

namespace SitefinityWebApp.CustomWidgets.DownloadList
{
    public class CustomDownloadListView : DownloadListView
    {
        public override string MasterViewName
        {
            get
            {
                return "CustomMasterListView";
            }
            set
            {
                base.MasterViewName = value;
            }
        }
    }
}