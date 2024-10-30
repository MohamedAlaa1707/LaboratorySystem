using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace WindowsFormsApp4
{
    public partial class ReportViewer : Form
    {
        private string selectedGroupName;
        private List<ReportData> reportDataList;
        private string patientName, patientRefBy, patientDate, patientGender, patientAge, patientAgeUnit;

        public ReportViewer(List<ReportData> data, string name, string refBy, string date, string gender, string age, string ageUnit ,  string selectedGroupName)
        {
            InitializeComponent();
            reportDataList = data;
            patientName = name;
            patientRefBy = refBy;
            patientDate = date;
            patientGender = gender;
            patientAge = age;
            patientAgeUnit = ageUnit;
            this.selectedGroupName = selectedGroupName;
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            string currentDate = DateTime.Now.ToString();
            // Set the parameters for the patient's information
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("Textbox9", patientName),
                new ReportParameter("Textbox10", patientRefBy),
                new ReportParameter("Textbox11", patientDate),
                new ReportParameter("Textbox13", patientGender),
                new ReportParameter("Textbox14", patientAge),
                new ReportParameter("Textbox15", patientAgeUnit),
                new ReportParameter("Textbox12", currentDate),
                new ReportParameter("Textbox16", selectedGroupName)
            };


            this.reportViewer1.LocalReport.SetParameters(parameters);

            // Bind the reportDataList to the report's DataSource
            ReportDataSource rds = new ReportDataSource("DataSet1", reportDataList);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}
