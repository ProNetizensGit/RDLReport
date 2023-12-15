<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="sampleRDLCReport.Views.Index" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <title></title>
   </head>
   <body>
      <form id="form1" runat="server">
         <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div>
               <asp:TextBox id ="txtSite" runat="server"/>
               <br />
               <asp:Button ID="btnLoadReport" runat="server" Text="Load Report" OnClick="btnLoadReport_Click" />

               <asp:Button ID="btnSnapReceiptHandlingDispatch" runat="server" Text="Snap Receipt Handling Dispatch" 
                           OnClick="btnReport_Click" CommandArgument="Site2" />
               <asp:Button ID="btnSnapStockStatus" runat="server" Text="SnapStockStatus" OnClick="btnReport_Click" CommandArgument="Site3" />
               <asp:Button ID="btnStockDisposals" runat="server" Text="Stock Disposals" OnClick="btnReport_Click" CommandArgument="Site1" />
               <asp:Button ID="Button1" runat="server" Text="Sales Order RDL Report" OnClick="btnReportRDL_Click" CommandArgument="Site1" />
            </div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1000" Height="500"></rsweb:ReportViewer>
         </div>
      </form>
   </body>
</html>