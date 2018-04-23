<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1, Version=9.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to fill values in a new row obtained from the row where the "new" button was clicked</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="sds" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            DeleteCommand="DELETE FROM [Categories] WHERE [CategoryID] = @CategoryID" InsertCommand="INSERT INTO [Categories] ([CategoryName], [Description]) VALUES (@CategoryName, @Description)"
            SelectCommand="SELECT [CategoryID], [CategoryName], [Description] FROM [Categories]"
            UpdateCommand="UPDATE [Categories] SET [CategoryName] = @CategoryName, [Description] = @Description WHERE [CategoryID] = @CategoryID">
            <DeleteParameters>
                <asp:Parameter Name="CategoryID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="CategoryName" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="CategoryID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="CategoryName" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <dxwgv:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="sds"
            KeyFieldName="CategoryID" ClientInstanceName="grid" OnCustomCallback="grid_CustomCallback"
            OnInitNewRow="grid_InitNewRow" OnRowDeleting="grid_RowDeleting" OnRowInserting="grid_RowInserting"
            OnRowUpdating="grid_RowUpdating">
            <Columns>
                <dxwgv:GridViewDataTextColumn Caption="#" VisibleIndex="0">
                    <DataItemTemplate>
                        <dxe:ASPxHyperLink ID="lnkEdit" runat="server" NavigateUrl="javascript:void(0);"
                            Text="Edit" OnLoad="lnkEdit_Load" />
                        <dxe:ASPxHyperLink ID="lnkNew" runat="server" NavigateUrl="javascript:void(0);" Text="New"
                            OnLoad="lnkNew_Load" />
                        <dxe:ASPxHyperLink ID="lnkDelete" runat="server" NavigateUrl="javascript:void(0);"
                            Text="Delete" ClientSideEvents-Click='<%# "function (s, e) { grid.DeleteRow(" + Container.VisibleIndex + "); }"%>' />
                    </DataItemTemplate>
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True" VisibleIndex="1">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="2">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="Description" VisibleIndex="3">
                </dxwgv:GridViewDataTextColumn>
            </Columns>
        </dxwgv:ASPxGridView>
    </div>
    </form>
</body>
</html>
