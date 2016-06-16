using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Modules.Libraries.Documents;
using Telerik.Sitefinity.Modules.Libraries.Web.UI.Documents;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ContentUI.Contracts;

namespace SitefinityWebApp.CustomWidgets.DownloadList
{
    public class CustomMasterListView : MasterListView
    {
        #region Properties

        /// <inheritdoc />
        public override string LayoutTemplatePath
        {
            get
            {
                return CustomMasterListView.layoutTemplatePath;
            }
        }

        static CustomMasterListView()
        {
            CustomMasterListView.layoutTemplatePath = "~/CustomWidgets/DownloadList/CustomMasterListView.ascx";
        }


        #endregion

        #region Control References

        protected virtual TextBox SearchTextBox
        {
            get
            {
                return this.Container.GetControl<TextBox>("search", true);
            }
        }

        #endregion

        public override void DataBindDocumentList()
        {
            if (String.IsNullOrEmpty(this.SearchTextBox.Text))
            {
                base.DataBindDocumentList();
            }
        }

        #region Private fields and constants

         public readonly static string layoutTemplatePath;

        #endregion
    }
}