<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to fill values in a new row obtained from the row where the "new" button was clicked
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e1566/)**
<!-- run online end -->


<p>Rows are filled in the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_InitNewRowtopic">ASPxGridView.InitNewRow</a> event handler. Editing starts by performing a callback on the client side with an appropriate parameter "New|#", where "#" is a row number where the "new" button is placed. The <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_CustomCallbacktopic">ASPxGridView.CustomCallback</a> event handler performs parsing and new node inserting. The default values are added to the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebDataASPxDataInitNewRowEventArgs_NewValuestopic">e.NewValues</a> argument.</p><p><strong>Note:</strong><br />
The database couldn't be updated in the example due to server restrictions.</p>

<br/>


