using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4
{
    public partial class showResult : Form
    {
        ShowResults _showResults;
        public string PatientID { set { idtxt.Text = value; } get => idtxt.Text; }
        public string PatientTitle { set { TitleCom.Text = value; } get => TitleCom.Text; }
        public string PatientName { set { nametxt.Text = value; } get { return nametxt.Text; } }
        public string PatientGender { set { gendercom.Text = value; } get { return gendercom.Text; } }
        public string PatientAge { set { agetxt.Text = value; }  get { return agetxt.Text; } }
        public string PatientAgeUnit { set { unitagecom.Text = value; } get { return unitagecom.Text; } }
        public string PatientRefBy { set { refcom.Text = value; } get { return refcom.Text; } }
        public string PatientPhone { set { phonetxt.Text = value; } get { return phonetxt.Text; } }
        public string PatientDate { set { DatetextBox.Text = value; } get { return DatetextBox.Text; } }
        public string TestName { set { DatetextBox.Text = value; } get { return DatetextBox.Text; } }


        public showResult(ShowResults s)
        {
            _showResults = s;
            GlobalKeyHandler.RegisterGlobalShortcuts(this);
            InitializeComponent();

            groupBox1.Width = Screen.PrimaryScreen.Bounds.Width - 20;


        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _showResults.Show();
            this.Close();
        }


        private void showResult_Load_1(object sender, EventArgs e)
        {

            //////////////////////////
            ///
            ///
            laboratorySystemEntities1 db = new laboratorySystemEntities1();
            

            // Fetch the patient information
            var patient = db.Patients.FirstOrDefault(p => p.Name == nametxt.Text);
            if (patient == null)
            {
                MessageBox.Show("Patient not found.");
                return;
            }

            // Fetch the patient's test result
            var results = (from pr in db.patientResultValues
                           join st in db.Sub_Test on pr.testID equals st.SubTestID
                           join g in db.Main_Test_Group on st.GroupID equals g.GroupID
                           where pr.patient_id == patient.PatientID
                           select new
                           {
                               TestName = st.SubTestName,
                               pr.ResultValue
                           }).FirstOrDefault();

            if (results == null)
            {
                MessageBox.Show("No test results found for this patient.");
                return;
            }

            // Fetch normal values based on the patient's test and demographic info
            var normalValue = db.fn_GetNormalValueForTest(results.TestName, patient.Age, patient.Gender).FirstOrDefault();
            if (normalValue == null)
            {
                MessageBox.Show("No normal values found for this test.");
                return;
            }
            string re = results.ResultValue;
            if (re == "Result Pending")
            {
                re = "0";
            }
            string minValueStr = normalValue.MinValue;
            string maxValueStr = normalValue.MaxValue;
            string resultValueStr = re;

            // Attempt to parse the string values
            double minValue, maxValue, resultValue;
            bool isMinValueParsed = double.TryParse(minValueStr, out minValue);
            bool isMaxValueParsed = double.TryParse(maxValueStr, out maxValue);
            bool isResultValueParsed = double.TryParse(resultValueStr, out resultValue);

            if (isMinValueParsed && isMaxValueParsed && isResultValueParsed)
            {
                // Determine L/H/N status
                string lhStatus = "N";
                if (resultValue < minValue)
                {
                    lhStatus = "L";
                }
                else if (resultValue > maxValue)
                {
                    lhStatus = "H";
                }

                // Add data to ResultSDataGridView
                int rowIndex = ResultSDataGridView.Rows.Add(results.TestName, re, lhStatus, $"{minValue} - {maxValue}");
                ResultSDataGridView.Rows[rowIndex].ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Error parsing one or more values. Please check the data.");
            }

        }

        private void WhatsappButton_Click(object sender, EventArgs e)
        {
            string phoneNumber = phonetxt.Text;

            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                phoneNumber = phoneNumber.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

                if (!phoneNumber.StartsWith("+2"))
                {
                    phoneNumber = "+2" + phoneNumber;
                }

                string url = $"https://wa.me/{phoneNumber}";

                System.Diagnostics.Process.Start(url);
            }
            else
            {
                MessageBox.Show("Please enter a valid phone number.");
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {

            List<ReportData> reportDataList = new List<ReportData>();

            foreach (DataGridViewRow row in ResultSDataGridView.Rows)
            {
                if (row.Cells["TestDAtaGrid"].Value != null)
                {
                    reportDataList.Add(new ReportData
                    {
                        Test = row.Cells["TestDAtaGrid"].Value.ToString(),
                        Result = row.Cells["ResultDAtaGrid"].Value.ToString(),
                        NormalValue = row.Cells["NormalValueDAtaGrid"].Value.ToString()
                    });
                }
            }

            ReportViewer reportViewerForm = new ReportViewer(reportDataList, PatientName, PatientRefBy, PatientDate, PatientGender, PatientAge, PatientAgeUnit,"");
            reportViewerForm.Show();
        }
    }
}
