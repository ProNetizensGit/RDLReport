using Microsoft.Reporting.WebForms;
using sampleRDLCReport.Report_Data_Sets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sampleRDLCReport.Views
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
        }
        
        protected void btnReportRDL_Click(object sender, EventArgs e)
        {
            // Get the report name from the CommandArgument property of the clicked button
            string reportName = (sender as Button)?.CommandArgument;

            if (!string.IsNullOrEmpty(reportName))
            {
                ShowReport2(reportName);
            }
        }
        protected void btnLoadReport_Click(object sender, EventArgs e)
        {
            try
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/SnapStockReport.rdlc");
                SnapStockReport _objRDLCReport = GetData();
                ReportDataSource ds = new ReportDataSource("SnapStockReportDs", _objRDLCReport.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(ds);
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            // Get the report name from the CommandArgument property of the clicked button
            string reportName = (sender as Button)?.CommandArgument;

            if (!string.IsNullOrEmpty(reportName))
            {
                ShowReport(reportName);
            }
        }

        private void ShowReport(string reportName)
        {
            try
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath($"~/Reports/SnapStockReport.rdlc");
                // Set other parameters as needed, e.g., Site parameter
                SnapStockReport _objRDLCReport = GetData(reportName);
                ReportDataSource ds = new ReportDataSource("SnapStockReportDs", _objRDLCReport.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(ds);
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        private void ShowReport2(string reportName)
        {
            try
            {
                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://laptop-tn6o5drm:8080/ReportServer");
                ReportViewer1.ServerReport.ReportPath = @"/Sample_SSRS/Sales Orders";
                //ReportParameter[] parameters = new ReportParameter[2];
                //parameters[0] = new ReportParameter("Parameter", "Value");
                //ReportViewer1.ServerReport.SetParameters(parameters);


            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private SnapStockReport GetData()
        {
            string conStr = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            string query = "SELECT TOP (1000) * FROM [RDLCReport].[dbo].[RDLCTemplateDB] WHERE Site = @SlotID";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SlotID", txtSite.Text);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        using (SnapStockReport objRDLCReport = new SnapStockReport())
                        {
                            da.Fill(objRDLCReport, "RDLCTemplateDB");
                            return objRDLCReport;
                        }
                    }
                }
            }
        }

        private SnapStockReport GetData(string reportName)
        {
            string conStr = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            string query = "SELECT TOP (1000) * FROM [RDLCReport].[dbo].[RDLCTemplateDB] WHERE Site = @SlotID";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SlotID", reportName);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        using (SnapStockReport objRDLCReport = new SnapStockReport())
                        {
                            da.Fill(objRDLCReport, "RDLCTemplateDB");
                            return objRDLCReport;
                        }
                    }
                }
            }
        }


    }
}