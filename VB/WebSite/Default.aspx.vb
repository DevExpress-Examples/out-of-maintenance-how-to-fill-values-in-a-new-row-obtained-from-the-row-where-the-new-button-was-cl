Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Imports System.Data

Partial Public Class _Default
	Inherits System.Web.UI.Page
	' Used for remembering the clicked button position
	Private clickedRowIndex As Int32 = -1

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub lnkEdit_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim link As ASPxHyperLink = TryCast(sender, ASPxHyperLink)
		Dim container As GridViewDataItemTemplateContainer = TryCast(link.NamingContainer, GridViewDataItemTemplateContainer)

		link.ClientInstanceName = String.Format("lnkEdit{0}", container.VisibleIndex)
		link.ClientSideEvents.Click = String.Format("function (s, e) {{ grid.StartEditRow({0}); }}", container.VisibleIndex)
	End Sub

	Protected Sub lnkNew_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim link As ASPxHyperLink = TryCast(sender, ASPxHyperLink)
		Dim container As GridViewDataItemTemplateContainer = TryCast(link.NamingContainer, GridViewDataItemTemplateContainer)

		link.ClientInstanceName = String.Format("lnkNew_{0}", container.VisibleIndex)
		link.ClientSideEvents.Click = String.Format("function (s, e) {{ grid.PerformCallback(""New|"" + {0}); }}", container.VisibleIndex)
	End Sub
	Protected Sub grid_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
		Dim options() As String = e.Parameters.Split("|"c)

		If options.Length = 2 Then
			If options(0) = "New" Then
				clickedRowIndex = Convert.ToInt32(options(1))
			End If
		End If

		grid.AddNewRow()
	End Sub

	Protected Sub grid_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs)
		Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)

		Dim row As DataRowView = CType(grid.GetRow(clickedRowIndex), DataRowView)
		For Each column As DataColumn In row.DataView.Table.Columns
			e.NewValues(column.ColumnName) = row(column.ColumnName)
		Next column
	End Sub

	Protected Sub grid_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
		e.Cancel = True
	End Sub

	Protected Sub grid_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
		Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
		e.Cancel = True
		grid.CancelEdit()
	End Sub

	Protected Sub grid_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
		Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
		e.Cancel = True
		grid.CancelEdit()
	End Sub
End Class
