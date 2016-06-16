using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Web.UI;

namespace SitefinityWebApp.CustomTemplates.DownloadList
{
    public partial class CustomMasterListView1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void documentsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Document dataItem = (Document)e.Item.DataItem;
                if (dataItem != null)
                {
                    string extension = dataItem.Extension;
                    if (extension.Length > 0)
                    {
                        extension = extension.Remove(0, 1);
                    }
                    HyperLink title = e.Item.FindControl("documentLink") as HyperLink;
                    if (title != null)
                    {
                        title.Text = dataItem.Title;
                        title.ToolTip = dataItem.Description;
                        title.NavigateUrl = dataItem.MediaUrl;
                    }
                    HyperLink downloadIcon = e.Item.FindControl("downloadIcon") as HyperLink;
                    if (downloadIcon != null)
                    {
                        downloadIcon.Text = @"<span class=""glyphicon glyphicon-collapse-down"" aria-hidden=""true""></span>";
                        downloadIcon.ToolTip = dataItem.Description;
                        downloadIcon.NavigateUrl = dataItem.MediaUrl;
                    }
                    SitefinityLabel sitefinityLabel = e.Item.FindControl("infoLabel") as SitefinityLabel;
                    if (sitefinityLabel != null)
                    {
                        sitefinityLabel.Text = string.Format("{0}, {1}", extension.ToUpperInvariant(),
                            this.ConfigureBytes(dataItem.TotalSize));
                    }
                    HtmlGenericControl htmlGenericControl = e.Item.FindControl("docItem") as HtmlGenericControl;
                    if (htmlGenericControl != null)
                    {
                        AttributeCollection attributes = htmlGenericControl.Attributes;
                        AttributeCollection attributeCollection = attributes;
                        attributes["class"] = string.Concat(attributeCollection["class"], " sf", extension.ToLower());
                    }

                    Literal libraryName = e.Item.FindControl("libraryName") as Literal;
                    if (dataItem.Library.Title == "Default Library")
                    {
                        libraryName.Text = "General";
                    }
                    else
                    {
                        libraryName.Text = dataItem.Library.Title;
                    }
                }
            }
        }

        public string ConfigureBytes(long bytes)
        {
            string empty = string.Empty;
            if (bytes != (long)0)
            {
                string[] strArrays = new string[] { "bytes", "KB", "MB", "GB", "TB", "PB" };
                string[] strArrays1 = strArrays;
                double num = Math.Floor(Math.Log((double)bytes) / Math.Log(1024));
                if (num != 0)
                {
                    empty = string.Concat(string.Format("{0:0.00}", (double)bytes / Math.Pow(1024, Math.Floor(num))), " ", strArrays1[(int)num]);
                }
                else
                {
                    num = num + 1;
                    empty = string.Concat(Math.Ceiling((double)bytes / Math.Pow(1024, Math.Floor(num))), " ", strArrays1[(int)num]);
                }
            }
            else
            {
                empty = "0 KB";
            }
            return empty;
        }

        protected void search_TextChanged(object sender, EventArgs e)
        {
            LibrariesManager libMan = LibrariesManager.GetManager();
            var dataSource = libMan.GetDocuments().Where(a => a.Status == ContentLifecycleStatus.Live);
            if (!this.search.Text.IsNullOrEmpty())
                dataSource = dataSource
                    .Where(itm => (itm.Title.ToString()
                        .Contains(this.search.Text) && itm.Status == ContentLifecycleStatus.Live));

            this.documentsRepeater.DataSource = dataSource.ToList();
            this.documentsRepeater.ItemDataBound += documentsRepeater_ItemDataBound;
            this.documentsRepeater.DataBind();
        }
    }
}