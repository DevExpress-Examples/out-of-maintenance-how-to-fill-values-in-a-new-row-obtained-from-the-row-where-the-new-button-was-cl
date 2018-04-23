using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    // Used for remembering the clicked button position
    private Int32 clickedRowIndex = -1;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lnkEdit_Load(object sender, EventArgs e)
    {
        ASPxHyperLink link = sender as ASPxHyperLink;
        GridViewDataItemTemplateContainer container = link.NamingContainer as GridViewDataItemTemplateContainer;

        link.ClientInstanceName = String.Format("lnkEdit{0}", container.VisibleIndex);
        link.ClientSideEvents.Click = String.Format("function (s, e) {{ grid.StartEditRow({0}); }}", container.VisibleIndex);
    }

    protected void lnkNew_Load(object sender, EventArgs e)
    {
        ASPxHyperLink link = sender as ASPxHyperLink;
        GridViewDataItemTemplateContainer container = link.NamingContainer as GridViewDataItemTemplateContainer;

        link.ClientInstanceName = String.Format("lnkNew_{0}", container.VisibleIndex);
        link.ClientSideEvents.Click = String.Format("function (s, e) {{ grid.PerformCallback(\"New|\" + {0}); }}", container.VisibleIndex);
    }
    protected void grid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        String[] options = e.Parameters.Split('|');

        if (options.Length == 2)
        {
            if (options[0] == "New")
                clickedRowIndex = Convert.ToInt32(options[1]);
        }

        grid.AddNewRow();
    }

    protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;

        DataRowView row = (DataRowView)grid.GetRow(clickedRowIndex);
        foreach (DataColumn column in row.DataView.Table.Columns)
            e.NewValues[column.ColumnName] = row[column.ColumnName];
    }

    protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
    {
        e.Cancel = true;
    }

    protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        e.Cancel = true;
        grid.CancelEdit();
    }

    protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        ASPxGridView grid = sender as ASPxGridView;
        e.Cancel = true;
        grid.CancelEdit();
    }
}
