<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomMasterListView.ascx.cs" Inherits="SitefinityWebApp.CustomTemplates.DownloadList.CustomMasterListView1" %>

<%@ Register TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI.PublicControls.BrowseAndEdit" Assembly="Telerik.Sitefinity" %>
<%@ Register TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" Assembly="Telerik.Sitefinity" %>
<%@ Import Namespace="Telerik.Sitefinity.Web.UI" %>

<sitefinity:ResourceLinks ID="resourcesLinks2" runat="server" UseEmbeddedThemes="true" Theme="Basic">
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Themes.Basic.Styles.icons.css" Static="true" />
</sitefinity:ResourceLinks>
<sf:BrowseAndEditToolbar ID="browseAndEditToolbar" runat="server" Mode="Edit"></sf:BrowseAndEditToolbar>

<sitefinity:ResourceLinks ID="resourceLinks" runat="server" UseEmbeddedThemes="false">
    <sitefinity:ResourceFile Name="~/CustomWidgets/DownloadList/assets/css/bootstrap.min.css" Static="true" />
    <sitefinity:ResourceFile Name="~/CustomWidgets/DownloadList/assets/css/font-awesome.min.css" Static="true" />
    <sitefinity:ResourceFile Name="~/CustomWidgets/DownloadList/assets/css/styles.css" Static="true" />
</sitefinity:ResourceLinks>

<div id="search-wrapper" class="well resid-arrow">
    <asp:TextBox ID="search" ClientIDMode="Static" CssClass="search" placeholder="Search" runat="server"
        onkeyup="RefreshUpdatePanel();" OnTextChanged="search_TextChanged"
        AutoPostBack="true" />
    <input name="search-index" type="hidden" value="documents-search-index" />
    <p>
        <span class="glyphicon glyphicon-search lend-cri" aria-hidden="true"></span>
    </p>
</div>

<asp:UpdatePanel ID="Update" runat="server">
    <ContentTemplate>
        <div id="itemsContainer" runat="server">
            <asp:Repeater ID="documentsRepeater" runat="server" OnItemDataBound="documentsRepeater_ItemDataBound">
                <ItemTemplate>
                    <h4 class="toupper">
                        <asp:Literal runat="server" ID="libraryName" /></h4>
                    <div class="download-list">
                        <i class="fa fa-file-pdf-o" aria-hidden="true"></i>
                        <h5><strong>
                            <sitefinity:SitefinityHyperLink ID="documentLink" runat="server" Target="_blank" />
                        </strong>
                            <sitefinity:SitefinityLabel ID="infoLabel" runat="server" WrapperTagName="p" HideIfNoText="false" />
                        </h5>
                        <sitefinity:SitefinityHyperLink ID="downloadIcon" runat="server" Target="_blank" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <sitefinity:Pager ID="pager" runat="server"></sitefinity:Pager>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="search" />
    </Triggers>
</asp:UpdatePanel>

<telerik:RadCodeBlock runat="server" ID="RadCodeBlock1">
    <script src="<%= ResolveUrl("~/CustomWidgets/DownloadList/assets/js/bootstrap.min.js") %>"></script>
</telerik:RadCodeBlock>

<script type="text/javascript">
    function RefreshUpdatePanel() {
        __doPostBack('<%= search.ClientID %>', '');
    };
</script>


